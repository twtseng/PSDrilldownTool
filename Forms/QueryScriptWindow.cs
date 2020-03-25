using PSDrilldownTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSDrilldownTool.Forms
{
    public partial class QueryScriptWindow : Form
    {
        #region Private members
        private QueryScript _queryScript;
        private Util.PowershellTask _powershellTask;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        #endregion
        #region Initialization
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public QueryScriptWindow(string name, QueryScript queryScript)
        {
            InitializeComponent();
            SetWindowName(name);
            this.MdiParent = queryScript.MainAppWindow;
            _queryScript = queryScript;
            richTextBox_ScriptText.DragEnter += RichTextBox_ScriptText_DragEnter;
        }

        private void QueryScriptWindow_Load(object sender, EventArgs e)
        {
            UpdateResultControls();
            UpdateTaskStatusControls();
        }

        public void SetWindowName(string name)
        {
            this.Text = name;
        }

        public void SetWindowLocation(int x, int y, int width, int height)
        {
            this.Location = new Point(x, y);
            this.Size = new Size(width, height);
        }
     
        private void QueryScriptWindow_Activated(object sender, EventArgs e)
        {
            _queryScript.MainAppWindow.SelectQueryScriptGridViewRow(name: this.Text);
            toolStripLabel1.Text = string.Format("Location: {0} Size: {1}", this.Location.ToString(), this.Size.ToString());
        }
        #endregion
        #region Output/Status update functions
        private void UpdateResultControls()
        {
            richTextBox_ScriptText.Text = _queryScript.ScriptText;
            richTextBox_TranslatedScript.Text = _queryScript.TranslatedScript;
            richTextBox_TextResults.Text = _queryScript.ResultText;
            dataGridView_TableResults.DataSource = _queryScript.ResultDataTable;
            if (_queryScript.ResultDataTable != null)
            {
                toolStripStatusLabel_RowCount.Text = _queryScript.ResultDataTable.Rows.Count.ToString() + " rows";
            }
        }
        private void UpdateTaskStatusControls()
        {
            toolStripStatusLabel_Duration.Text = "Duration: " + _queryScript.Duration.ToString(@"hh\:mm\:ss");
            toolStripStatusLabel_QueryStatus.Text = "Query " + _queryScript.TaskStatus.ToString();
            switch (_queryScript.TaskStatus)
            {
                case Util.PowershellTask.Status.COMPLETED:
                    toolStripStatusLabel_QueryStatus.BackColor = Color.LightGreen;
                    break;
                case Util.PowershellTask.Status.CANCELLED:
                case Util.PowershellTask.Status.FAILED:
                    toolStripStatusLabel_QueryStatus.BackColor = Color.IndianRed;
                    break;
                case Util.PowershellTask.Status.RUNNING:
                    toolStripStatusLabel_QueryStatus.BackColor = Color.Yellow;
                    break;
                default:
                    toolStripStatusLabel_QueryStatus.BackColor = Color.Gray;
                    break;
            }
            toolStripStatusLabel_TimeExecuted.Text = "Query start time: " + _queryScript.StartTime.ToString("MM/dd/yy hh:mm:ss tt");
        }
        #endregion
        #region Task Processing
        public void StartQuery()
        {
            Dictionary<string, object> variables = new Dictionary<string, object>(AppData.GlobalAppData.Variables);
            variables["AppData"] = AppData.GlobalAppData;

            _powershellTask = new Util.PowershellTask(
                scriptText: richTextBox_TranslatedScript.Text,
                variables: variables,
                scriptFiles: AppData.GlobalAppData.LibraryScripts.Values.ToList<string>()
                );
            toolStripButton_Start.Enabled = false;
            toolStripButton_Cancel.Enabled = true;
            dataGridView_TableResults.DataSource = null;
            dataGridView_TableResults.Rows.Clear();
            toolStripStatusLabel_RowCount.Text = "";
            _powershellTask.StartPsTaskAsync();
            timer1.Enabled = true;
        }
        private void toolStripButton_Start_Click(object sender, EventArgs e)
        {
            StartQuery();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _queryScript.LoadResultsFromPowershellTask(_powershellTask);
            UpdateTaskStatusControls();
            UpdateResultControls();
            if (_powershellTask.TaskCompleted)
            {
                timer1.Enabled = false;
                toolStripButton_Start.Enabled = true;
                toolStripButton_Cancel.Enabled = false;
            }
        }
        private void toolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            _powershellTask.CancelTask();
        }

        #endregion
        #region Script Editing and Translating
        public string ScriptReplacementToken
        {
            get { return "{" + this.Text + "}"; }
        }
        public string TableResultsReplacementToken
        {
            get { return ScriptReplacementToken + ".TableResults"; }
        }
        public string TableResultsReplacementValue
        {
            get { return "$appData.QueryScripts['" + this.Text + "'].ResultDataTable"; }
        }
        public string ColumnReplacementToken(string columnName)
        {
            return ScriptReplacementToken + ".[" + columnName + "]";
        }
        public Dictionary<string,string> ReplacementTokens
        {
            get
            {
                Dictionary<string, string> replacementTokens = new Dictionary<string, string>();
                replacementTokens[this.TableResultsReplacementToken] = this.TableResultsReplacementValue;
                if (dataGridView_TableResults.CurrentRow != null)
                {
                    foreach(DataGridViewColumn column in dataGridView_TableResults.Columns)
                    {
                        string columnName = column.HeaderText;
                        string replacementValue = 
                            dataGridView_TableResults.CurrentRow.Cells[columnName].Value != null 
                            ? dataGridView_TableResults.CurrentRow.Cells[columnName].Value.ToString()
                            : string.Empty;
                        string replacementToken = ColumnReplacementToken(columnName);
                        replacementTokens[replacementToken] = replacementValue;
                    }
                }
                return replacementTokens;
            }
        }
        private void richTextBox_ScriptText_TextChanged(object sender, EventArgs e)
        {
            _queryScript.ScriptText = richTextBox_ScriptText.Text;
            UpdateTranslatedQuery();
        }
        private void richTextBox_ScriptText_KeyDown(object sender, KeyEventArgs e)
        {
            // Override default richtext paste to only paste the text (we don't want formatting to get pasted)
            if (e.Control && e.KeyCode == Keys.V)
            {
                string textData = (string)Clipboard.GetData("Text");
                Clipboard.SetText(textData);
            }
        }

        private void UpdateTranslatedQuery()
        {
            string translatedQuery = richTextBox_ScriptText.Text;

            // Replace the QueryScript tokens with actual values
            foreach(QueryScript queryScript in AppData.GlobalAppData.QueryScripts)
            {
                if (queryScript.QueryScriptWindow != null)
                {
                    foreach (var kvp in queryScript.QueryScriptWindow.ReplacementTokens)
                    {
                        translatedQuery = translatedQuery.Replace(kvp.Key, kvp.Value);
                    }
                }
            }

            _queryScript.TranslatedScript = translatedQuery;
            richTextBox_TranslatedScript.Text = translatedQuery;
            _queryScript.MainAppWindow.UpdateDependentScriptsList();
        }
        private void dataGridView_TableResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update dependent script text and run (if RunOnParentRowSelect specified)
            foreach (QueryScript queryScript in AppData.GlobalAppData.GetDependentQueryScripts(_queryScript, allDecendants: false))
            {
                queryScript.QueryScriptWindow.UpdateTranslatedQuery();
                if (queryScript.RunOnParentRowSelect)
                {
                    queryScript.QueryScriptWindow.StartQuery();
                }
            }
        }

        #endregion
        #region Drag and Drop handling
        private void dataGridView_TableResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                // Copy columnName to dragdrop
                string columnName = dataGridView_TableResults.Columns[e.ColumnIndex].HeaderText;
                string scriptName = this.Text;
                string dragData = ColumnReplacementToken(columnName: columnName);
                dataGridView_TableResults.DoDragDrop(dragData, DragDropEffects.Copy);
            }
        }
        private void tabControl_Results_MouseDown(object sender, MouseEventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                // Copy script table to dragdrop
                string scriptName = this.Text;
                string dragData = TableResultsReplacementToken;
                dataGridView_TableResults.DoDragDrop(dragData, DragDropEffects.Copy);
            }
        }
        private void RichTextBox_ScriptText_DragEnter(object sender, DragEventArgs e)
        {
            string sourceScript = e.Data.GetData("Text").ToString();
            if (sourceScript.IndexOf("{") >= 0 && sourceScript.IndexOf("{") < sourceScript.IndexOf("}"))
            {
                sourceScript = sourceScript.Substring(1, sourceScript.IndexOf("}") - 1);
                if (AppData.GlobalAppData.GetDependentQueryScripts(_queryScript).Select(x => x.Name).Contains(sourceScript))
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
        #endregion
        #region Font editing
        public void SetQueryScriptFont(Font font)
        {
            richTextBox_ScriptText.Font = font;
            richTextBox_TranslatedScript.Font = font;
        }
        public void SetResultTableFont(Font font)
        {
            dataGridView_TableResults.Font = font;
        }
        public void SetTextResultsFont(Font font)
        {
            richTextBox_TextResults.Font = font;
        }
        #endregion
    }
}