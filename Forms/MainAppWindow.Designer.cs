namespace PSDrilldownTool.Forms
{
    partial class MainAppWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAppWindow));
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_QueryScripts = new System.Windows.Forms.TabPage();
            this.dataGridView_QueryScripts = new System.Windows.Forms.DataGridView();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AutoRun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_Dependencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_QueryScriptFont = new System.Windows.Forms.TextBox();
            this.textBox_ResultTableFont = new System.Windows.Forms.TextBox();
            this.textBox_TextResultsFont = new System.Windows.Forms.TextBox();
            this.label_QueryWindowFont = new System.Windows.Forms.Label();
            this.label_ResultTableFont = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl_Settings = new System.Windows.Forms.TabControl();
            this.tabPage_LibScripts = new System.Windows.Forms.TabPage();
            this.dataGridView_LibScripts = new System.Windows.Forms.DataGridView();
            this.Column_ScriptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ScriptPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_Variables = new System.Windows.Forms.TabPage();
            this.dataGridView_Variables = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_QueryScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QueryScripts)).BeginInit();
            this.tabPage_Settings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_LibScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LibScripts)).BeginInit();
            this.tabPage_Variables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Variables)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(1635, 40);
            this.menuStrip_Main.TabIndex = 1;
            this.menuStrip_Main.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl_Settings);
            this.splitContainer1.Size = new System.Drawing.Size(696, 870);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_QueryScripts);
            this.tabControl1.Controls.Add(this.tabPage_Settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_QueryScripts
            // 
            this.tabPage_QueryScripts.Controls.Add(this.dataGridView_QueryScripts);
            this.tabPage_QueryScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_QueryScripts.Name = "tabPage_QueryScripts";
            this.tabPage_QueryScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_QueryScripts.Size = new System.Drawing.Size(680, 371);
            this.tabPage_QueryScripts.TabIndex = 0;
            this.tabPage_QueryScripts.Text = "Query Scripts";
            this.tabPage_QueryScripts.UseVisualStyleBackColor = true;
            // 
            // dataGridView_QueryScripts
            // 
            this.dataGridView_QueryScripts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_QueryScripts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_QueryScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_QueryScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Name,
            this.Column_AutoRun,
            this.Column_Dependencies,
            this.Column_OldName});
            this.dataGridView_QueryScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_QueryScripts.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_QueryScripts.MultiSelect = false;
            this.dataGridView_QueryScripts.Name = "dataGridView_QueryScripts";
            this.dataGridView_QueryScripts.RowHeadersWidth = 30;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_QueryScripts.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_QueryScripts.RowTemplate.Height = 33;
            this.dataGridView_QueryScripts.Size = new System.Drawing.Size(674, 365);
            this.dataGridView_QueryScripts.TabIndex = 0;
            this.dataGridView_QueryScripts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_QueryScripts_CellEndEdit);
            this.dataGridView_QueryScripts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_QueryScripts_RowsRemoved);
            this.dataGridView_QueryScripts.Click += new System.EventHandler(this.dataGridView_QueryScripts_Click);
            this.dataGridView_QueryScripts.Leave += new System.EventHandler(this.dataGridView_QueryScripts_Leave);
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.MinimumWidth = 10;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 113;
            // 
            // Column_AutoRun
            // 
            this.Column_AutoRun.HeaderText = "AutoRun ";
            this.Column_AutoRun.MinimumWidth = 10;
            this.Column_AutoRun.Name = "Column_AutoRun";
            this.Column_AutoRun.Width = 107;
            // 
            // Column_Dependencies
            // 
            this.Column_Dependencies.HeaderText = "Dependencies";
            this.Column_Dependencies.MinimumWidth = 10;
            this.Column_Dependencies.Name = "Column_Dependencies";
            this.Column_Dependencies.Width = 195;
            // 
            // Column_OldName
            // 
            this.Column_OldName.HeaderText = "OldName";
            this.Column_OldName.MinimumWidth = 10;
            this.Column_OldName.Name = "Column_OldName";
            this.Column_OldName.ReadOnly = true;
            this.Column_OldName.Visible = false;
            this.Column_OldName.Width = 146;
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_Settings.Location = new System.Drawing.Point(8, 39);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(680, 371);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_QueryScriptFont, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ResultTableFont, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_TextResultsFont, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_QueryWindowFont, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ResultTableFont, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 365);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_QueryScriptFont
            // 
            this.textBox_QueryScriptFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_QueryScriptFont.Location = new System.Drawing.Point(227, 3);
            this.textBox_QueryScriptFont.Name = "textBox_QueryScriptFont";
            this.textBox_QueryScriptFont.ReadOnly = true;
            this.textBox_QueryScriptFont.Size = new System.Drawing.Size(444, 31);
            this.textBox_QueryScriptFont.TabIndex = 0;
            this.textBox_QueryScriptFont.DoubleClick += new System.EventHandler(this.textBox_QueryScriptFont_DoubleClick);
            // 
            // textBox_ResultTableFont
            // 
            this.textBox_ResultTableFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ResultTableFont.Location = new System.Drawing.Point(227, 43);
            this.textBox_ResultTableFont.Name = "textBox_ResultTableFont";
            this.textBox_ResultTableFont.ReadOnly = true;
            this.textBox_ResultTableFont.Size = new System.Drawing.Size(444, 31);
            this.textBox_ResultTableFont.TabIndex = 1;
            this.textBox_ResultTableFont.DoubleClick += new System.EventHandler(this.textBox_ResultTableFont_DoubleClick);
            // 
            // textBox_TextResultsFont
            // 
            this.textBox_TextResultsFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_TextResultsFont.Location = new System.Drawing.Point(227, 83);
            this.textBox_TextResultsFont.Name = "textBox_TextResultsFont";
            this.textBox_TextResultsFont.ReadOnly = true;
            this.textBox_TextResultsFont.Size = new System.Drawing.Size(444, 31);
            this.textBox_TextResultsFont.TabIndex = 2;
            this.textBox_TextResultsFont.DoubleClick += new System.EventHandler(this.textBox_TextResultsFont_DoubleClick);
            // 
            // label_QueryWindowFont
            // 
            this.label_QueryWindowFont.AutoSize = true;
            this.label_QueryWindowFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_QueryWindowFont.Location = new System.Drawing.Point(3, 0);
            this.label_QueryWindowFont.Name = "label_QueryWindowFont";
            this.label_QueryWindowFont.Size = new System.Drawing.Size(218, 40);
            this.label_QueryWindowFont.TabIndex = 4;
            this.label_QueryWindowFont.Text = "Query Window Font";
            this.label_QueryWindowFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ResultTableFont
            // 
            this.label_ResultTableFont.AutoSize = true;
            this.label_ResultTableFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ResultTableFont.Location = new System.Drawing.Point(3, 40);
            this.label_ResultTableFont.Name = "label_ResultTableFont";
            this.label_ResultTableFont.Size = new System.Drawing.Size(218, 40);
            this.label_ResultTableFont.TabIndex = 5;
            this.label_ResultTableFont.Text = "Table Results Font";
            this.label_ResultTableFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Text Results Font";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tabPage_LibScripts);
            this.tabControl_Settings.Controls.Add(this.tabPage_Variables);
            this.tabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Settings.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(696, 448);
            this.tabControl_Settings.TabIndex = 1;
            // 
            // tabPage_LibScripts
            // 
            this.tabPage_LibScripts.Controls.Add(this.dataGridView_LibScripts);
            this.tabPage_LibScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_LibScripts.Name = "tabPage_LibScripts";
            this.tabPage_LibScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LibScripts.Size = new System.Drawing.Size(680, 401);
            this.tabPage_LibScripts.TabIndex = 0;
            this.tabPage_LibScripts.Text = "Lib scripts";
            this.tabPage_LibScripts.UseVisualStyleBackColor = true;
            // 
            // dataGridView_LibScripts
            // 
            this.dataGridView_LibScripts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_LibScripts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_LibScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LibScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ScriptName,
            this.Column_ScriptPath});
            this.dataGridView_LibScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LibScripts.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_LibScripts.Name = "dataGridView_LibScripts";
            this.dataGridView_LibScripts.RowHeadersWidth = 40;
            this.dataGridView_LibScripts.RowTemplate.Height = 33;
            this.dataGridView_LibScripts.Size = new System.Drawing.Size(674, 395);
            this.dataGridView_LibScripts.TabIndex = 0;
            this.dataGridView_LibScripts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_LibScripts_CellClick);
            this.dataGridView_LibScripts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_LibScripts_CellDoubleClick);
            this.dataGridView_LibScripts.Leave += new System.EventHandler(this.dataGridView_LibScripts_Leave);
            // 
            // Column_ScriptName
            // 
            this.Column_ScriptName.HeaderText = "Name";
            this.Column_ScriptName.MinimumWidth = 10;
            this.Column_ScriptName.Name = "Column_ScriptName";
            this.Column_ScriptName.Width = 113;
            // 
            // Column_ScriptPath
            // 
            this.Column_ScriptPath.HeaderText = "Path";
            this.Column_ScriptPath.MinimumWidth = 10;
            this.Column_ScriptPath.Name = "Column_ScriptPath";
            this.Column_ScriptPath.Width = 101;
            // 
            // tabPage_Variables
            // 
            this.tabPage_Variables.Controls.Add(this.dataGridView_Variables);
            this.tabPage_Variables.Location = new System.Drawing.Point(8, 39);
            this.tabPage_Variables.Name = "tabPage_Variables";
            this.tabPage_Variables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Variables.Size = new System.Drawing.Size(680, 401);
            this.tabPage_Variables.TabIndex = 1;
            this.tabPage_Variables.Text = "Variables";
            this.tabPage_Variables.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Variables
            // 
            this.dataGridView_Variables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Variables.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_Variables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Variables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Variables.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Variables.Name = "dataGridView_Variables";
            this.dataGridView_Variables.RowHeadersWidth = 40;
            this.dataGridView_Variables.RowTemplate.Height = 33;
            this.dataGridView_Variables.Size = new System.Drawing.Size(674, 395);
            this.dataGridView_Variables.TabIndex = 1;
            this.dataGridView_Variables.Leave += new System.EventHandler(this.dataGridView_Variables_Leave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 113;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 112;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(696, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 870);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // MainAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 910);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_Main;
            this.Name = "MainAppWindow";
            this.Text = "Powershell Drilldown Tool";
            this.Load += new System.EventHandler(this.MainAppWindow_Load);
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_QueryScripts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QueryScripts)).EndInit();
            this.tabPage_Settings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl_Settings.ResumeLayout(false);
            this.tabPage_LibScripts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LibScripts)).EndInit();
            this.tabPage_Variables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Variables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_QueryScripts;
        private System.Windows.Forms.DataGridView dataGridView_QueryScripts;
        private System.Windows.Forms.TabControl tabControl_Settings;
        private System.Windows.Forms.TabPage tabPage_LibScripts;
        private System.Windows.Forms.TabPage tabPage_Variables;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dataGridView_LibScripts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ScriptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ScriptPath;
        private System.Windows.Forms.DataGridView dataGridView_Variables;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_AutoRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Dependencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OldName;
        private System.Windows.Forms.TabPage tabPage_Settings;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_QueryScriptFont;
        private System.Windows.Forms.TextBox textBox_ResultTableFont;
        private System.Windows.Forms.TextBox textBox_TextResultsFont;
        private System.Windows.Forms.Label label_QueryWindowFont;
        private System.Windows.Forms.Label label_ResultTableFont;
        private System.Windows.Forms.Label label1;
    }
}

