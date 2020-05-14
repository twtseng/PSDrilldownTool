using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections;
using System.Data;

namespace PSDrilldownTool.Util
{
    public class PowershellTask
    {
        public enum Status
        {
            NOTSTARTED,
            RUNNING,
            COMPLETED,
            FAILED,
            CANCELLED
        };

        private Runspace _runspace;
        private string _scriptText = "";
        private Pipeline _pipeline = null;
        private Dictionary<string, object> _variables = null;
        private List<string> _scriptFiles;

        private DateTime _startTime;
        /// <summary>
        /// Time script started executing
        /// </summary>
        public DateTime StartTime { get { return _startTime; } }
        private DateTime _endTime;
        /// <summary>
        /// Time script stopped executing or was cancelled
        /// </summary>
        public DateTime EndTime { get { return _endTime; } }

        private StringBuilder _resultStringBuilder;
        /// <summary>
        /// Returns the text results from the script to the caller
        /// </summary>
        public string ResultText { get { return _resultStringBuilder.ToString(); } }
        private DataTable _resultDataTable;
        /// <summary>
        /// Returns the tabular results from the script to the caller for the *first* dataset found.
        /// TODO: Add support for multiple result tables if needed
        /// </summary>
        public DataTable ResultDataTable
        {
            // Return table results or empty table if there were no tabular results
            get
            {
                if (_resultDataTable == null)
                {
                    return new DataTable();
                }
                else
                {
                    return _resultDataTable;
                }
            }
        }

        enum DataTableType
        {
            None,
            DataRow,
            PSCustomObject
        }

        private DataTableType _dataTableType;
        private void SetDataTableFromPSCustomObject(PSObject psObject)
        {
            _resultDataTable = new DataTable();
            foreach(var prop in psObject.Properties)
            {
                _resultDataTable.Columns.Add(prop.Name, Type.GetType(prop.TypeNameOfValue));
            }
            _dataTableType = DataTableType.PSCustomObject;
        }
        private void ImportRowFromPSCustomObject(PSObject psObject)
        {
            var newRow = _resultDataTable.NewRow();
            foreach(DataColumn column in _resultDataTable.Columns)
            {
                if (psObject.Properties[column.ColumnName] != null)
                {
                    if (psObject.Properties[column.ColumnName].Value != null)
                    {
                        newRow[column.ColumnName] = psObject.Properties[column.ColumnName].Value;
                    }
                    else
                    {
                        newRow[column.ColumnName] = System.DBNull.Value;
                    }
                }
            }
            _resultDataTable.Rows.Add(newRow);
        }

        private Status _taskStatus;
        /// <summary>
        /// Current status for the task (from the PowershellTask.Status enumeration) 
        /// </summary>
        public Status TaskStatus { get { return _taskStatus; } }
        private bool _taskCompleted;
        /// <summary>
        /// True if the task is finished running. Does not necessarily mean the task is SUCCEEDED.
        /// We can also have TaskCompleted=true if the task was FAILED or CANCELLED
        /// </summary>
        public bool TaskCompleted { get { return _taskCompleted; } }

        /// <summary>
        /// If task is running, then how long has it been running.
        /// If task is completed, how long did it run for.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                if (EndTime == DateTime.MinValue)
                    return DateTime.Now - StartTime;
                else
                    return EndTime - StartTime;
            }
        }
        /// <summary>
        /// Create a PowershellTask to execute the specified scripts
        /// </summary>
        /// <param name="variables">Variables to pass into the powershell task</param>
        /// <param name="scriptFiles">List of script files to load prior to running scriptText. Loaded 1st into Pipeline.Commands</param>
        /// <param name="scriptText">Script text to perform the task. Loaded last into Pipeline.Commands</param>
        public PowershellTask(Dictionary<string, object> variables, List<string> scriptFiles, string scriptText)
        {
            _scriptText = scriptText;
            _scriptFiles = scriptFiles;
            _variables = variables;
            _dataTableType = DataTableType.None;
        }

        public bool CreatePsPipeline()
        {
            _startTime = DateTime.MinValue;
            _endTime = DateTime.MinValue;
            _taskCompleted = false;
            _taskStatus = Status.NOTSTARTED;
            _resultDataTable = null;
            _resultStringBuilder = new StringBuilder();
            try
            {
                InitialSessionState iss = InitialSessionState.CreateDefault();
                foreach (var v in _variables)
                {
                    SessionStateVariableEntry variable = new SessionStateVariableEntry(v.Key, v.Value, null);
                    iss.Variables.Add(variable);
                }
                _runspace = RunspaceFactory.CreateRunspace(initialSessionState: iss);
            }
            catch
            {
                _taskCompleted = true;
                _taskStatus = Status.FAILED;
                throw;
            }
            try
            {
                _runspace.Open();
                _pipeline = _runspace.CreatePipeline();
                foreach (var scriptFile in _scriptFiles)
                {
                    string scriptContent = System.IO.File.ReadAllText(scriptFile);
                    _pipeline.Commands.AddScript(scriptContent);
                }
                _pipeline.Commands.AddScript(_scriptText);
            }
            catch
            {
                _taskStatus = Status.FAILED;
                throw;
            }
            return true;
        }

        public void StartPsTaskAsync()
        {
            try
            {
                CreatePsPipeline();
                _taskStatus = Status.RUNNING;
                _startTime = DateTime.Now;
                _pipeline.Output.DataReady += DataReady;
                _pipeline.Error.DataReady += DataReady;
                _pipeline.InvokeAsync();
            }
            catch (Exception ex)
            {
                _taskCompleted = true;
                _taskStatus = Status.FAILED;
                string logMessage = string.Format("SCRIPT FAILED. Time:[{0:MM/dd/yy HH:mm:ss}] Error:{1}", DateTime.Now, ex.ToString());
                _resultStringBuilder.Append(logMessage);
            }
        }
        private void DataReady(object sender, EventArgs e)
        {
            CheckIsRunningAndReceiveAsyncResults();
        }

        /// <summary>
        /// Receives output from async powershell execution
        /// </summary> 
        public bool CheckIsRunningAndReceiveAsyncResults()
        {
            if (_taskCompleted)
            {
                return false;
            }
            try
            {
                while (_pipeline.Output.Peek() != System.Management.Automation.Internal.AutomationNull.Value)
                {
                    var r = _pipeline.Output.Read();
                    if (r == null)
                    {
                        // no-op
                    }
                    else if (r.BaseObject is System.Data.DataRow)
                    {
                        DataRow row = (DataRow)r.BaseObject;
                        if (_resultDataTable == null)
                        {
                            _resultDataTable = row.Table.Clone();
                            _dataTableType = DataTableType.DataRow;
                        }
                        if (_dataTableType == DataTableType.DataRow)
                        {
                            _resultDataTable.ImportRow(row);
                        }
                    }
                    else if (r.BaseObject is System.Management.Automation.PSCustomObject)
                    {
                        if (_resultDataTable == null)
                        {
                            SetDataTableFromPSCustomObject(r);
                            _dataTableType = DataTableType.PSCustomObject;
                        }
                        if (_dataTableType == DataTableType.PSCustomObject)
                        {
                            ImportRowFromPSCustomObject(r);
                        }
                    }
                    else
                    {
                        _resultStringBuilder.AppendLine(r.ToString());
                    }
                }
                if (_pipeline.HadErrors)
                {
                    _resultStringBuilder.AppendLine(_pipeline.PipelineStateInfo.Reason.ToString());
                    _taskStatus = Status.FAILED;
                }
            }
            catch (Exception ex)
            {
                _taskCompleted = true;
                _endTime = DateTime.Now;
                _taskStatus = Status.FAILED;
                string logMessage = string.Format(@"SCRIPT FAILED. Time:[{0:MM/dd/yy HH:mm:ss}] Duration:[{1}] Error:{2}", DateTime.Now, this.Duration.ToString(@"hh\:mm\:ss"), ex.ToString());
                _resultStringBuilder.Append(logMessage);
                return false;
            }
            if (_pipeline.PipelineStateInfo.State == PipelineState.Running)
            {
                _taskCompleted = false;
                return true;
            }
            else
            {
                if (_taskStatus == Status.RUNNING)
                {
                    _taskStatus = Status.COMPLETED;
                }
                _taskCompleted = true;
                _endTime = DateTime.Now;
                string logMessage = string.Format("SCRIPT {0}. Time:[{1:MM/dd/yy HH:mm:ss}] Duration:[{2}]", TaskStatus.ToString(), DateTime.Now, this.Duration.ToString(@"hh\:mm\:ss"));
                _resultStringBuilder.Append(logMessage);
                _runspace.Close();
                _runspace.Dispose();
                return false;
            }
        }
        /// <summary>
        /// Execute the script synchronously. 
        /// </summary>       
        public void RunPsTaskSync()
        {
            try
            {
                CreatePsPipeline();
                _startTime = DateTime.Now;
                _taskStatus = Status.RUNNING;
                foreach (var r in _pipeline.Invoke())
                {
                    if (r == null)
                    {
                        // no-op
                    }
                    else if (r.BaseObject is System.Data.DataRow)
                    {
                        DataRow row = (DataRow)r.BaseObject;
                        if (_resultDataTable == null)
                        {
                            _resultDataTable = row.Table.Clone();
                        }
                        _resultDataTable.ImportRow(row);
                    }
                    else
                    {
                        _resultStringBuilder.AppendLine(r.ToString());
                    }
                }
                _taskStatus = Status.COMPLETED;
                // Get errors (if any)
                foreach (var e in _pipeline.Error.ReadToEnd())
                {
                    _resultStringBuilder.AppendLine(e.ToString());
                    _taskStatus = Status.FAILED;
                }
                string logMessage = string.Format("SCRIPT {0}. Time:[{1:MM/dd/yy HH:mm:ss}] Duration:[{2}]", TaskStatus.ToString(), DateTime.Now, this.Duration.ToString(@"hh\:mm\:ss"));
                _resultStringBuilder.Append(logMessage);
            }
            catch (Exception ex)
            {
                _taskStatus = Status.FAILED;
                string logMessage = string.Format("SCRIPT FAILED. Time:[{1:MM/dd/yy HH:mm:ss}] Duration:[{2}] Error:{3}", TaskStatus.ToString(), DateTime.Now, this.Duration.ToString(@"hh\:mm\:ss"), ex.ToString());
                _resultStringBuilder.Append(logMessage);
            }
            finally
            {
                _taskCompleted = true;
            }
        }

        /// <summary>
        /// Method to allow caller to cancel the task. For example, the task is running for long time and user doesn't want to wait.
        /// </summary> 
        public void CancelTask()
        {
            _taskStatus = Status.CANCELLED;
            _pipeline.Stop();
        }
    }
}
