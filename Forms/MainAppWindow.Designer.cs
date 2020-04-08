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
            this.Column_OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_MasterLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_MasterTop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SlaveBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SlaveRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Fanned = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ResultsMaximized = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ResultsSplit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ResultsMinimized = new System.Windows.Forms.ToolStripButton();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.dataGridView_Settings = new System.Windows.Forms.DataGridView();
            this.Column_SettingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SettingValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl_Settings = new System.Windows.Forms.TabControl();
            this.tabPage_DependencyTree = new System.Windows.Forms.TabPage();
            this.treeView_DependencyTree = new System.Windows.Forms.TreeView();
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
            this.toolStrip1.SuspendLayout();
            this.tabPage_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settings)).BeginInit();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_DependencyTree.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(561, 870);
            this.splitContainer1.SplitterDistance = 414;
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
            this.tabControl1.Size = new System.Drawing.Size(561, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_QueryScripts
            // 
            this.tabPage_QueryScripts.Controls.Add(this.dataGridView_QueryScripts);
            this.tabPage_QueryScripts.Controls.Add(this.toolStrip1);
            this.tabPage_QueryScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_QueryScripts.Name = "tabPage_QueryScripts";
            this.tabPage_QueryScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_QueryScripts.Size = new System.Drawing.Size(545, 367);
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
            this.Column_OldName});
            this.dataGridView_QueryScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_QueryScripts.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_QueryScripts.MultiSelect = false;
            this.dataGridView_QueryScripts.Name = "dataGridView_QueryScripts";
            this.dataGridView_QueryScripts.RowHeadersWidth = 30;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_QueryScripts.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_QueryScripts.RowTemplate.Height = 33;
            this.dataGridView_QueryScripts.Size = new System.Drawing.Size(539, 323);
            this.dataGridView_QueryScripts.TabIndex = 0;
            this.dataGridView_QueryScripts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_QueryScripts_CellContentClick);
            this.dataGridView_QueryScripts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_QueryScripts_CellEndEdit);
            this.dataGridView_QueryScripts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_QueryScripts_CellValueChanged);
            this.dataGridView_QueryScripts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_QueryScripts_RowsRemoved);
            this.dataGridView_QueryScripts.Click += new System.EventHandler(this.dataGridView_QueryScripts_Click);
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
            // Column_OldName
            // 
            this.Column_OldName.HeaderText = "OldName";
            this.Column_OldName.MinimumWidth = 10;
            this.Column_OldName.Name = "Column_OldName";
            this.Column_OldName.ReadOnly = true;
            this.Column_OldName.Visible = false;
            this.Column_OldName.Width = 146;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton_MasterLeft,
            this.toolStripButton_MasterTop,
            this.toolStripButton_SlaveBottom,
            this.toolStripButton_SlaveRight,
            this.toolStripButton_Fanned,
            this.toolStripSeparator1,
            this.toolStripButton_ResultsMaximized,
            this.toolStripButton_ResultsSplit,
            this.toolStripButton_ResultsMinimized});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(539, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 32);
            this.toolStripLabel1.Text = "Layouts";
            // 
            // toolStripButton_MasterLeft
            // 
            this.toolStripButton_MasterLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_MasterLeft.Image = global::PSDrilldownTool.Properties.Resources.Layout_MasterLeft;
            this.toolStripButton_MasterLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_MasterLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_MasterLeft.Name = "toolStripButton_MasterLeft";
            this.toolStripButton_MasterLeft.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_MasterLeft.Text = "Master left";
            this.toolStripButton_MasterLeft.Click += new System.EventHandler(this.toolStripButton_MasterLeft_Click);
            // 
            // toolStripButton_MasterTop
            // 
            this.toolStripButton_MasterTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_MasterTop.Image = global::PSDrilldownTool.Properties.Resources.Layout_MasterTop;
            this.toolStripButton_MasterTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_MasterTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_MasterTop.Name = "toolStripButton_MasterTop";
            this.toolStripButton_MasterTop.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_MasterTop.Text = "Master top";
            this.toolStripButton_MasterTop.Click += new System.EventHandler(this.toolStripButton_MasterTop_Click);
            // 
            // toolStripButton_SlaveBottom
            // 
            this.toolStripButton_SlaveBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SlaveBottom.Image = global::PSDrilldownTool.Properties.Resources.Layout_SlaveBottom;
            this.toolStripButton_SlaveBottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_SlaveBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SlaveBottom.Name = "toolStripButton_SlaveBottom";
            this.toolStripButton_SlaveBottom.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_SlaveBottom.Text = "Slave bottom";
            this.toolStripButton_SlaveBottom.Click += new System.EventHandler(this.toolStripButton_SlaveBottom_Click);
            // 
            // toolStripButton_SlaveRight
            // 
            this.toolStripButton_SlaveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SlaveRight.Image = global::PSDrilldownTool.Properties.Resources.Layout_SlaveRight;
            this.toolStripButton_SlaveRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_SlaveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SlaveRight.Name = "toolStripButton_SlaveRight";
            this.toolStripButton_SlaveRight.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_SlaveRight.Text = "Slave right";
            this.toolStripButton_SlaveRight.Click += new System.EventHandler(this.toolStripButton_SlaveRight_Click);
            // 
            // toolStripButton_Fanned
            // 
            this.toolStripButton_Fanned.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Fanned.Image = global::PSDrilldownTool.Properties.Resources.Layout_Fanned;
            this.toolStripButton_Fanned.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Fanned.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Fanned.Name = "toolStripButton_Fanned";
            this.toolStripButton_Fanned.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_Fanned.Text = "Fanned";
            this.toolStripButton_Fanned.Click += new System.EventHandler(this.toolStripButton_Fanned_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton_ResultsMaximized
            // 
            this.toolStripButton_ResultsMaximized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsMaximized.Image = global::PSDrilldownTool.Properties.Resources.Results_Maximized;
            this.toolStripButton_ResultsMaximized.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsMaximized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsMaximized.Name = "toolStripButton_ResultsMaximized";
            this.toolStripButton_ResultsMaximized.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_ResultsMaximized.Text = "Results maximized";
            this.toolStripButton_ResultsMaximized.Click += new System.EventHandler(this.toolStripButton_ResultsMaximized_Click);
            // 
            // toolStripButton_ResultsSplit
            // 
            this.toolStripButton_ResultsSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsSplit.Image = global::PSDrilldownTool.Properties.Resources.Results_Half;
            this.toolStripButton_ResultsSplit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsSplit.Name = "toolStripButton_ResultsSplit";
            this.toolStripButton_ResultsSplit.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_ResultsSplit.Text = "Split query and results";
            this.toolStripButton_ResultsSplit.Click += new System.EventHandler(this.toolStripButton_ResultsSplit_Click);
            // 
            // toolStripButton_ResultsMinimized
            // 
            this.toolStripButton_ResultsMinimized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ResultsMinimized.Image = global::PSDrilldownTool.Properties.Resources.Results_Minimized;
            this.toolStripButton_ResultsMinimized.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ResultsMinimized.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ResultsMinimized.Name = "toolStripButton_ResultsMinimized";
            this.toolStripButton_ResultsMinimized.Size = new System.Drawing.Size(46, 32);
            this.toolStripButton_ResultsMinimized.Text = "Results minimized";
            this.toolStripButton_ResultsMinimized.Click += new System.EventHandler(this.toolStripButton_ResultsMinimized_Click);
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Controls.Add(this.dataGridView_Settings);
            this.tabPage_Settings.Location = new System.Drawing.Point(8, 39);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(545, 367);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Settings
            // 
            this.dataGridView_Settings.AllowUserToAddRows = false;
            this.dataGridView_Settings.AllowUserToDeleteRows = false;
            this.dataGridView_Settings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_Settings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_Settings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Settings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_SettingName,
            this.Column_SettingValue});
            this.dataGridView_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Settings.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Settings.Name = "dataGridView_Settings";
            this.dataGridView_Settings.RowHeadersWidth = 5;
            this.dataGridView_Settings.RowTemplate.Height = 33;
            this.dataGridView_Settings.Size = new System.Drawing.Size(539, 361);
            this.dataGridView_Settings.TabIndex = 0;
            this.dataGridView_Settings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Settings_CellDoubleClick);
            // 
            // Column_SettingName
            // 
            this.Column_SettingName.HeaderText = "Setting";
            this.Column_SettingName.MinimumWidth = 10;
            this.Column_SettingName.Name = "Column_SettingName";
            this.Column_SettingName.Width = 124;
            // 
            // Column_SettingValue
            // 
            this.Column_SettingValue.HeaderText = "Value";
            this.Column_SettingValue.MinimumWidth = 10;
            this.Column_SettingValue.Name = "Column_SettingValue";
            this.Column_SettingValue.Width = 112;
            // 
            // tabControl_Settings
            // 
            this.tabControl_Settings.Controls.Add(this.tabPage_DependencyTree);
            this.tabControl_Settings.Controls.Add(this.tabPage_LibScripts);
            this.tabControl_Settings.Controls.Add(this.tabPage_Variables);
            this.tabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Settings.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(561, 452);
            this.tabControl_Settings.TabIndex = 1;
            // 
            // tabPage_DependencyTree
            // 
            this.tabPage_DependencyTree.Controls.Add(this.treeView_DependencyTree);
            this.tabPage_DependencyTree.Location = new System.Drawing.Point(8, 39);
            this.tabPage_DependencyTree.Name = "tabPage_DependencyTree";
            this.tabPage_DependencyTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DependencyTree.Size = new System.Drawing.Size(545, 405);
            this.tabPage_DependencyTree.TabIndex = 2;
            this.tabPage_DependencyTree.Text = "DependencyTree";
            this.tabPage_DependencyTree.UseVisualStyleBackColor = true;
            // 
            // treeView_DependencyTree
            // 
            this.treeView_DependencyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_DependencyTree.Location = new System.Drawing.Point(3, 3);
            this.treeView_DependencyTree.Name = "treeView_DependencyTree";
            this.treeView_DependencyTree.Size = new System.Drawing.Size(539, 399);
            this.treeView_DependencyTree.TabIndex = 0;
            this.treeView_DependencyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_DependencyTree_AfterSelect);
            // 
            // tabPage_LibScripts
            // 
            this.tabPage_LibScripts.Controls.Add(this.dataGridView_LibScripts);
            this.tabPage_LibScripts.Location = new System.Drawing.Point(8, 39);
            this.tabPage_LibScripts.Name = "tabPage_LibScripts";
            this.tabPage_LibScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LibScripts.Size = new System.Drawing.Size(545, 405);
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
            this.dataGridView_LibScripts.Size = new System.Drawing.Size(539, 399);
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
            this.tabPage_Variables.Size = new System.Drawing.Size(545, 405);
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
            this.dataGridView_Variables.Size = new System.Drawing.Size(539, 399);
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
            this.splitter1.Location = new System.Drawing.Point(561, 40);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainAppWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainAppWindow_Load);
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_QueryScripts.ResumeLayout(false);
            this.tabPage_QueryScripts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_QueryScripts)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage_Settings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Settings)).EndInit();
            this.tabControl_Settings.ResumeLayout(false);
            this.tabPage_DependencyTree.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage_Settings;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_MasterLeft;
        private System.Windows.Forms.ToolStripButton toolStripButton_MasterTop;
        private System.Windows.Forms.ToolStripButton toolStripButton_SlaveBottom;
        private System.Windows.Forms.ToolStripButton toolStripButton_SlaveRight;
        private System.Windows.Forms.ToolStripButton toolStripButton_Fanned;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsSplit;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsMaximized;
        private System.Windows.Forms.ToolStripButton toolStripButton_ResultsMinimized;
        private System.Windows.Forms.TabPage tabPage_DependencyTree;
        private System.Windows.Forms.TreeView treeView_DependencyTree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_AutoRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OldName;
        private System.Windows.Forms.DataGridView dataGridView_Settings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SettingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SettingValue;
    }
}

