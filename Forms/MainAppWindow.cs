using System;
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
                    UpdateDependentScriptsList();
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
                    row.DefaultCellStyle.BackColor = Color.Aqua;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        private void dataGridView_QueryScripts_Click(object sender, EventArgs e)
        {
            if (dataGridView_QueryScripts.CurrentRow != null && dataGridView_QueryScripts.CurrentRow.Cells[0].Value != null)
            {
                string scriptName = dataGridView_QueryScripts.CurrentRow.Cells["Column_Name"].Value.ToString();
                Models.QueryScript queryScript = AppData.GlobalAppData.QueryScripts.Where(x => x.Name == scriptName).FirstOrDefault();
                if (queryScript != null)
                {
                    queryScript.QueryScriptWindow.BringToFront();
                }
            }
            UpdateQueryScriptSettingsFromGridview();
        }
        private void dataGridView_QueryScripts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_QueryScripts.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dataGridView_QueryScripts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateQueryScriptSettingsFromGridview();
        }
        private void UpdateQueryScriptSettingsFromGridview()
        {
            foreach (DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells[0] != null && row.Cells[0].Value != null)
                {
                    string scriptName = row.Cells[0].Value.ToString();
                    var queryScript = AppData.GlobalAppData.QueryScripts.Where(x => x.Name == scriptName).FirstOrDefault();
                    if (queryScript != null)
                    {
                        queryScript.RunOnParentRowSelect = row.Cells[1].Value != null ? (bool)row.Cells[1].Value : false;
                    }
                }
            }
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
            try
            {
                AppData.GlobalAppData = JsonConvert.DeserializeObject<Models.AppData>(appDataJson);
                LoadGuiFromAppData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Load file failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetGuiAndCloseQueryScriptWindows()
        {
            dataGridView_Variables.Rows.Clear();
            dataGridView_LibScripts.Rows.Clear();
            dataGridView_QueryScripts.Rows.Clear();
            foreach(QueryScript queryScript in AppData.GlobalAppData.QueryScripts)
            {
                AppData.GlobalAppData.RemoveQueryScript(queryScript.Name);
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

            // We need to recreate the QueryScript objects so we can get a QueryScriptWindow created for them
            var queryScriptsCopy = AppData.GlobalAppData.QueryScripts.ToArray();
            AppData.GlobalAppData.QueryScripts.Clear();
            foreach (QueryScript queryScript in queryScriptsCopy)
            {
                string dependentScripts = string.Join(",", AppData.GlobalAppData.GetDependentQueryScripts(queryScript).Select(x => x.Name));
                // Columns are: ScriptName, RunOnParentRowSelect, DependentScripts, OldName (used for renaming the script)
                dataGridView_QueryScripts.Rows.Add(queryScript.Name, queryScript.RunOnParentRowSelect, dependentScripts, queryScript.Name);
                AppData.GlobalAppData.AddQueryScript(mainAppWindow: this, scriptToClone: queryScript);
            }

            // Load settings
            if (AppData.GlobalAppData.Settings.ContainsKey(AppData.FontSetting.QueryScriptFont.ToString()))
            {
                FontConverter fontConverter = new FontConverter();
                Font font = (Font) fontConverter.ConvertFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.QueryScriptFont.ToString()]);
                AppData.GlobalAppData.SetFont(AppData.FontSetting.QueryScriptFont, font);
                textBox_QueryScriptFont.Text = font.ToString();
            }
            if (AppData.GlobalAppData.Settings.ContainsKey(AppData.FontSetting.ResultTableFont.ToString()))
            {
                FontConverter fontConverter = new FontConverter();
                Font font = (Font)fontConverter.ConvertFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.ResultTableFont.ToString()]);
                AppData.GlobalAppData.SetFont(AppData.FontSetting.ResultTableFont, font);
                textBox_ResultTableFont.Text = font.ToString();
            }
            if (AppData.GlobalAppData.Settings.ContainsKey(AppData.FontSetting.TextResultsFont.ToString()))
            {
                FontConverter fontConverter = new FontConverter();
                Font font = (Font)fontConverter.ConvertFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.TextResultsFont.ToString()]);
                AppData.GlobalAppData.SetFont(AppData.FontSetting.TextResultsFont, font);
                textBox_TextResultsFont.Text = font.ToString();
            }
        }
        public void UpdateDependentScriptsList()
        {
            foreach(DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells["column_Name"].Value != null)
                {
                    string scriptName = row.Cells["column_Name"].Value.ToString();
                    QueryScript queryScript = AppData.GlobalAppData.GetQueryScriptByName(scriptName);
                    string dependentScripts = string.Join(",", AppData.GlobalAppData.GetDependentQueryScripts(queryScript).Select(x => x.Name));
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
            foreach(var scriptName in AppData.GlobalAppData.QueryScripts.Select(x => x.Name).ToArray())
            {
                if (!queryScriptsFromGui.Contains(scriptName))
                {
                    AppData.GlobalAppData.RemoveQueryScript(scriptName);
                }
            }

            // Update QueryScript properties from GUI
            foreach(DataGridViewRow row in dataGridView_QueryScripts.Rows)
            {
                if (row.Cells["Column_Name"].Value != null && AppData.GlobalAppData.QueryScripts.Exists(x => x.Name == row.Cells["Column_Name"].Value.ToString()))
                {
                    var queryScript = AppData.GlobalAppData.QueryScripts.Where(x => x.Name == row.Cells["Column_Name"].Value.ToString()).FirstOrDefault();
                    if (queryScript != null)
                    {
                        queryScript.RunOnParentRowSelect = row.Cells["Column_AutoRun"].Value != null
                            ? (bool)row.Cells["Column_AutoRun"].Value
                            : false;
                    }
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
        #region Font editing
        private void textBox_QueryScriptFont_DoubleClick(object sender, EventArgs e)
        {
            fontDialog1.Font = AppData.FontFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.QueryScriptFont.ToString()]);
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_QueryScriptFont.Text = fontDialog1.Font.ToString();
                AppData.GlobalAppData.SetFont(AppData.FontSetting.QueryScriptFont, fontDialog1.Font);
            }
        }

        private void textBox_ResultTableFont_DoubleClick(object sender, EventArgs e)
        {
            fontDialog1.Font = AppData.FontFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.ResultTableFont.ToString()]);
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_ResultTableFont.Text = fontDialog1.Font.ToString();
                AppData.GlobalAppData.SetFont(AppData.FontSetting.ResultTableFont, fontDialog1.Font);
            }
        }

        private void textBox_TextResultsFont_DoubleClick(object sender, EventArgs e)
        {
            fontDialog1.Font = AppData.FontFromString(AppData.GlobalAppData.Settings[AppData.FontSetting.TextResultsFont.ToString()]);
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_TextResultsFont.Text = fontDialog1.Font.ToString();
                AppData.GlobalAppData.SetFont(AppData.FontSetting.TextResultsFont, fontDialog1.Font);
            }
        }
        #endregion
        #region QueryScriptWindow Layouts
        private Rectangle GetMdiRectangle()
        {
            Rectangle rectangle = new Rectangle(0, 0,
                width: (this.ClientRectangle.Width - splitter1.Location.X - 10),
                height: this.ClientRectangle.Height - 30
                );
            return rectangle;
        }

        public QueryScript CurrentlySelectedQueryScript
        {
            get
            {
                QueryScript queryScript = null;
                if (dataGridView_QueryScripts.CurrentRow != null
                && dataGridView_QueryScripts.CurrentRow.Cells[0] != null
                && dataGridView_QueryScripts.CurrentRow.Cells[0].Value != null)
                {
                    string scriptName = dataGridView_QueryScripts.CurrentRow.Cells[0].Value.ToString();
                    queryScript = AppData.GlobalAppData.GetQueryScriptByName(scriptName: scriptName);
                }
                return queryScript;
            }
        }
        private void LayoutQueryScriptWindows(QueryScript selectedScript, DockStyle dock, List<QueryScript> relatedScripts)
        {
            Rectangle rect = this.GetMdiRectangle();
            int selectedWidth=0;
            int selectedHeight=0;
            int selectedX = 0;
            int selectedY = 0;
            int relatedWidth = 0;
            int relatedHeight = 0;

            switch (dock)
            {
                case DockStyle.Top:
                    selectedWidth = rect.Width;
                    selectedHeight = rect.Height / 2;
                    selectedX = 0;
                    selectedY = 0;
                    relatedWidth = relatedScripts.Count > 0 ? rect.Width / relatedScripts.Count : 0;
                    relatedHeight = rect.Height / 2;
                    break;
                case DockStyle.Bottom:
                    selectedWidth = rect.Width;
                    selectedHeight = rect.Height / 2;
                    selectedX = 0;
                    selectedY = selectedHeight;
                    relatedWidth = relatedScripts.Count > 0 ? rect.Width / relatedScripts.Count : 0;
                    relatedHeight = rect.Height / 2;
                    break;
                case DockStyle.Left:
                    selectedWidth = rect.Width / 2;
                    selectedHeight = rect.Height;
                    selectedX = 0;
                    selectedY = 0;
                    relatedWidth = rect.Width / 2;
                    relatedHeight = relatedScripts.Count > 0 ? rect.Height / relatedScripts.Count : 0;
                    break;
                case DockStyle.Right:
                    selectedWidth = rect.Width / 2;
                    selectedHeight = rect.Height;
                    selectedX = selectedWidth;
                    selectedY = 0;
                    relatedWidth = rect.Width / 2 ;
                    relatedHeight = relatedScripts.Count > 0 ? rect.Height / relatedScripts.Count : 0;
                    break;
            }

            for (int i = 0; i < relatedScripts.Count; ++i)
            {
                QueryScript relatedScript = relatedScripts[i];
                int x = i * relatedWidth * (dock == DockStyle.Top || dock == DockStyle.Bottom ? 1 : 0)
                    + (dock == DockStyle.Left ? selectedWidth : 0);
                int y = i * relatedHeight * (dock == DockStyle.Left || dock == DockStyle.Right ? 1 : 0)
                    + (dock == DockStyle.Top ? selectedHeight : 0);
                relatedScript.QueryScriptWindow.SetWindowLocation(x,y,relatedWidth,relatedHeight);
                relatedScript.QueryScriptWindow.Focus();
            }
            this.CurrentlySelectedQueryScript.QueryScriptWindow.SetWindowLocation(selectedX, selectedY, selectedWidth, selectedHeight);
            this.CurrentlySelectedQueryScript.QueryScriptWindow.Focus();
        }
        private void toolStripButton_MasterTop_Click(object sender, EventArgs e)
        {
            if (this.CurrentlySelectedQueryScript != null)
            {
                var dependentScripts = AppData.GlobalAppData.GetDependentQueryScripts(this.CurrentlySelectedQueryScript, allDecendants: false);
                LayoutQueryScriptWindows(selectedScript: this.CurrentlySelectedQueryScript, dock: DockStyle.Top, relatedScripts: dependentScripts);
            }
        }
        private void toolStripButton_MasterLeft_Click(object sender, EventArgs e)
        {
            if (this.CurrentlySelectedQueryScript != null)
            {
                var dependentScripts = AppData.GlobalAppData.GetDependentQueryScripts(this.CurrentlySelectedQueryScript, allDecendants: false);
                LayoutQueryScriptWindows(selectedScript: this.CurrentlySelectedQueryScript, dock: DockStyle.Left, relatedScripts: dependentScripts);
            }
        }

        private void toolStripButton_SlaveBottom_Click(object sender, EventArgs e)
        {
            if (this.CurrentlySelectedQueryScript != null)
            {
                var masterScripts = AppData.GlobalAppData.GetMasterQueryScripts(this.CurrentlySelectedQueryScript);
                LayoutQueryScriptWindows(selectedScript: this.CurrentlySelectedQueryScript, dock: DockStyle.Bottom, relatedScripts: masterScripts);
            }
        }

        private void toolStripButton_SlaveRight_Click(object sender, EventArgs e)
        {
            if (this.CurrentlySelectedQueryScript != null)
            {
                var masterScripts = AppData.GlobalAppData.GetMasterQueryScripts(this.CurrentlySelectedQueryScript);
                LayoutQueryScriptWindows(selectedScript: this.CurrentlySelectedQueryScript, dock: DockStyle.Right, relatedScripts: masterScripts);
            }
        }

        private void toolStripButton_Fanned_Click(object sender, EventArgs e)
        {
            Rectangle rect = this.GetMdiRectangle();
            int width =  (int) (rect.Width * .7);
            int height = (int)(rect.Height * .7);
            for (int i=0; i < AppData.GlobalAppData.QueryScripts.Count; ++i)
            {
                AppData.GlobalAppData.QueryScripts[i].QueryScriptWindow.SetWindowLocation(i*50, i*50, width, height);
                AppData.GlobalAppData.QueryScripts[i].QueryScriptWindow.Focus();
            }
        }
        private void SetQueryWindowSplitterPercent(int percent)
        {
            foreach(QueryScript queryScript in AppData.GlobalAppData.QueryScripts)
            {
                queryScript.QueryScriptWindow.SetSplitterPercent(percent);
            }
        }
        private void toolStripButton_ResultsSplit_Click(object sender, EventArgs e)
        {
            SetQueryWindowSplitterPercent(50);
        }

        private void toolStripButton_ResultsMaximized_Click(object sender, EventArgs e)
        {
            SetQueryWindowSplitterPercent(10);
        }

        private void toolStripButton_ResultsMinimized_Click(object sender, EventArgs e)
        {
            SetQueryWindowSplitterPercent(90);
        }
        #endregion
    }
}
