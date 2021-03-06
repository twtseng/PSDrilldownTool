﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using PSDrilldownTool.Forms;
using System.Data;

namespace PSDrilldownTool.Models
{

    public class AppData
    {
        public const string QueryScriptFont = "QueryScriptFont";
        public const string TextResultsFont = "TextResultsFont";
        public const string ResultTableFont = "ResultTableFont";

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
        /// </summary>
        public List<QueryScript> QueryScripts { get; set; }
        public Dictionary<string, string> LibraryScripts { get; set; }
        public Dictionary<string, object> Variables { get; set; }
        public Dictionary<string, string> Settings { get; set; }
        public Dictionary<string, DataTable> GetQueryScriptsTableResultsDictionary()
        {
            Dictionary<string, DataTable> tableResults = new Dictionary<string, DataTable>();
            foreach (QueryScript queryScript in QueryScripts)
            {
                tableResults[queryScript.Name] = queryScript.ResultDataTable;
            }
            return tableResults;
        }
        public QueryScript GetQueryScriptByName(string scriptName)
        {
            return QueryScripts.Where(x => x.Name == scriptName).FirstOrDefault();
        }
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
            // Set position based on script count
            int scriptIndex = AppData.GlobalAppData.QueryScripts.Count - 1;
            int positionIndex = scriptIndex % 20;
            int position = positionIndex * 30;
            queryScript.QueryScriptWindow.Location = new Point(position, position);
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
            int index = AppData.GlobalAppData.QueryScripts.Count - 1;
            index = index % 20;
            queryScript.QueryScriptWindow.Location = new Point(index * 30, index * 30);
            queryScript.QueryScriptWindow.Focus();
        }
        public void RenameQueryScript(string oldName, string newName)
        {
            // Rename the script token in any script that might be using it
            string oldToken = Util.ScriptUtil.ScriptNameToken(oldName);
            string newToken = Util.ScriptUtil.ScriptNameToken(newName);
            QueryScript scriptToRename = GetQueryScriptByName(oldName);
            scriptToRename.Name = newName;
            scriptToRename.QueryScriptWindow.SetWindowName(newName);
            foreach (QueryScript queryScript in QueryScripts)
            {
                if (!string.IsNullOrWhiteSpace(queryScript.ScriptText))
                {
                    queryScript.ScriptText = queryScript.ScriptText.Replace(oldToken, newToken);
                    queryScript.QueryScriptWindow.UpdateTranslatedQuery();
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

        public List<QueryScript> GetDependentQueryScripts(QueryScript script, bool allDescendants=true)
        {
            List<QueryScript> dependentQueryScripts = new List<QueryScript>();
            foreach (var queryScript in QueryScripts)
            {
                if (script != queryScript && queryScript.ScriptText != null && queryScript.ScriptText.Contains(Util.ScriptUtil.ScriptNameToken(script.Name)))
                {
                    dependentQueryScripts.Add(queryScript);
                    if (allDescendants)
                    {
                        foreach (QueryScript dependentScript in GetDependentQueryScripts(queryScript))
                        {
                            if (!dependentQueryScripts.Contains(dependentScript))
                            {
                                dependentQueryScripts.Add(dependentScript);
                            }
                        }
                    }
                }
            }
            return dependentQueryScripts;
        }
        public List<QueryScript> GetMasterQueryScripts(QueryScript script)
        {
            List<QueryScript> masterQueryScripts = new List<QueryScript>();
            foreach (var queryScript in QueryScripts)
            {
                if (script != queryScript && script.ScriptText != null && script.ScriptText.Contains(Util.ScriptUtil.ScriptNameToken(queryScript.Name)))
                {
                    masterQueryScripts.Add(queryScript);
                }
            }
            return masterQueryScripts;
        }
        public enum FontSetting
        {
            QueryScriptFont,
            ResultTableFont,
            TextResultsFont
        }
        static public Font FontFromString(string fontString)
        {
            FontConverter fontConverter = new FontConverter();
            try
            {
                return (Font)fontConverter.ConvertFromString(fontString);
            }
            catch
            {
                // Return a default font if this fails
                return new Font(family: FontFamily.GenericSansSerif, emSize: 10);
            }
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
            Settings[fontSetting.ToString()] = fontConverter.ConvertToString(font);
        }

        public void SaveToFile(string filename)
        {
            string appDataJson = JsonConvert.SerializeObject(this);

            // Workaround for dataTable null returned by SQL query
            appDataJson = appDataJson.Replace(@"{""IsNull"":true}", @"""""").Replace(@"{""IsNull"":false}", @"""""");
            System.IO.File.WriteAllText(filename, appDataJson);
        }
    }
}
