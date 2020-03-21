using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace PSDrilldownTool.Models
{
    public class QueryScript
    {
        /// <summary>
        /// Default constructor for json deserialization when loading from a file
        /// </summary>
        public QueryScript() { }
        public string ScriptText { get; set; }
        public string TranslatedScript { get; set; }
        public bool RunOnParentRowSelect { get; set; }
        public DataTable ResultDataTable { get; set; }
        public string ResultText { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Util.PowershellTask.Status TaskStatus { get; set; }

        public void LoadResultsFromPowershellTask(Util.PowershellTask powershellTask)
        {
            ResultDataTable = powershellTask.ResultDataTable;
            ResultText = powershellTask.ResultText;
            TaskStatus = powershellTask.TaskStatus;
            StartTime = powershellTask.StartTime;
            EndTime = powershellTask.EndTime;
            Duration = powershellTask.Duration;
        }

        public QueryScript(string name, Forms.MainAppWindow mainAppWindow)
        {
            _mainAppWindow = mainAppWindow;
            _queryScriptWindow = new Forms.QueryScriptWindow(name: name, queryScript: this);
        }
        public QueryScript(string name, Forms.MainAppWindow mainAppWindow, QueryScript queryScript) 
            : this(name: name, mainAppWindow: mainAppWindow)
        {
            this.Duration = queryScript.Duration;
            this.EndTime = queryScript.EndTime;
            this.StartTime = queryScript.StartTime;
            this.ScriptText = queryScript.ScriptText;
            this.TranslatedScript = queryScript.TranslatedScript;
            this.RunOnParentRowSelect = queryScript.RunOnParentRowSelect;
            this.TaskStatus = queryScript.TaskStatus;
            this.ResultDataTable = queryScript.ResultDataTable;
            this.ResultText = queryScript.ResultText;
        }
        private Forms.MainAppWindow _mainAppWindow;
        [JsonIgnore]
        public Forms.MainAppWindow MainAppWindow
        {
            get { return _mainAppWindow; }
        }
        private Forms.QueryScriptWindow _queryScriptWindow;
        [JsonIgnore]
        public Forms.QueryScriptWindow QueryScriptWindow
        {
            get { return _queryScriptWindow; }
        }
    }
}
