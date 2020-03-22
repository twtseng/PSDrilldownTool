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
        public string Name { get; set; }
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
            this.Name = name;
            _mainAppWindow = mainAppWindow;
            _queryScriptWindow = new Forms.QueryScriptWindow(name: name, queryScript: this);
        }
        public QueryScript(Forms.MainAppWindow mainAppWindow, QueryScript queryScriptToClone) 
            : this(name: queryScriptToClone.Name, mainAppWindow: mainAppWindow)
        {
            this.Name = queryScriptToClone.Name;
            this.Duration = queryScriptToClone.Duration;
            this.EndTime = queryScriptToClone.EndTime;
            this.StartTime = queryScriptToClone.StartTime;
            this.ScriptText = queryScriptToClone.ScriptText;
            this.TranslatedScript = queryScriptToClone.TranslatedScript;
            this.RunOnParentRowSelect = queryScriptToClone.RunOnParentRowSelect;
            this.TaskStatus = queryScriptToClone.TaskStatus;
            this.ResultDataTable = queryScriptToClone.ResultDataTable;
            this.ResultText = queryScriptToClone.ResultText;
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
