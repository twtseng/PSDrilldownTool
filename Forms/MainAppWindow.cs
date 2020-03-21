﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PSDrilldownTool.Models;

namespace PSDrilldownTool.Forms
{
    public partial class MainAppWindow : Form
    {
        private string _filename;

        #region Initialization
        public MainAppWindow()
        {
            InitializeComponent();
            _filename = string.Empty;
        }
        private void MainAppWindow_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region QueryScript List Edit Controls
        private void dataGridView_QueryScripts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow curRow = dataGridView_QueryScripts.Rows[e.RowIndex];
                string newName = curRow.Cells["Column_Name"].Value != null ? curRow.Cells["Column_Name"].Value.ToString() : string.Empty;
                string oldName = curRow.Cells["Column_OldName"].Value != null ? curRow.Cells["Column_OldName"].Value.ToString() : string.Empty;
                if (string.IsNullOrWhiteSpace(newName))
                {
                    newName = AppData.GlobalAppData.NewDefaultQueryScriptName();
                    curRow.Cells["Column_Name"].Value = newName;

                }
                if (string.IsNullOrWhiteSpace(oldName))
                {
                    AppData.GlobalAppData.AddQueryScript(name: newName, mainAppWindow: this);
                }
                else
                {
                    AppData.GlobalAppData.RenameQueryScript(oldName: oldName, newName: newName);
                }
                curRow.Cells["Column_OldName"].Value = newName;
            }
        }
        private void dataGridView_QueryScripts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LoadAppDataFromGui();
        }
        public void SelectQueryScriptGridViewRow(string name)
        {
            foreach(DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString()==name)
                {
                    row.Selected = true;
                    return;
                }
            }
        }
        private void dataGridView_QueryScripts_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control && dataGridView_QueryScripts.CurrentRow.Cells[0].Value != null)
            {
                string scriptName = dataGridView_QueryScripts.CurrentRow.Cells[0].Value.ToString();
                Models.QueryScript queryScript = AppData.GlobalAppData.QueryScripts[scriptName];
                queryScript.QueryScriptWindow.Show();
                queryScript.QueryScriptWindow.Focus();
            }
        }
        private void dataGridView_QueryScripts_Leave(object sender, EventArgs e)
        {
            LoadAppDataFromGui();
        }
        #endregion
        #region File Operations
        private void SetFilename(string filename)
        {
            _filename = filename;
            this.Text = "Powershell Drilldown Tool - " + _filename;
        }

        private void LoadAppDataAndGuiDataFromJson(string appDataJson)
        {

            AppData.GlobalAppData = JsonConvert.DeserializeObject<Models.AppData>(appDataJson);
            LoadGuiFromAppData();
        }
        private void ResetGuiAndCloseQueryScriptWindows()
        {
            dataGridView_Variables.Rows.Clear();
            dataGridView_LibScripts.Rows.Clear();
            dataGridView_QueryScripts.Rows.Clear();
            foreach(string queryScript in AppData.GlobalAppData.QueryScripts.Keys.ToArray())
            {
                AppData.GlobalAppData.RemoveQueryScript(queryScript);
            }
        }
        private void LoadGuiFromAppData()
        {
            // Load settings
            foreach (var kvp in AppData.GlobalAppData.Variables)
            {
                dataGridView_Variables.Rows.Add(kvp.Key, kvp.Value);
            }

            // Load scripts
            foreach (var kvp in AppData.GlobalAppData.LibraryScripts)
            {
                dataGridView_LibScripts.Rows.Add(kvp.Key, kvp.Value);
            }

            // Load the scripts
            foreach (var kvp in AppData.GlobalAppData.QueryScripts.ToArray())
            {
                // TO DO: Set the 3rd column for "Dependencies"
                string dependentScripts = string.Join(",", AppData.GlobalAppData.GetDependentQueryScriptNames(kvp.Key));
                dataGridView_QueryScripts.Rows.Add(kvp.Key, kvp.Value.RunOnParentRowSelect, dependentScripts);
                AppData.GlobalAppData.AddQueryScript(name: kvp.Key, mainAppWindow: this, scriptToClone: kvp.Value);
            }
        }
        public void UpdateDependentScriptsList()
        {
            foreach(DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells["column_Name"].Value != null)
                {
                    string dependentScripts = string.Join(",", AppData.GlobalAppData.GetDependentQueryScriptNames(row.Cells["column_Name"].Value.ToString()));
                    row.Cells["column_Dependencies"].Value = dependentScripts;
                }
            }
        }
        private void LoadAppDataFromGui()
        {
            // Load variables
            AppData.GlobalAppData.Variables.Clear();
            foreach (DataGridViewRow row in dataGridView_Variables.Rows)
            {
                string varName = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                string varValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                if (!string.IsNullOrWhiteSpace(varName) && !string.IsNullOrWhiteSpace(varValue))
                {
                    AppData.GlobalAppData.Variables[varName] = varValue;
                }
            }

            // Load lib scripts
            AppData.GlobalAppData.LibraryScripts.Clear();
            foreach (DataGridViewRow row in dataGridView_LibScripts.Rows)
            {
                string varName = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                string varValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                if (!string.IsNullOrWhiteSpace(varName) && !string.IsNullOrWhiteSpace(varValue))
                {
                    AppData.GlobalAppData.LibraryScripts[varName] = varValue;
                }
            }

            // Remove QueryScripts from the AppData that have been removed from the GUI
            var queryScriptsFromGui = from DataGridViewRow row in dataGridView_QueryScripts.Rows
                                      where row.Cells["Column_Name"].Value != null
                                      select row.Cells["Column_Name"].Value.ToString();
            foreach(var scriptName in AppData.GlobalAppData.QueryScripts.Keys.ToArray())
            {
                if (!queryScriptsFromGui.Contains(scriptName))
                {
                    AppData.GlobalAppData.RemoveQueryScript(scriptName);
                }
            }

            // Update QueryScript properties from GUI
            foreach(DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells["Column_Name"].Value != null && AppData.GlobalAppData.QueryScripts.ContainsKey(row.Cells["Column_Name"].Value.ToString()))
                {
                    var queryScript = AppData.GlobalAppData.QueryScripts[row.Cells["Column_Name"].Value.ToString()];
                    queryScript.RunOnParentRowSelect = row.Cells["Column_AutoRun"].Value != null 
                        ? (bool) row.Cells["Column_AutoRun"].Value
                        : false;
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.json files|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetFilename(Util.FileUtil.GetRelativePath(openFileDialog.FileName));
                string appDataJson = System.IO.File.ReadAllText(_filename);
                ResetGuiAndCloseQueryScriptWindows();
                LoadAppDataAndGuiDataFromJson(appDataJson);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.json files|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetFilename(Util.FileUtil.GetRelativePath(saveFileDialog.FileName));
                ResetGuiAndCloseQueryScriptWindows();
                AppData.GlobalAppData = new AppData();
                LoadGuiFromAppData();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAppDataFromGui();
            if (string.IsNullOrWhiteSpace(_filename))
            {
                saveAsToolStripMenuItem_Click(this, null);
            }
            else
            {
                string appDataJson = JsonConvert.SerializeObject(AppData.GlobalAppData);
                System.IO.File.WriteAllText(_filename, appDataJson);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.json files|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadAppDataFromGui();
                SetFilename(Util.FileUtil.GetRelativePath(saveFileDialog.FileName));
                string appDataJson = JsonConvert.SerializeObject(AppData.GlobalAppData);
                System.IO.File.WriteAllText(_filename, appDataJson);
            }
        }
        #endregion
        #region LibScript Management
        private void dataGridView_LibScripts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView_LibScripts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "*.ps1 files|*.ps1";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(openFileDialog.FileName);
                    dataGridView_LibScripts.Rows.Add(fileInfo.Name, Util.FileUtil.GetRelativePath(fileInfo.FullName));
                }
            }
        }

        private void dataGridView_LibScripts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open selected powershell script in powershell_ise
            if (dataGridView_LibScripts.CurrentRow.Cells[1].Value != null)
            {
                string scriptPath = dataGridView_LibScripts.CurrentRow.Cells[1].Value.ToString();
                System.Diagnostics.Process.Start("powershell_ise", scriptPath);
            }
        }
        private void dataGridView_LibScripts_Leave(object sender, EventArgs e)
        {
            AppData.GlobalAppData.LibraryScripts.Clear();
            foreach (DataGridViewRow row in dataGridView_LibScripts.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    AppData.GlobalAppData.LibraryScripts[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                }
            }
        }
        #endregion
        #region Variables Management
        private void dataGridView_Variables_Leave(object sender, EventArgs e)
        {
            AppData.GlobalAppData.Variables.Clear();
            foreach (DataGridViewRow row in dataGridView_Variables.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    AppData.GlobalAppData.Variables[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                }
            }
        }
        #endregion
    }
}
