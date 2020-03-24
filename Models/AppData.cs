using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using PSDrilldownTool.Forms;

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
            QueryScripts = new List<QueryScript>();
            LibraryScripts = new Dictionary<string, string>();
            Variables = new Dictionary<string, object>();
            Settings = new Dictionary<string, string>();
        }
        /// <summary>
        /// The store of all of the QueryScripts.
        /// The key is the store for the "script names".
        /// </summary>
        public List<QueryScript> QueryScripts { get; set; }
        public Dictionary<string, string> LibraryScripts { get; set; }
        public Dictionary<string, object> Variables { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        
        public void AddQueryScript(string name, Forms.MainAppWindow mainAppWindow)
        {
            // Exit if script name already exists
            if (QueryScripts.Exists(x => x.Name == name))
            {
                return;
            }
            Models.QueryScript queryScript = new Models.QueryScript(name: name, mainAppWindow: mainAppWindow);
            QueryScripts.Add(queryScript);
            queryScript.QueryScriptWindow.Show();
            queryScript.QueryScriptWindow.Focus();
        }
        public void AddQueryScript(Forms.MainAppWindow mainAppWindow, Models.QueryScript scriptToClone)
        {
            // Exit if script name already exists
            if (QueryScripts.Exists(x => x.Name == scriptToClone.Name))
            {
                return;
            }
            Models.QueryScript queryScript = new Models.QueryScript(mainAppWindow: mainAppWindow, queryScriptToClone: scriptToClone);
            QueryScripts.Add(queryScript);
            queryScript.QueryScriptWindow.Show();
            queryScript.QueryScriptWindow.Focus();
        }
        public void RenameQueryScript(string oldName, string newName)
        {
            // Rename the script token in any script that might be using it
            string oldToken = Util.ScriptUtil.ScriptNameToken(oldName);
            string newToken = Util.ScriptUtil.ScriptNameToken(newName);
            foreach (QueryScript queryScript in QueryScripts)
            {
                if (!string.IsNullOrWhiteSpace(queryScript.ScriptText))
                {
                    queryScript.ScriptText = queryScript.ScriptText.Replace(oldToken, newToken);
                }
                if (queryScript.Name == oldName)
                {
                    queryScript.QueryScriptWindow.SetWindowName(newName);
                    queryScript.Name = newName;
                }
            }
        }
        public void RemoveQueryScript(string name)
        {
            QueryScript queryScript = QueryScripts.Where(x => x.Name == name).FirstOrDefault();
            if (queryScript != null)
            {
                queryScript.QueryScriptWindow.Close();
                QueryScripts.Remove(queryScript);
            }
        }
        public string NewDefaultQueryScriptName()
        {
            for(int i=0; i < 1000;++i)
            {
                string scriptName = $"QueryScript_{i}";
                if (QueryScripts.Where(x => x.Name == scriptName).Count() == 0)
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
        public List<string> GetDependentQueryScriptNames(string scriptName, bool allDecendants=true)
        {
            List<string> dependentQueryScripts = new List<string>();
            foreach (var queryScript in QueryScripts)
            {
                if (queryScript.ScriptText != null && queryScript.ScriptText.Contains(AppData.ScriptReplacementToken(scriptName)))
                {
                    dependentQueryScripts.Add(queryScript.Name);
                    if (allDecendants)
                    {
                        foreach (string subScriptName in GetDependentQueryScriptNames(queryScript.Name))
                        {
                            if (!dependentQueryScripts.Contains(subScriptName))
                            {
                                dependentQueryScripts.Add(subScriptName);
                            }
                        }
                    }
                }
            }
            return dependentQueryScripts;
        }

        public enum FontSetting
        {
            QueryScriptFont,
            ResultTableFont,
            TextResultsFont
        }
        public void SetFont(FontSetting fontSetting, Font font)
        {
            foreach (QueryScript queryScript in QueryScripts)
            {
                switch (fontSetting)
                {
                    case FontSetting.QueryScriptFont:
                        queryScript.QueryScriptWindow.SetQueryScriptFont(font);
                        break;
                    case FontSetting.ResultTableFont:
                        queryScript.QueryScriptWindow.SetResultTableFont(font);
                        break;
                    case FontSetting.TextResultsFont:
                        queryScript.QueryScriptWindow.SetTextResultsFont(font);
                        break;
                }
            }
            FontConverter fontConverter = new FontConverter();
            Settings[fontSetting.ToString()] = fontConverter.ConvertToString(font); ;
        }
    }
}
