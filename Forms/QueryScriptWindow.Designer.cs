﻿namespace PSDrilldownTool.Forms
{
    partial class QueryScriptWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryScriptWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBox_ScriptText = new System.Windows.Forms.RichTextBox();
            this.label_ScriptText = new System.Windows.Forms.Label();
            this.richTextBox_TranslatedScript = new System.Windows.Forms.RichTextBox();
            this.label_TranslatedScript = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Start = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ResultsMaximized = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ResultsSplit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ResultsMinimized = new System.Windows.Forms.ToolStripButton();
            this.tabControl_Results = new System.Windows.Forms.TabControl();
            this.tabPage_TableResults = new System.Windows.Forms.TabPage();
            this.dataGridView_TableResults = new System.Windows.Forms.DataGridView();
            this.tabPage_TextResults = new System.Windows.Forms.TabPage();
            this.richTextBox_TextResults = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_QueryStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Duration = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_TimeExecuted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_RowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl_Results.SuspendLayout();
            this.tabPage_TableResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableResults)).BeginInit();
            this.tabPage_TextResults.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl_Results);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1141, 898);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 28);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBox_ScriptText);
            this.splitContainer2.Panel1.Controls.Add(this.label_ScriptText);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox_TranslatedScript);
            this.splitContainer2.Panel2.Controls.Add(this.label_TranslatedScript);
            this.splitContainer2.Size = new System.Drawing.Size(1141, 247);
            this.splitContainer2.SplitterDistance = 52;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 1;
            // 
            // richTextBox_ScriptText
            // 
            this.richTextBox_ScriptText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_ScriptText.EnableAutoDragDrop = true;
            this.richTextBox_ScriptText.Location = new System.Drawing.Point(0, 20);
            this.richTextBox_ScriptText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox_ScriptText.Name = "richTextBox_ScriptText";
            this.richTextBox_ScriptText.Size = new System.Drawing.Size(1141, 32);
            this.richTextBox_ScriptText.TabIndex = 1;
            this.richTextBox_ScriptText.Text = "";
            this.richTextBox_ScriptText.WordWrap = false;
            this.richTextBox_ScriptText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox_ScriptText_KeyDown);
            this.richTextBox_ScriptText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_ScriptText_KeyUp);
            // 
            // label_ScriptText
            // 
            this.label_ScriptText.AutoSize = true;
            this.label_ScriptText.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_ScriptText.Location = new System.Drawing.Point(0, 0);
            this.label_ScriptText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ScriptText.Name = "label_ScriptText";
            this.label_ScriptText.Size = new System.Drawing.Size(84, 20);
            this.label_ScriptText.TabIndex = 0;
            this.label_ScriptText.Text = "Script Text";
            // 
            // richTextBox_TranslatedScript
            // 
            this.richTextBox_TranslatedScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_TranslatedScript.Location = new System.Drawing.Point(0, 20);
            this.richTextBox_TranslatedScript.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox_TranslatedScript.Name = "richTextBox_TranslatedScript";
            this.richTextBox_TranslatedScript.ReadOnly = true;
            this.richTextBox_TranslatedScript.Size = new System.Drawing.Size(1141, 172);
            this.richTextBox_TranslatedScript.TabIndex = 2;
            this.richTextBox_TranslatedScript.Text = "";
            this.richTextBox_TranslatedScript.WordWrap = false;
            // 
            // label_TranslatedScript
            // 
            this.label_TranslatedScript.AutoSize = true;
            this.label_TranslatedScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_TranslatedScript.Location = new System.Drawing.Point(0, 0);
            this.label_TranslatedScript.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TranslatedScript.Name = "label_TranslatedScript";
            this.label_TranslatedScript.Size = new System.Drawing.Size(129, 20);
            this.label_TranslatedScript.TabIndex = 0;
            this.label_TranslatedScript.Text = "Translated Script";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Start,
            this.toolStripButton_Cancel,
            this.toolStripSeparator1,
            this.toolStripButton_ResultsMaximized,
            this.toolStripButton_ResultsSplit,
            this.toolStripButton_ResultsMinimized});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1141, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Start
            // 
            this.toolStripButton_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Start.Image = global::PSDrilldownTool.Properties.Resources.Image_StartScript_small;
            this.toolStripButton_Start.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Start.Name = "toolStripButton_Start";
            this.toolStripButton_Start.Size = new System.Drawing.Size(34, 23);
            this.toolStripButton_Start.Text = "Start";
            this.toolStripButton_Start.Click += new System.EventHandler(this.toolStripButton_Start_Click);
            // 
            // toolStripButton_Cancel
            // 
            this.toolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Cancel.Enabled = false;
            this.toolStripButton_Cancel.Image = global::PSDrilldownTool.Properties.Resources.Image_StopScript_small;
            this.toolStripButton_Cancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Cancel.Name = "toolStripButton_Cancel";
            this.toolStripButton_Cancel.Size = new System.Drawing.Size(34, 23);
            this.toolStripButton_Cancel.Text = "Cancel";
            this.toolStripButton_Cancel.ToolTipText = "Cancel";
            this.toolStripButton_Cancel.Click += new System.EventHandler(this.toolStripButton_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButton_ResultsMaximized
            // 
            this.toolStripButton_ResultsMaximized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsMaximized.Image = global::PSDrilldownTool.Properties.Resources.Results_Maximized;
            this.toolStripButton_ResultsMaximized.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsMaximized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsMaximized.Name = "toolStripButton_ResultsMaximized";
            this.toolStripButton_ResultsMaximized.Size = new System.Drawing.Size(34, 23);
            this.toolStripButton_ResultsMaximized.Text = "Results Maximized";
            this.toolStripButton_ResultsMaximized.Click += new System.EventHandler(this.toolStripButton_ResultsMaximized_Click);
            // 
            // toolStripButton_ResultsSplit
            // 
            this.toolStripButton_ResultsSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsSplit.Image = global::PSDrilldownTool.Properties.Resources.Results_Half;
            this.toolStripButton_ResultsSplit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsSplit.Name = "toolStripButton_ResultsSplit";
            this.toolStripButton_ResultsSplit.Size = new System.Drawing.Size(34, 23);
            this.toolStripButton_ResultsSplit.Text = "Results Split";
            this.toolStripButton_ResultsSplit.Click += new System.EventHandler(this.toolStripButton_ResultsSplit_Click);
            // 
            // toolStripButton_ResultsMinimized
            // 
            this.toolStripButton_ResultsMinimized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsMinimized.Image = global::PSDrilldownTool.Properties.Resources.Results_Minimized;
            this.toolStripButton_ResultsMinimized.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsMinimized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsMinimized.Name = "toolStripButton_ResultsMinimized";
            this.toolStripButton_ResultsMinimized.Size = new System.Drawing.Size(34, 23);
            this.toolStripButton_ResultsMinimized.Text = "Results Minimized";
            this.toolStripButton_ResultsMinimized.Click += new System.EventHandler(this.toolStripButton_ResultsMinimized_Click);
            // 
            // tabControl_Results
            // 
            this.tabControl_Results.Controls.Add(this.tabPage_TableResults);
            this.tabControl_Results.Controls.Add(this.tabPage_TextResults);
            this.tabControl_Results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Results.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Results.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl_Results.Name = "tabControl_Results";
            this.tabControl_Results.SelectedIndex = 0;
            this.tabControl_Results.Size = new System.Drawing.Size(1141, 588);
            this.tabControl_Results.TabIndex = 0;
            this.tabControl_Results.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_Results_MouseDown);
            // 
            // tabPage_TableResults
            // 
            this.tabPage_TableResults.Controls.Add(this.dataGridView_TableResults);
            this.tabPage_TableResults.Location = new System.Drawing.Point(4, 29);
            this.tabPage_TableResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_TableResults.Name = "tabPage_TableResults";
            this.tabPage_TableResults.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_TableResults.Size = new System.Drawing.Size(1133, 555);
            this.tabPage_TableResults.TabIndex = 0;
            this.tabPage_TableResults.Text = "Table Results";
            this.tabPage_TableResults.UseVisualStyleBackColor = true;
            // 
            // dataGridView_TableResults
            // 
            this.dataGridView_TableResults.AllowUserToAddRows = false;
            this.dataGridView_TableResults.AllowUserToDeleteRows = false;
            this.dataGridView_TableResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_TableResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_TableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TableResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TableResults.Location = new System.Drawing.Point(2, 2);
            this.dataGridView_TableResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_TableResults.Name = "dataGridView_TableResults";
            this.dataGridView_TableResults.RowHeadersWidth = 40;
            this.dataGridView_TableResults.RowTemplate.Height = 33;
            this.dataGridView_TableResults.Size = new System.Drawing.Size(1129, 551);
            this.dataGridView_TableResults.TabIndex = 1;
            this.dataGridView_TableResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_TableResults_CellClick);
            this.dataGridView_TableResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_TableResults_CellMouseDown);
            // 
            // tabPage_TextResults
            // 
            this.tabPage_TextResults.Controls.Add(this.richTextBox_TextResults);
            this.tabPage_TextResults.Location = new System.Drawing.Point(4, 29);
            this.tabPage_TextResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_TextResults.Name = "tabPage_TextResults";
            this.tabPage_TextResults.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage_TextResults.Size = new System.Drawing.Size(1133, 616);
            this.tabPage_TextResults.TabIndex = 1;
            this.tabPage_TextResults.Text = "Text Results";
            this.tabPage_TextResults.UseVisualStyleBackColor = true;
            // 
            // richTextBox_TextResults
            // 
            this.richTextBox_TextResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_TextResults.Location = new System.Drawing.Point(2, 2);
            this.richTextBox_TextResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox_TextResults.Name = "richTextBox_TextResults";
            this.richTextBox_TextResults.ReadOnly = true;
            this.richTextBox_TextResults.Size = new System.Drawing.Size(1129, 612);
            this.richTextBox_TextResults.TabIndex = 3;
            this.richTextBox_TextResults.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_QueryStatus,
            this.toolStripStatusLabel_Duration,
            this.toolStripStatusLabel_TimeExecuted,
            this.toolStripStatusLabel_RowCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1141, 32);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_QueryStatus
            // 
            this.toolStripStatusLabel_QueryStatus.Name = "toolStripStatusLabel_QueryStatus";
            this.toolStripStatusLabel_QueryStatus.Size = new System.Drawing.Size(108, 25);
            this.toolStripStatusLabel_QueryStatus.Text = "QueryStatus";
            // 
            // toolStripStatusLabel_Duration
            // 
            this.toolStripStatusLabel_Duration.Name = "toolStripStatusLabel_Duration";
            this.toolStripStatusLabel_Duration.Size = new System.Drawing.Size(81, 25);
            this.toolStripStatusLabel_Duration.Text = "Duration";
            // 
            // toolStripStatusLabel_TimeExecuted
            // 
            this.toolStripStatusLabel_TimeExecuted.Name = "toolStripStatusLabel_TimeExecuted";
            this.toolStripStatusLabel_TimeExecuted.Size = new System.Drawing.Size(120, 25);
            this.toolStripStatusLabel_TimeExecuted.Text = "TimeExecuted";
            // 
            // toolStripStatusLabel_RowCount
            // 
            this.toolStripStatusLabel_RowCount.Name = "toolStripStatusLabel_RowCount";
            this.toolStripStatusLabel_RowCount.Size = new System.Drawing.Size(94, 25);
            this.toolStripStatusLabel_RowCount.Text = "RowCount";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // QueryScriptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 898);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QueryScriptWindow";
            this.Text = "QueryScriptWindow";
            this.Activated += new System.EventHandler(this.QueryScriptWindow_Activated);
            this.Load += new System.EventHandler(this.QueryScriptWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl_Results.ResumeLayout(false);
            this.tabPage_TableResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TableResults)).EndInit();
            this.tabPage_TextResults.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBox_ScriptText;
        private System.Windows.Forms.Label label_ScriptText;
        private System.Windows.Forms.RichTextBox richTextBox_TranslatedScript;
        private System.Windows.Forms.Label label_TranslatedScript;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Start;
        private System.Windows.Forms.ToolStripButton toolStripButton_Cancel;
        private System.Windows.Forms.TabControl tabControl_Results;
        private System.Windows.Forms.TabPage tabPage_TableResults;
        private System.Windows.Forms.TabPage tabPage_TextResults;
        private System.Windows.Forms.DataGridView dataGridView_TableResults;
        private System.Windows.Forms.RichTextBox richTextBox_TextResults;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_QueryStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Duration;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_TimeExecuted;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_RowCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsMaximized;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsSplit;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsMinimized;
    }
}