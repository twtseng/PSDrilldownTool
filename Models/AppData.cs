using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PSDrilldownTool.Models
{

    public class AppData
    {
        private static AppData _globalAppData;
        public static AppData GlobalAppData
        {
            get
            {
                if (_globalAppData == null)
                {
                    _globalAppData = new AppData();
                }
                return _globalAppData;
            }
            set
            {
                _globalAppData = value;
            }
        }
        public AppData()
        {
            QueryScripts = new Dictionary<string, QueryScript>();
            LibraryScripts = new Dictionary<string, string>();
            Variables = new Dictionary<string, object>();
            Settings = new Dictionary<string, string>();
        }
        /// <summary>
        /// The store of all of the QueryScripts.
        /// The key is the store for the "script names".
        /// </summary>
        public Dictionary<string, QueryScript> QueryScripts { get; set; }
        public Dictionary<string, string> LibraryScripts { get; set; }
        public Dictionary<string, object> Variables { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        
        public void AddQueryScript(string name, Forms.MainAppWindow mainAppWindow)
        {
            Models.QueryScript queryScript = new Models.QueryScript(name: name, mainAppWindow: mainAppWindow);
            QueryScripts[name] = queryScript;
            queryScript.QueryScriptWindow.Show();
            queryScript.QueryScriptWindow.Focus();
        }
        public void AddQueryScript(string name, Forms.MainAppWindow mainAppWindow, Models.QueryScript scriptToClone)
        {
            Models.QueryScript queryScript = new Models.QueryScript(name: name, mainAppWindow: mainAppWindow, queryScript: scriptToClone);
            QueryScripts[name] = queryScript;
            queryScript.QueryScriptWindow.Show();
            queryScript.QueryScriptWindow.Focus();
        }
        public void RenameQueryScript(string oldName, string newName)
        {
            // Rename the script token in any script that might be using it
            string oldToken = Util.ScriptUtil.ScriptNameToken(oldName);
            string newToken = Util.ScriptUtil.ScriptNameToken(newName);
            foreach (QueryScript queryScript in QueryScripts.Values)
            {
                if (!string.IsNullOrWhiteSpace(queryScript.ScriptText))
                {
                    queryScript.ScriptText = queryScript.ScriptText.Replace(oldToken, newToken);
                }
            }

            // Rename script's key in the QueryScripts dictionary
            QueryScript scriptToRename = QueryScripts[oldName];
            QueryScripts.Remove(oldName);
            QueryScripts.Add(newName, scriptToRename);

            // Rename the window title
            scriptToRename.QueryScriptWindow.SetWindowName(newName);
        }
        public void RemoveQueryScript(string name)
        {
            if (QueryScripts.ContainsKey(name))
            {
                if (QueryScripts[name].QueryScriptWindow != null)
                {
                    QueryScripts[name].QueryScriptWindow.Close();
                }
                QueryScripts.Remove(name);
            }
        }
        public string NewDefaultQueryScriptName()
        {
            for(int i=0; i < 1000;++i)
            {
                string scriptName = $"QueryScript_{i}";
                if (QueryScripts.ContainsKey(scriptName) == false)
                {
                    return scriptName;
                }
            }
            // Return a guid if 0 through 999 are all used up
            return System.Guid.NewGuid().ToString();
        }

        static string ScriptReplacementToken(string scriptName)
        {
            return "{" + scriptName + "}";
        }
        public List<string> GetDependentQueryScriptNames(string scriptName)
        {
            List<string> dependentQueryScripts = new List<string>();
            foreach (var kvp in QueryScripts)
            {
                if (kvp.Value.ScriptText != null && kvp.Value.ScriptText.Contains(AppData.ScriptReplacementToken(scriptName)))
                {
                    dependentQueryScripts.Add(kvp.Key);
                    foreach(string subScriptName in GetDependentQueryScriptNames(kvp.Key))
                    {
                        if (!dependentQueryScripts.Contains(subScriptName))
                        {
                            dependentQueryScripts.Add(subScriptName);
                        }
                    }
                }
            }
            return dependentQueryScripts;
        }
    }
}
