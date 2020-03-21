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
            this.menuStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_QueryScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QueryScripts)).BeginInit();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_LibScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LibScripts)).BeginInit();
            this.tabPage_Variables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Variables)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
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
            this.splitContainer1.SplitterDistance = 419;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_QueryScripts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 419);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_QueryScripts
            // 
            this.tabPage_QueryScripts.Controls.Add(this.dataGridView_QueryScripts);
            this.tabPage_QueryScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_QueryScripts.Name = "tabPage_QueryScripts";
            this.tabPage_QueryScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_QueryScripts.Size = new System.Drawing.Size(680, 372);
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
            this.dataGridView_QueryScripts.Size = new System.Drawing.Size(674, 366);
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
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tabPage_LibScripts);
            this.tabControl_Settings.Controls.Add(this.tabPage_Variables);
            this.tabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Settings.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(696, 447);
            this.tabControl_Settings.TabIndex = 1;
            // 
            // tabPage_LibScripts
            // 
            this.tabPage_LibScripts.Controls.Add(this.dataGridView_LibScripts);
            this.tabPage_LibScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_LibScripts.Name = "tabPage_LibScripts";
            this.tabPage_LibScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LibScripts.Size = new System.Drawing.Size(680, 400);
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
            this.dataGridView_LibScripts.Size = new System.Drawing.Size(674, 394);
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
            this.tabPage_Variables.Size = new System.Drawing.Size(680, 400);
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
            this.dataGridView_Variables.Size = new System.Drawing.Size(674, 394);
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
    }
}

