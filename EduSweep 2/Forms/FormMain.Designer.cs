using EduEngine.Scanner;

namespace EduSweep_2.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBoxTasks = new System.Windows.Forms.GroupBox();
            this.listViewTasks = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCreator = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCreateDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLastRunDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripScanTasks = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStartTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNewTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClone = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteTask = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDonate = new System.Windows.Forms.ToolStripButton();
            this.statusStripWorkingDirectory = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWorkDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarantineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarantineBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileInspectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchSignatureStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHomepage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxHeader = new System.Windows.Forms.PictureBox();
            this.groupBoxTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewTasks)).BeginInit();
            this.toolStripScanTasks.SuspendLayout();
            this.statusStripWorkingDirectory.SuspendLayout();
            this.menuStripTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(105, 22);
            this.toolStripButton4.Text = "toolStripButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(105, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // groupBoxTasks
            // 
            this.groupBoxTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTasks.Controls.Add(this.listViewTasks);
            this.groupBoxTasks.Controls.Add(this.toolStripScanTasks);
            this.groupBoxTasks.Location = new System.Drawing.Point(18, 108);
            this.groupBoxTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTasks.Name = "groupBoxTasks";
            this.groupBoxTasks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTasks.Size = new System.Drawing.Size(1020, 312);
            this.groupBoxTasks.TabIndex = 2;
            this.groupBoxTasks.TabStop = false;
            this.groupBoxTasks.Text = "Scan Tasks";
            // 
            // listViewTasks
            // 
            this.listViewTasks.AllColumns.Add(this.olvColumnName);
            this.listViewTasks.AllColumns.Add(this.olvColumnStatus);
            this.listViewTasks.AllColumns.Add(this.olvColumnCreator);
            this.listViewTasks.AllColumns.Add(this.olvColumnCreateDate);
            this.listViewTasks.AllColumns.Add(this.olvColumnLastRunDate);
            this.listViewTasks.CellEditUseWholeCell = false;
            this.listViewTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnStatus,
            this.olvColumnCreator,
            this.olvColumnCreateDate,
            this.olvColumnLastRunDate});
            this.listViewTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTasks.EmptyListMsg = "";
            this.listViewTasks.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTasks.FullRowSelect = true;
            this.listViewTasks.HasCollapsibleGroups = false;
            this.listViewTasks.HideSelection = false;
            this.listViewTasks.Location = new System.Drawing.Point(4, 58);
            this.listViewTasks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewTasks.MultiSelect = false;
            this.listViewTasks.Name = "listViewTasks";
            this.listViewTasks.Size = new System.Drawing.Size(1012, 249);
            this.listViewTasks.TabIndex = 2;
            this.listViewTasks.UseCompatibleStateImageBehavior = false;
            this.listViewTasks.View = System.Windows.Forms.View.Details;
            this.listViewTasks.SelectedIndexChanged += new System.EventHandler(this.listViewTasks_SelectedIndexChanged);
            this.listViewTasks.DoubleClick += new System.EventHandler(this.listViewTasks_DoubleClick);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.FillsFreeSpace = true;
            this.olvColumnName.MinimumWidth = 50;
            this.olvColumnName.Text = "Name";
            this.olvColumnName.UseInitialLetterForGroup = true;
            this.olvColumnName.Width = 224;
            // 
            // olvColumnStatus
            // 
            this.olvColumnStatus.AspectName = "Status";
            this.olvColumnStatus.FillsFreeSpace = true;
            this.olvColumnStatus.MinimumWidth = 50;
            this.olvColumnStatus.Text = "Status";
            this.olvColumnStatus.Width = 81;
            // 
            // olvColumnCreator
            // 
            this.olvColumnCreator.AspectName = "Creator";
            this.olvColumnCreator.FillsFreeSpace = true;
            this.olvColumnCreator.MinimumWidth = 50;
            this.olvColumnCreator.Text = "Creator";
            this.olvColumnCreator.Width = 128;
            // 
            // olvColumnCreateDate
            // 
            this.olvColumnCreateDate.AspectName = "CreationTime";
            this.olvColumnCreateDate.FillsFreeSpace = true;
            this.olvColumnCreateDate.MinimumWidth = 50;
            this.olvColumnCreateDate.Text = "Created";
            this.olvColumnCreateDate.Width = 107;
            // 
            // olvColumnLastRunDate
            // 
            this.olvColumnLastRunDate.AspectName = "LastCompletionTime";
            this.olvColumnLastRunDate.FillsFreeSpace = true;
            this.olvColumnLastRunDate.MinimumWidth = 50;
            this.olvColumnLastRunDate.Text = "Last Completed";
            this.olvColumnLastRunDate.Width = 110;
            // 
            // toolStripScanTasks
            // 
            this.toolStripScanTasks.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripScanTasks.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripScanTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStartTask,
            this.toolStripSeparator1,
            this.toolStripButtonNewTask,
            this.toolStripButtonEditTask,
            this.toolStripButtonClone,
            this.toolStripButtonDeleteTask,
            this.toolStripButtonDonate});
            this.toolStripScanTasks.Location = new System.Drawing.Point(4, 24);
            this.toolStripScanTasks.Name = "toolStripScanTasks";
            this.toolStripScanTasks.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripScanTasks.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripScanTasks.Size = new System.Drawing.Size(1012, 34);
            this.toolStripScanTasks.TabIndex = 1;
            this.toolStripScanTasks.Text = "toolStrip1";
            // 
            // toolStripButtonStartTask
            // 
            this.toolStripButtonStartTask.Enabled = false;
            this.toolStripButtonStartTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartTask.Image")));
            this.toolStripButtonStartTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartTask.Name = "toolStripButtonStartTask";
            this.toolStripButtonStartTask.Size = new System.Drawing.Size(114, 29);
            this.toolStripButtonStartTask.Text = "Start Task";
            this.toolStripButtonStartTask.ToolTipText = "Run an existing scan task";
            this.toolStripButtonStartTask.Click += new System.EventHandler(this.toolStripButtonStartTask_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripButtonNewTask
            // 
            this.toolStripButtonNewTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewTask.Image")));
            this.toolStripButtonNewTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewTask.Name = "toolStripButtonNewTask";
            this.toolStripButtonNewTask.Size = new System.Drawing.Size(87, 29);
            this.toolStripButtonNewTask.Text = "New...";
            this.toolStripButtonNewTask.ToolTipText = "Create a new scan task";
            this.toolStripButtonNewTask.Click += new System.EventHandler(this.toolStripButtonNewTask_Click);
            // 
            // toolStripButtonEditTask
            // 
            this.toolStripButtonEditTask.Enabled = false;
            this.toolStripButtonEditTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditTask.Image")));
            this.toolStripButtonEditTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditTask.Name = "toolStripButtonEditTask";
            this.toolStripButtonEditTask.Size = new System.Drawing.Size(82, 29);
            this.toolStripButtonEditTask.Text = "Edit...";
            this.toolStripButtonEditTask.ToolTipText = "Edit an existing scan task";
            this.toolStripButtonEditTask.Click += new System.EventHandler(this.toolStripButtonEditTask_Click);
            // 
            // toolStripButtonClone
            // 
            this.toolStripButtonClone.Enabled = false;
            this.toolStripButtonClone.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClone.Image")));
            this.toolStripButtonClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClone.Name = "toolStripButtonClone";
            this.toolStripButtonClone.Size = new System.Drawing.Size(97, 29);
            this.toolStripButtonClone.Text = "Clone...";
            this.toolStripButtonClone.ToolTipText = "Create a copy of an existing scan task";
            this.toolStripButtonClone.Click += new System.EventHandler(this.toolStripButtonClone_Click);
            // 
            // toolStripButtonDeleteTask
            // 
            this.toolStripButtonDeleteTask.Enabled = false;
            this.toolStripButtonDeleteTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteTask.Image")));
            this.toolStripButtonDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteTask.Name = "toolStripButtonDeleteTask";
            this.toolStripButtonDeleteTask.Size = new System.Drawing.Size(90, 29);
            this.toolStripButtonDeleteTask.Text = "Delete";
            this.toolStripButtonDeleteTask.ToolTipText = "Delete an existing scan task";
            this.toolStripButtonDeleteTask.Click += new System.EventHandler(this.toolStripButtonDeleteTask_Click);
            // 
            // toolStripButtonDonate
            // 
            this.toolStripButtonDonate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDonate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDonate.Image")));
            this.toolStripButtonDonate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDonate.Name = "toolStripButtonDonate";
            this.toolStripButtonDonate.Size = new System.Drawing.Size(137, 29);
            this.toolStripButtonDonate.Text = "Send Coffee";
            this.toolStripButtonDonate.ToolTipText = "Say thanks and support further EduSweep development!";
            this.toolStripButtonDonate.Click += new System.EventHandler(this.toolStripButtonDonate_Click);
            // 
            // statusStripWorkingDirectory
            // 
            this.statusStripWorkingDirectory.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripWorkingDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWorkDirectory});
            this.statusStripWorkingDirectory.Location = new System.Drawing.Point(0, 431);
            this.statusStripWorkingDirectory.Name = "statusStripWorkingDirectory";
            this.statusStripWorkingDirectory.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStripWorkingDirectory.Size = new System.Drawing.Size(1056, 32);
            this.statusStripWorkingDirectory.TabIndex = 4;
            this.statusStripWorkingDirectory.Text = "statusStrip1";
            // 
            // toolStripStatusLabelWorkDirectory
            // 
            this.toolStripStatusLabelWorkDirectory.Name = "toolStripStatusLabelWorkDirectory";
            this.toolStripStatusLabelWorkDirectory.Size = new System.Drawing.Size(285, 25);
            this.toolStripStatusLabelWorkDirectory.Text = "C:\\Example Directory\\Subdirectory";
            this.toolStripStatusLabelWorkDirectory.ToolTipText = "The working directory where EduSweep stores its files and settings";
            // 
            // menuStripTop
            // 
            this.menuStripTop.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scanTasksToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.quarantineToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripTop.Size = new System.Drawing.Size(1056, 35);
            this.menuStripTop.TabIndex = 5;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(141, 34);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // scanTasksToolStripMenuItem
            // 
            this.scanTasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator4,
            this.startToolStripMenuItem,
            this.editToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.scanTasksToolStripMenuItem.Name = "scanTasksToolStripMenuItem";
            this.scanTasksToolStripMenuItem.Size = new System.Drawing.Size(111, 29);
            this.scanTasksToolStripMenuItem.Text = "Scan Tasks";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.newToolStripMenuItem.Text = "New Task...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.editToolStripMenuItem.Text = "Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Enabled = false;
            this.cloneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cloneToolStripMenuItem.Image")));
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.cloneToolStripMenuItem.Text = "Clone...";
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(199, 34);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportBrowserToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // reportBrowserToolStripMenuItem
            // 
            this.reportBrowserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportBrowserToolStripMenuItem.Image")));
            this.reportBrowserToolStripMenuItem.Name = "reportBrowserToolStripMenuItem";
            this.reportBrowserToolStripMenuItem.Size = new System.Drawing.Size(242, 34);
            this.reportBrowserToolStripMenuItem.Text = "Report Manager";
            this.reportBrowserToolStripMenuItem.Click += new System.EventHandler(this.reportBrowserToolStripMenuItem_Click);
            // 
            // quarantineToolStripMenuItem
            // 
            this.quarantineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quarantineBrowserToolStripMenuItem});
            this.quarantineToolStripMenuItem.Name = "quarantineToolStripMenuItem";
            this.quarantineToolStripMenuItem.Size = new System.Drawing.Size(115, 29);
            this.quarantineToolStripMenuItem.Text = "Quarantine";
            // 
            // quarantineBrowserToolStripMenuItem
            // 
            this.quarantineBrowserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quarantineBrowserToolStripMenuItem.Image")));
            this.quarantineBrowserToolStripMenuItem.Name = "quarantineBrowserToolStripMenuItem";
            this.quarantineBrowserToolStripMenuItem.Size = new System.Drawing.Size(276, 34);
            this.quarantineBrowserToolStripMenuItem.Text = "Quarantine Manager";
            this.quarantineBrowserToolStripMenuItem.Click += new System.EventHandler(this.quarantineBrowserToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileInspectorToolStripMenuItem,
            this.launchSignatureStudioToolStripMenuItem,
            this.toolStripSeparator6,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // fileInspectorToolStripMenuItem
            // 
            this.fileInspectorToolStripMenuItem.Enabled = false;
            this.fileInspectorToolStripMenuItem.Name = "fileInspectorToolStripMenuItem";
            this.fileInspectorToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.fileInspectorToolStripMenuItem.Text = "Launch File Inspector";
            this.fileInspectorToolStripMenuItem.Click += new System.EventHandler(this.fileInspectorToolStripMenuItem_Click);
            // 
            // launchSignatureStudioToolStripMenuItem
            // 
            this.launchSignatureStudioToolStripMenuItem.Enabled = false;
            this.launchSignatureStudioToolStripMenuItem.Name = "launchSignatureStudioToolStripMenuItem";
            this.launchSignatureStudioToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.launchSignatureStudioToolStripMenuItem.Text = "Launch Signature Studio";
            this.launchSignatureStudioToolStripMenuItem.Click += new System.EventHandler(this.launchSignatureStudioToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(302, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(305, 34);
            this.optionsToolStripMenuItem.Text = "Settings...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemHomepage,
            this.toolStripMenuItemDocs,
            this.toolStripMenuItemIssue,
            this.toolStripSeparator2,
            this.toolStripMenuItemUpdates,
            this.toolStripSeparator5,
            this.toolStripMenuItemAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItemHomepage
            // 
            this.toolStripMenuItemHomepage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemHomepage.Image")));
            this.toolStripMenuItemHomepage.Name = "toolStripMenuItemHomepage";
            this.toolStripMenuItemHomepage.Size = new System.Drawing.Size(262, 34);
            this.toolStripMenuItemHomepage.Text = "Project Homepage";
            this.toolStripMenuItemHomepage.Click += new System.EventHandler(this.toolStripMenuItemHomepage_Click);
            // 
            // toolStripMenuItemDocs
            // 
            this.toolStripMenuItemDocs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDocs.Image")));
            this.toolStripMenuItemDocs.Name = "toolStripMenuItemDocs";
            this.toolStripMenuItemDocs.Size = new System.Drawing.Size(262, 34);
            this.toolStripMenuItemDocs.Text = "Documentation";
            this.toolStripMenuItemDocs.Click += new System.EventHandler(this.toolStripMenuItemDocs_Click);
            // 
            // toolStripMenuItemIssue
            // 
            this.toolStripMenuItemIssue.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemIssue.Image")));
            this.toolStripMenuItemIssue.Name = "toolStripMenuItemIssue";
            this.toolStripMenuItemIssue.Size = new System.Drawing.Size(262, 34);
            this.toolStripMenuItemIssue.Text = "Report an Issue";
            this.toolStripMenuItemIssue.Click += new System.EventHandler(this.toolStripMenuItemIssue_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(259, 6);
            // 
            // toolStripMenuItemUpdates
            // 
            this.toolStripMenuItemUpdates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemUpdates.Image")));
            this.toolStripMenuItemUpdates.Name = "toolStripMenuItemUpdates";
            this.toolStripMenuItemUpdates.Size = new System.Drawing.Size(262, 34);
            this.toolStripMenuItemUpdates.Text = "Check for Updates";
            this.toolStripMenuItemUpdates.Click += new System.EventHandler(this.toolStripMenuItemUpdates_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(259, 6);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemAbout.Image")));
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(262, 34);
            this.toolStripMenuItemAbout.Text = "About";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBoxHeader
            // 
            this.pictureBoxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxHeader.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHeader.Image")));
            this.pictureBoxHeader.Location = new System.Drawing.Point(0, 35);
            this.pictureBoxHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxHeader.Name = "pictureBoxHeader";
            this.pictureBoxHeader.Size = new System.Drawing.Size(1056, 62);
            this.pictureBoxHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHeader.TabIndex = 6;
            this.pictureBoxHeader.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 463);
            this.Controls.Add(this.pictureBoxHeader);
            this.Controls.Add(this.statusStripWorkingDirectory);
            this.Controls.Add(this.menuStripTop);
            this.Controls.Add(this.groupBoxTasks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTop;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1069, 354);
            this.Name = "FormMain";
            this.Text = "EduSweep";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxTasks.ResumeLayout(false);
            this.groupBoxTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewTasks)).EndInit();
            this.toolStripScanTasks.ResumeLayout(false);
            this.toolStripScanTasks.PerformLayout();
            this.statusStripWorkingDirectory.ResumeLayout(false);
            this.statusStripWorkingDirectory.PerformLayout();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBoxTasks;
        private System.Windows.Forms.ToolStrip toolStripScanTasks;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewTask;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditTask;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteTask;
        private System.Windows.Forms.ToolStripButton toolStripButtonClone;
        private System.Windows.Forms.StatusStrip statusStripWorkingDirectory;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarantineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarantineBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileInspectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem scanTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWorkDirectory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHomepage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDocs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIssue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdates;
        private System.Windows.Forms.PictureBox pictureBoxHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDonate;
        private BrightIdeasSoftware.ObjectListView listViewTasks;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnStatus;
        private BrightIdeasSoftware.OLVColumn olvColumnCreator;
        private BrightIdeasSoftware.OLVColumn olvColumnCreateDate;
        private BrightIdeasSoftware.OLVColumn olvColumnLastRunDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem launchSignatureStudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}