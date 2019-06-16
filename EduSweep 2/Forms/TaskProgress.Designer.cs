namespace EduSweep_2.Forms
{
    partial class TaskProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskProgress));
            this.tabControlTask = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.pictureBoxLog = new System.Windows.Forms.PictureBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelLogMinor = new System.Windows.Forms.Label();
            this.labelLogMajor = new System.Windows.Forms.Label();
            this.tabPageTargets = new System.Windows.Forms.TabPage();
            this.listViewLocations = new BrightIdeasSoftware.ObjectListView();
            this.olvLocationColumnPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLocationColumnRecurse = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pictureBoxLocations = new System.Windows.Forms.PictureBox();
            this.labelTargetsMinor = new System.Windows.Forms.Label();
            this.labelTargetsMajor = new System.Windows.Forms.Label();
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.listViewResults = new BrightIdeasSoftware.ObjectListView();
            this.olvResultsColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvResultsColumnExtension = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvResultsColumnSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvResultsColumnLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonShowFile = new System.Windows.Forms.Button();
            this.pictureBoxResults = new System.Windows.Forms.PictureBox();
            this.buttonResultsDetails = new System.Windows.Forms.Button();
            this.buttonResultsDelete = new System.Windows.Forms.Button();
            this.buttonResultsQuarantine = new System.Windows.Forms.Button();
            this.labelResultsMinor = new System.Windows.Forms.Label();
            this.labelResultsMajor = new System.Windows.Forms.Label();
            this.contextMenuStripResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorkerInitialize = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerScan = new System.ComponentModel.BackgroundWorker();
            this.timerLocations = new System.Windows.Forms.Timer(this.components);
            this.timerResults = new System.Windows.Forms.Timer(this.components);
            this.tabControlTask.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLog)).BeginInit();
            this.tabPageTargets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocations)).BeginInit();
            this.tabPageResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResults)).BeginInit();
            this.contextMenuStripResults.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTask
            // 
            this.tabControlTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTask.Controls.Add(this.tabPageLog);
            this.tabControlTask.Controls.Add(this.tabPageTargets);
            this.tabControlTask.Controls.Add(this.tabPageResults);
            this.tabControlTask.Location = new System.Drawing.Point(0, 18);
            this.tabControlTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlTask.Name = "tabControlTask";
            this.tabControlTask.SelectedIndex = 0;
            this.tabControlTask.Size = new System.Drawing.Size(1059, 606);
            this.tabControlTask.TabIndex = 1;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Controls.Add(this.buttonPause);
            this.tabPageLog.Controls.Add(this.pictureBoxLog);
            this.tabPageLog.Controls.Add(this.buttonStop);
            this.tabPageLog.Controls.Add(this.labelLogMinor);
            this.tabPageLog.Controls.Add(this.labelLogMajor);
            this.tabPageLog.Location = new System.Drawing.Point(4, 29);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageLog.Size = new System.Drawing.Size(1051, 573);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Task Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(20, 114);
            this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(1009, 395);
            this.richTextBoxLog.TabIndex = 29;
            this.richTextBoxLog.Text = "";
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(724, 520);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(148, 35);
            this.buttonPause.TabIndex = 13;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPauseTask_Click);
            // 
            // pictureBoxLog
            // 
            this.pictureBoxLog.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLog.Image")));
            this.pictureBoxLog.Location = new System.Drawing.Point(20, 31);
            this.pictureBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxLog.Name = "pictureBoxLog";
            this.pictureBoxLog.Size = new System.Drawing.Size(72, 74);
            this.pictureBoxLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLog.TabIndex = 28;
            this.pictureBoxLog.TabStop = false;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(882, 520);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(148, 35);
            this.buttonStop.TabIndex = 14;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStopTask_Click);
            // 
            // labelLogMinor
            // 
            this.labelLogMinor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogMinor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogMinor.Location = new System.Drawing.Point(100, 55);
            this.labelLogMinor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogMinor.Name = "labelLogMinor";
            this.labelLogMinor.Size = new System.Drawing.Size(902, 49);
            this.labelLogMinor.TabIndex = 17;
            this.labelLogMinor.Text = resources.GetString("labelLogMinor.Text");
            // 
            // labelLogMajor
            // 
            this.labelLogMajor.AutoSize = true;
            this.labelLogMajor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelLogMajor.Location = new System.Drawing.Point(99, 23);
            this.labelLogMajor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogMajor.Name = "labelLogMajor";
            this.labelLogMajor.Size = new System.Drawing.Size(105, 32);
            this.labelLogMajor.TabIndex = 16;
            this.labelLogMajor.Text = "Task Log";
            // 
            // tabPageTargets
            // 
            this.tabPageTargets.Controls.Add(this.listViewLocations);
            this.tabPageTargets.Controls.Add(this.pictureBoxLocations);
            this.tabPageTargets.Controls.Add(this.labelTargetsMinor);
            this.tabPageTargets.Controls.Add(this.labelTargetsMajor);
            this.tabPageTargets.Location = new System.Drawing.Point(4, 29);
            this.tabPageTargets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageTargets.Name = "tabPageTargets";
            this.tabPageTargets.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageTargets.Size = new System.Drawing.Size(1051, 573);
            this.tabPageTargets.TabIndex = 1;
            this.tabPageTargets.Text = "Target Locations";
            this.tabPageTargets.UseVisualStyleBackColor = true;
            // 
            // listViewLocations
            // 
            this.listViewLocations.AllColumns.Add(this.olvLocationColumnPath);
            this.listViewLocations.AllColumns.Add(this.olvLocationColumnRecurse);
            this.listViewLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLocations.CellEditUseWholeCell = false;
            this.listViewLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvLocationColumnPath,
            this.olvLocationColumnRecurse});
            this.listViewLocations.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewLocations.FullRowSelect = true;
            this.listViewLocations.HideSelection = false;
            this.listViewLocations.Location = new System.Drawing.Point(20, 114);
            this.listViewLocations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewLocations.Name = "listViewLocations";
            this.listViewLocations.Size = new System.Drawing.Size(1016, 441);
            this.listViewLocations.TabIndex = 30;
            this.listViewLocations.UseCompatibleStateImageBehavior = false;
            this.listViewLocations.UseExplorerTheme = true;
            this.listViewLocations.View = System.Windows.Forms.View.Details;
            // 
            // olvLocationColumnPath
            // 
            this.olvLocationColumnPath.AspectName = "Path";
            this.olvLocationColumnPath.FillsFreeSpace = true;
            this.olvLocationColumnPath.MinimumWidth = 50;
            this.olvLocationColumnPath.Text = "Path";
            this.olvLocationColumnPath.Width = 260;
            // 
            // olvLocationColumnRecurse
            // 
            this.olvLocationColumnRecurse.AspectName = "Recursive";
            this.olvLocationColumnRecurse.FillsFreeSpace = true;
            this.olvLocationColumnRecurse.MaximumWidth = 100;
            this.olvLocationColumnRecurse.MinimumWidth = 50;
            this.olvLocationColumnRecurse.Text = "Recursive";
            this.olvLocationColumnRecurse.Width = 69;
            // 
            // pictureBoxLocations
            // 
            this.pictureBoxLocations.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLocations.Image")));
            this.pictureBoxLocations.Location = new System.Drawing.Point(20, 31);
            this.pictureBoxLocations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxLocations.Name = "pictureBoxLocations";
            this.pictureBoxLocations.Size = new System.Drawing.Size(72, 74);
            this.pictureBoxLocations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLocations.TabIndex = 29;
            this.pictureBoxLocations.TabStop = false;
            // 
            // labelTargetsMinor
            // 
            this.labelTargetsMinor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTargetsMinor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTargetsMinor.Location = new System.Drawing.Point(100, 55);
            this.labelTargetsMinor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTargetsMinor.Name = "labelTargetsMinor";
            this.labelTargetsMinor.Size = new System.Drawing.Size(930, 49);
            this.labelTargetsMinor.TabIndex = 19;
            this.labelTargetsMinor.Text = resources.GetString("labelTargetsMinor.Text");
            // 
            // labelTargetsMajor
            // 
            this.labelTargetsMajor.AutoSize = true;
            this.labelTargetsMajor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTargetsMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelTargetsMajor.Location = new System.Drawing.Point(99, 23);
            this.labelTargetsMajor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTargetsMajor.Name = "labelTargetsMajor";
            this.labelTargetsMajor.Size = new System.Drawing.Size(187, 32);
            this.labelTargetsMajor.TabIndex = 18;
            this.labelTargetsMajor.Text = "Target Locations";
            // 
            // tabPageResults
            // 
            this.tabPageResults.Controls.Add(this.listViewResults);
            this.tabPageResults.Controls.Add(this.buttonShowFile);
            this.tabPageResults.Controls.Add(this.pictureBoxResults);
            this.tabPageResults.Controls.Add(this.buttonResultsDetails);
            this.tabPageResults.Controls.Add(this.buttonResultsDelete);
            this.tabPageResults.Controls.Add(this.buttonResultsQuarantine);
            this.tabPageResults.Controls.Add(this.labelResultsMinor);
            this.tabPageResults.Controls.Add(this.labelResultsMajor);
            this.tabPageResults.Location = new System.Drawing.Point(4, 29);
            this.tabPageResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Size = new System.Drawing.Size(1051, 573);
            this.tabPageResults.TabIndex = 2;
            this.tabPageResults.Text = "Scan Results";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // listViewResults
            // 
            this.listViewResults.AllColumns.Add(this.olvResultsColumnName);
            this.listViewResults.AllColumns.Add(this.olvResultsColumnExtension);
            this.listViewResults.AllColumns.Add(this.olvResultsColumnSize);
            this.listViewResults.AllColumns.Add(this.olvResultsColumnLocation);
            this.listViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResults.CellEditUseWholeCell = false;
            this.listViewResults.CheckBoxes = true;
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvResultsColumnName,
            this.olvResultsColumnExtension,
            this.olvResultsColumnSize,
            this.olvResultsColumnLocation});
            this.listViewResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewResults.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.HasCollapsibleGroups = false;
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(20, 114);
            this.listViewResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(1009, 382);
            this.listViewResults.TabIndex = 31;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.UseExplorerTheme = true;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listViewResults_CellRightClick);
            this.listViewResults.HeaderCheckBoxChanging += new System.EventHandler<BrightIdeasSoftware.HeaderCheckBoxChangingEventArgs>(this.listViewResults_HeaderCheckBoxChanging);
            this.listViewResults.GroupTaskClicked += new System.EventHandler<BrightIdeasSoftware.GroupTaskClickedEventArgs>(this.listViewResults_GroupTaskClicked);
            this.listViewResults.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListViewResults_ItemChecked);
            // 
            // olvResultsColumnName
            // 
            this.olvResultsColumnName.AspectName = "Name";
            this.olvResultsColumnName.FillsFreeSpace = true;
            this.olvResultsColumnName.HeaderCheckBox = true;
            this.olvResultsColumnName.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvResultsColumnName.MinimumWidth = 200;
            this.olvResultsColumnName.Text = "File Name";
            this.olvResultsColumnName.Width = 200;
            // 
            // olvResultsColumnExtension
            // 
            this.olvResultsColumnExtension.AspectName = "Extension.Name";
            this.olvResultsColumnExtension.FillsFreeSpace = true;
            this.olvResultsColumnExtension.MaximumWidth = 125;
            this.olvResultsColumnExtension.MinimumWidth = 50;
            this.olvResultsColumnExtension.Text = "Extension";
            this.olvResultsColumnExtension.Width = 70;
            // 
            // olvResultsColumnSize
            // 
            this.olvResultsColumnSize.AspectName = "Length";
            this.olvResultsColumnSize.FillsFreeSpace = true;
            this.olvResultsColumnSize.MaximumWidth = 125;
            this.olvResultsColumnSize.MinimumWidth = 50;
            this.olvResultsColumnSize.Text = "Size";
            this.olvResultsColumnSize.Width = 50;
            // 
            // olvResultsColumnLocation
            // 
            this.olvResultsColumnLocation.AspectName = "ParentDirectoryPath";
            this.olvResultsColumnLocation.FillsFreeSpace = true;
            this.olvResultsColumnLocation.MinimumWidth = 200;
            this.olvResultsColumnLocation.Text = "Location";
            this.olvResultsColumnLocation.Width = 288;
            // 
            // buttonShowFile
            // 
            this.buttonShowFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowFile.Enabled = false;
            this.buttonShowFile.Location = new System.Drawing.Point(334, 508);
            this.buttonShowFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowFile.Name = "buttonShowFile";
            this.buttonShowFile.Size = new System.Drawing.Size(148, 35);
            this.buttonShowFile.TabIndex = 7;
            this.buttonShowFile.Text = "Show File";
            this.buttonShowFile.UseVisualStyleBackColor = true;
            this.buttonShowFile.Click += new System.EventHandler(this.buttonShowFile_Click);
            // 
            // pictureBoxResults
            // 
            this.pictureBoxResults.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxResults.Image")));
            this.pictureBoxResults.Location = new System.Drawing.Point(20, 31);
            this.pictureBoxResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxResults.Name = "pictureBoxResults";
            this.pictureBoxResults.Size = new System.Drawing.Size(72, 74);
            this.pictureBoxResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResults.TabIndex = 30;
            this.pictureBoxResults.TabStop = false;
            // 
            // buttonResultsDetails
            // 
            this.buttonResultsDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResultsDetails.Enabled = false;
            this.buttonResultsDetails.Location = new System.Drawing.Point(882, 508);
            this.buttonResultsDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResultsDetails.Name = "buttonResultsDetails";
            this.buttonResultsDetails.Size = new System.Drawing.Size(148, 35);
            this.buttonResultsDetails.TabIndex = 8;
            this.buttonResultsDetails.Text = "Inspect";
            this.buttonResultsDetails.UseVisualStyleBackColor = true;
            this.buttonResultsDetails.Click += new System.EventHandler(this.buttonResultsDetails_Click);
            // 
            // buttonResultsDelete
            // 
            this.buttonResultsDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResultsDelete.Enabled = false;
            this.buttonResultsDelete.Location = new System.Drawing.Point(177, 508);
            this.buttonResultsDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResultsDelete.Name = "buttonResultsDelete";
            this.buttonResultsDelete.Size = new System.Drawing.Size(148, 35);
            this.buttonResultsDelete.TabIndex = 6;
            this.buttonResultsDelete.Text = "Delete";
            this.buttonResultsDelete.UseVisualStyleBackColor = true;
            this.buttonResultsDelete.Click += new System.EventHandler(this.buttonResultsDelete_Click);
            // 
            // buttonResultsQuarantine
            // 
            this.buttonResultsQuarantine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResultsQuarantine.Enabled = false;
            this.buttonResultsQuarantine.Location = new System.Drawing.Point(20, 508);
            this.buttonResultsQuarantine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonResultsQuarantine.Name = "buttonResultsQuarantine";
            this.buttonResultsQuarantine.Size = new System.Drawing.Size(148, 35);
            this.buttonResultsQuarantine.TabIndex = 5;
            this.buttonResultsQuarantine.Text = "Quarantine";
            this.buttonResultsQuarantine.UseVisualStyleBackColor = true;
            this.buttonResultsQuarantine.Click += new System.EventHandler(this.buttonResultsQuarantine_Click);
            // 
            // labelResultsMinor
            // 
            this.labelResultsMinor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResultsMinor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultsMinor.Location = new System.Drawing.Point(100, 55);
            this.labelResultsMinor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultsMinor.Name = "labelResultsMinor";
            this.labelResultsMinor.Size = new System.Drawing.Size(930, 54);
            this.labelResultsMinor.TabIndex = 19;
            this.labelResultsMinor.Text = resources.GetString("labelResultsMinor.Text");
            // 
            // labelResultsMajor
            // 
            this.labelResultsMajor.AutoSize = true;
            this.labelResultsMajor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultsMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelResultsMajor.Location = new System.Drawing.Point(99, 23);
            this.labelResultsMajor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResultsMajor.Name = "labelResultsMajor";
            this.labelResultsMajor.Size = new System.Drawing.Size(146, 32);
            this.labelResultsMajor.TabIndex = 18;
            this.labelResultsMajor.Text = "Scan Results";
            // 
            // contextMenuStripResults
            // 
            this.contextMenuStripResults.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSelect,
            this.toolStripSeparator,
            this.toolStripMenuItemClearSelection});
            this.contextMenuStripResults.Name = "contextMenuStripResults";
            this.contextMenuStripResults.Size = new System.Drawing.Size(200, 74);
            // 
            // toolStripMenuItemSelect
            // 
            this.toolStripMenuItemSelect.Name = "toolStripMenuItemSelect";
            this.toolStripMenuItemSelect.Size = new System.Drawing.Size(199, 32);
            this.toolStripMenuItemSelect.Text = "Select All";
            this.toolStripMenuItemSelect.Click += new System.EventHandler(this.toolStripMenuItemSelect_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuItemClearSelection
            // 
            this.toolStripMenuItemClearSelection.Name = "toolStripMenuItemClearSelection";
            this.toolStripMenuItemClearSelection.Size = new System.Drawing.Size(199, 32);
            this.toolStripMenuItemClearSelection.Text = "Clear Selection";
            this.toolStripMenuItemClearSelection.Click += new System.EventHandler(this.toolStripMenuItemClearSelection_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslabelStatus,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 631);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1064, 32);
            this.statusStrip.TabIndex = 15;
            // 
            // toolStripStatuslabelStatus
            // 
            this.toolStripStatuslabelStatus.Name = "toolStripStatuslabelStatus";
            this.toolStripStatuslabelStatus.Size = new System.Drawing.Size(887, 25);
            this.toolStripStatuslabelStatus.Spring = true;
            this.toolStripStatuslabelStatus.Text = "Status Text";
            this.toolStripStatuslabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 24);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // backgroundWorkerInitialize
            // 
            this.backgroundWorkerInitialize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInitialize_DoWork);
            this.backgroundWorkerInitialize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInitialize_RunWorkerCompleted);
            // 
            // backgroundWorkerScan
            // 
            this.backgroundWorkerScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerScan_DoWork);
            // 
            // timerLocations
            // 
            this.timerLocations.Interval = 250;
            this.timerLocations.Tick += new System.EventHandler(this.timerLocations_Tick);
            // 
            // timerResults
            // 
            this.timerResults.Interval = 1000;
            this.timerResults.Tick += new System.EventHandler(this.timerResults_Tick);
            // 
            // TaskProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1064, 663);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControlTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1076, 693);
            this.Name = "TaskProgress";
            this.Text = "Task Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskProgress_FormClosing);
            this.Load += new System.EventHandler(this.TaskProgress_Load);
            this.tabControlTask.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLog)).EndInit();
            this.tabPageTargets.ResumeLayout(false);
            this.tabPageTargets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocations)).EndInit();
            this.tabPageResults.ResumeLayout(false);
            this.tabPageResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResults)).EndInit();
            this.contextMenuStripResults.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTask;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TabPage tabPageTargets;
        private System.Windows.Forms.TabPage tabPageResults;
        private System.Windows.Forms.Label labelLogMajor;
        private System.Windows.Forms.Label labelLogMinor;
        private System.Windows.Forms.Label labelTargetsMinor;
        private System.Windows.Forms.Label labelTargetsMajor;
        private System.Windows.Forms.Label labelResultsMinor;
        private System.Windows.Forms.Label labelResultsMajor;
        private System.Windows.Forms.Button buttonResultsDelete;
        private System.Windows.Forms.Button buttonResultsQuarantine;
        private System.Windows.Forms.Button buttonResultsDetails;
        private System.Windows.Forms.PictureBox pictureBoxLog;
        private System.Windows.Forms.PictureBox pictureBoxLocations;
        private System.Windows.Forms.PictureBox pictureBoxResults;
        private System.Windows.Forms.Button buttonShowFile;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslabelStatus;
        private BrightIdeasSoftware.ObjectListView listViewLocations;
        private BrightIdeasSoftware.OLVColumn olvLocationColumnPath;
        private BrightIdeasSoftware.OLVColumn olvLocationColumnRecurse;
        private BrightIdeasSoftware.ObjectListView listViewResults;
        private BrightIdeasSoftware.OLVColumn olvResultsColumnName;
        private BrightIdeasSoftware.OLVColumn olvResultsColumnExtension;
        private BrightIdeasSoftware.OLVColumn olvResultsColumnSize;
        private BrightIdeasSoftware.OLVColumn olvResultsColumnLocation;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInitialize;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScan;
        private System.Windows.Forms.Timer timerLocations;
        private System.Windows.Forms.Timer timerResults;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripResults;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearSelection;
    }
}