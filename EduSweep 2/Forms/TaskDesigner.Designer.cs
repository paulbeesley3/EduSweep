namespace EduSweep_2.Forms
{
    partial class TaskDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskDesigner));
            this.folderBrowserDialogLocalPath = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.tabControlTask = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.groupBoxAntivirus = new System.Windows.Forms.GroupBox();
            this.checkBoxAntivirus = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxParallel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxTaskName = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.tabPageTargets = new System.Windows.Forms.TabPage();
            this.listViewTargets = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLocal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnRecursive = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxQuickTarget = new System.Windows.Forms.TextBox();
            this.toolStripTargets = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddPath = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddNetworkPath = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemovePath = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRecursive = new System.Windows.Forms.ToolStripButton();
            this.tabPageSignatures = new System.Windows.Forms.TabPage();
            this.listViewElements = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripSignatures = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddSignature = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxElementName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.timerPathCheck = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogBinary = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.extensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlTask.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.groupBoxAntivirus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxTaskName.SuspendLayout();
            this.tabPageTargets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewTargets)).BeginInit();
            this.toolStripTargets.SuspendLayout();
            this.tabPageSignatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewElements)).BeginInit();
            this.toolStripSignatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialogLocalPath
            // 
            this.folderBrowserDialogLocalPath.Description = "Choose a folder to add to the task.";
            this.folderBrowserDialogLocalPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialogLocalPath.ShowNewFolderButton = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(533, 382);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 23);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(433, 382);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 23);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 30);
            this.label2.TabIndex = 47;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelHeader.Location = new System.Drawing.Point(65, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(84, 21);
            this.labelHeader.TabIndex = 46;
            this.labelHeader.Text = "Task Editor";
            // 
            // tabControlTask
            // 
            this.tabControlTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTask.Controls.Add(this.tabPageInfo);
            this.tabControlTask.Controls.Add(this.tabPageTargets);
            this.tabControlTask.Controls.Add(this.tabPageSignatures);
            this.tabControlTask.Location = new System.Drawing.Point(12, 66);
            this.tabControlTask.Name = "tabControlTask";
            this.tabControlTask.SelectedIndex = 0;
            this.tabControlTask.Size = new System.Drawing.Size(615, 308);
            this.tabControlTask.TabIndex = 1;
            this.tabControlTask.SelectedIndexChanged += new System.EventHandler(this.tabControlTask_SelectedIndexChanged);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.groupBoxAntivirus);
            this.tabPageInfo.Controls.Add(this.groupBox1);
            this.tabPageInfo.Controls.Add(this.groupBoxTaskName);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(607, 282);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "General Settings";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxAntivirus
            // 
            this.groupBoxAntivirus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAntivirus.Controls.Add(this.checkBoxAntivirus);
            this.groupBoxAntivirus.Controls.Add(this.label4);
            this.groupBoxAntivirus.Location = new System.Drawing.Point(6, 172);
            this.groupBoxAntivirus.Name = "groupBoxAntivirus";
            this.groupBoxAntivirus.Size = new System.Drawing.Size(595, 87);
            this.groupBoxAntivirus.TabIndex = 8;
            this.groupBoxAntivirus.TabStop = false;
            this.groupBoxAntivirus.Text = "Antivirus Integration";
            // 
            // checkBoxAntivirus
            // 
            this.checkBoxAntivirus.AutoSize = true;
            this.checkBoxAntivirus.Location = new System.Drawing.Point(9, 57);
            this.checkBoxAntivirus.Name = "checkBoxAntivirus";
            this.checkBoxAntivirus.Size = new System.Drawing.Size(271, 17);
            this.checkBoxAntivirus.TabIndex = 50;
            this.checkBoxAntivirus.Text = "Enable ClamAV antivirus scanning of detected items";
            this.checkBoxAntivirus.UseVisualStyleBackColor = true;
            this.checkBoxAntivirus.CheckedChanged += new System.EventHandler(this.checkBoxAntivirus_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(583, 37);
            this.label4.TabIndex = 49;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxParallel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parallel Scanning";
            // 
            // comboBoxParallel
            // 
            this.comboBoxParallel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParallel.FormattingEnabled = true;
            this.comboBoxParallel.Items.AddRange(new object[] {
            "Disabled",
            "Reduced",
            "Full (Recommended)"});
            this.comboBoxParallel.Location = new System.Drawing.Point(6, 57);
            this.comboBoxParallel.Name = "comboBoxParallel";
            this.comboBoxParallel.Size = new System.Drawing.Size(583, 21);
            this.comboBoxParallel.TabIndex = 50;
            this.comboBoxParallel.SelectedIndexChanged += new System.EventHandler(this.comboBoxParallel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(583, 37);
            this.label3.TabIndex = 49;
            this.label3.Text = "EduSweep can use multiple processor cores when scanning large directories. The nu" +
    "mber of cores used is managed automatically but the degree of parallelism can be" +
    " limited if desired.";
            // 
            // groupBoxTaskName
            // 
            this.groupBoxTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTaskName.Controls.Add(this.label1);
            this.groupBoxTaskName.Controls.Add(this.textBoxName);
            this.groupBoxTaskName.Location = new System.Drawing.Point(6, 6);
            this.groupBoxTaskName.Name = "groupBoxTaskName";
            this.groupBoxTaskName.Size = new System.Drawing.Size(595, 67);
            this.groupBoxTaskName.TabIndex = 6;
            this.groupBoxTaskName.TabStop = false;
            this.groupBoxTaskName.Text = "Name";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "Give this task a recognisable name so that it can be identified in future.";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(6, 37);
            this.textBoxName.MaxLength = 80;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(583, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // tabPageTargets
            // 
            this.tabPageTargets.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTargets.Controls.Add(this.listViewTargets);
            this.tabPageTargets.Controls.Add(this.label8);
            this.tabPageTargets.Controls.Add(this.textBoxQuickTarget);
            this.tabPageTargets.Controls.Add(this.toolStripTargets);
            this.tabPageTargets.Location = new System.Drawing.Point(4, 22);
            this.tabPageTargets.Name = "tabPageTargets";
            this.tabPageTargets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTargets.Size = new System.Drawing.Size(607, 282);
            this.tabPageTargets.TabIndex = 1;
            this.tabPageTargets.Text = "Target Directories";
            // 
            // listViewTargets
            // 
            this.listViewTargets.AllColumns.Add(this.olvColumnPath);
            this.listViewTargets.AllColumns.Add(this.olvColumnLocal);
            this.listViewTargets.AllColumns.Add(this.olvColumnRecursive);
            this.listViewTargets.AllowDrop = true;
            this.listViewTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTargets.CellEditUseWholeCell = false;
            this.listViewTargets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnPath,
            this.olvColumnLocal,
            this.olvColumnRecursive});
            this.listViewTargets.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewTargets.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTargets.FullRowSelect = true;
            this.listViewTargets.HasCollapsibleGroups = false;
            this.listViewTargets.Location = new System.Drawing.Point(6, 31);
            this.listViewTargets.Name = "listViewTargets";
            this.listViewTargets.Size = new System.Drawing.Size(595, 219);
            this.listViewTargets.TabIndex = 56;
            this.listViewTargets.UseCompatibleStateImageBehavior = false;
            this.listViewTargets.View = System.Windows.Forms.View.Details;
            this.listViewTargets.SelectedIndexChanged += new System.EventHandler(this.listViewTargets_SelectedIndexChanged);
            this.listViewTargets.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewTargets_DragDrop);
            this.listViewTargets.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewTargets_DragEnter);
            // 
            // olvColumnPath
            // 
            this.olvColumnPath.AspectName = "Path";
            this.olvColumnPath.FillsFreeSpace = true;
            this.olvColumnPath.MinimumWidth = 50;
            this.olvColumnPath.Text = "Path";
            this.olvColumnPath.UseInitialLetterForGroup = true;
            // 
            // olvColumnLocal
            // 
            this.olvColumnLocal.AspectName = "PathType";
            this.olvColumnLocal.FillsFreeSpace = true;
            this.olvColumnLocal.MinimumWidth = 50;
            this.olvColumnLocal.Text = "Type";
            // 
            // olvColumnRecursive
            // 
            this.olvColumnRecursive.AspectName = "Recursive";
            this.olvColumnRecursive.FillsFreeSpace = true;
            this.olvColumnRecursive.MinimumWidth = 50;
            this.olvColumnRecursive.Text = "Recursive";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(6, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 55;
            this.label8.Text = "Quick Add:\r\n";
            // 
            // textBoxQuickTarget
            // 
            this.textBoxQuickTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuickTarget.Location = new System.Drawing.Point(78, 256);
            this.textBoxQuickTarget.Name = "textBoxQuickTarget";
            this.textBoxQuickTarget.Size = new System.Drawing.Size(523, 20);
            this.textBoxQuickTarget.TabIndex = 5;
            this.textBoxQuickTarget.TextChanged += new System.EventHandler(this.textBoxQuickTarget_TextChanged);
            this.textBoxQuickTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuickTarget_KeyPress);
            // 
            // toolStripTargets
            // 
            this.toolStripTargets.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddPath,
            this.toolStripButtonAddNetworkPath,
            this.toolStripButtonRemovePath,
            this.toolStripSeparator1,
            this.toolStripButtonRecursive});
            this.toolStripTargets.Location = new System.Drawing.Point(3, 3);
            this.toolStripTargets.Name = "toolStripTargets";
            this.toolStripTargets.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripTargets.Size = new System.Drawing.Size(601, 25);
            this.toolStripTargets.TabIndex = 51;
            this.toolStripTargets.Text = "toolStrip1";
            // 
            // toolStripButtonAddPath
            // 
            this.toolStripButtonAddPath.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddPath.Image")));
            this.toolStripButtonAddPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddPath.Name = "toolStripButtonAddPath";
            this.toolStripButtonAddPath.Size = new System.Drawing.Size(151, 22);
            this.toolStripButtonAddPath.Text = "Browse for Directories...";
            this.toolStripButtonAddPath.Click += new System.EventHandler(this.toolStripButtonAddPath_Click);
            // 
            // toolStripButtonAddNetworkPath
            // 
            this.toolStripButtonAddNetworkPath.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddNetworkPath.Image")));
            this.toolStripButtonAddNetworkPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNetworkPath.Name = "toolStripButtonAddNetworkPath";
            this.toolStripButtonAddNetworkPath.Size = new System.Drawing.Size(155, 22);
            this.toolStripButtonAddNetworkPath.Text = "Add Network Location...";
            this.toolStripButtonAddNetworkPath.ToolTipText = "Add Network Location";
            this.toolStripButtonAddNetworkPath.Click += new System.EventHandler(this.toolStripButtonAddNetworkPath_Click);
            // 
            // toolStripButtonRemovePath
            // 
            this.toolStripButtonRemovePath.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemovePath.Image")));
            this.toolStripButtonRemovePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemovePath.Name = "toolStripButtonRemovePath";
            this.toolStripButtonRemovePath.Size = new System.Drawing.Size(70, 22);
            this.toolStripButtonRemovePath.Text = "Remove";
            this.toolStripButtonRemovePath.Click += new System.EventHandler(this.toolStripButtonRemovePath_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRecursive
            // 
            this.toolStripButtonRecursive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRecursive.Image")));
            this.toolStripButtonRecursive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRecursive.Name = "toolStripButtonRecursive";
            this.toolStripButtonRecursive.Size = new System.Drawing.Size(161, 22);
            this.toolStripButtonRecursive.Text = "Toggle Subdirectory Scan";
            this.toolStripButtonRecursive.Click += new System.EventHandler(this.toolStripButtonSubdirs_Click);
            // 
            // tabPageSignatures
            // 
            this.tabPageSignatures.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSignatures.Controls.Add(this.listViewElements);
            this.tabPageSignatures.Controls.Add(this.toolStripSignatures);
            this.tabPageSignatures.Location = new System.Drawing.Point(4, 22);
            this.tabPageSignatures.Name = "tabPageSignatures";
            this.tabPageSignatures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSignatures.Size = new System.Drawing.Size(607, 282);
            this.tabPageSignatures.TabIndex = 5;
            this.tabPageSignatures.Text = "Signatures and Elements";
            // 
            // listViewElements
            // 
            this.listViewElements.AllColumns.Add(this.olvColumnName);
            this.listViewElements.AllColumns.Add(this.olvColumnType);
            this.listViewElements.CellEditUseWholeCell = false;
            this.listViewElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnType});
            this.listViewElements.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewElements.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewElements.FullRowSelect = true;
            this.listViewElements.HasCollapsibleGroups = false;
            this.listViewElements.Location = new System.Drawing.Point(3, 28);
            this.listViewElements.Name = "listViewElements";
            this.listViewElements.Size = new System.Drawing.Size(601, 251);
            this.listViewElements.TabIndex = 78;
            this.listViewElements.UseCompatibleStateImageBehavior = false;
            this.listViewElements.View = System.Windows.Forms.View.Details;
            this.listViewElements.SelectedIndexChanged += new System.EventHandler(this.listViewElements_SelectedIndexChanged);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.FillsFreeSpace = true;
            this.olvColumnName.MinimumWidth = 50;
            this.olvColumnName.Text = "Element Name";
            this.olvColumnName.UseInitialLetterForGroup = true;
            this.olvColumnName.Width = 470;
            // 
            // olvColumnType
            // 
            this.olvColumnType.AspectName = "Type";
            this.olvColumnType.FillsFreeSpace = true;
            this.olvColumnType.MinimumWidth = 50;
            this.olvColumnType.Text = "Element Type";
            this.olvColumnType.Width = 109;
            // 
            // toolStripSignatures
            // 
            this.toolStripSignatures.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSignatures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddSignature,
            this.toolStripSeparator2,
            this.toolStripTextBoxElementName,
            this.toolStripButtonAdd,
            this.toolStripSeparator4,
            this.toolStripButtonAddFile,
            this.toolStripSeparator3,
            this.toolStripButtonRemove});
            this.toolStripSignatures.Location = new System.Drawing.Point(3, 3);
            this.toolStripSignatures.Name = "toolStripSignatures";
            this.toolStripSignatures.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSignatures.Size = new System.Drawing.Size(601, 25);
            this.toolStripSignatures.TabIndex = 77;
            this.toolStripSignatures.Text = "toolStrip2";
            // 
            // toolStripButtonAddSignature
            // 
            this.toolStripButtonAddSignature.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddSignature.Image")));
            this.toolStripButtonAddSignature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddSignature.Name = "toolStripButtonAddSignature";
            this.toolStripButtonAddSignature.Size = new System.Drawing.Size(132, 22);
            this.toolStripButtonAddSignature.Text = "Browse Signatures...";
            this.toolStripButtonAddSignature.Click += new System.EventHandler(this.toolStripButtonAddKeywordSignature_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBoxElementName
            // 
            this.toolStripTextBoxElementName.Name = "toolStripTextBoxElementName";
            this.toolStripTextBoxElementName.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxElementName.TextChanged += new System.EventHandler(this.toolStripTextBoxElementName_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAddFile
            // 
            this.toolStripButtonAddFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFile.Image")));
            this.toolStripButtonAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFile.Name = "toolStripButtonAddFile";
            this.toolStripButtonAddFile.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonAddFile.Text = "Add File...";
            this.toolStripButtonAddFile.Click += new System.EventHandler(this.toolStripButtonAddFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemove.Image")));
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(117, 22);
            this.toolStripButtonRemove.Text = "Remove Selected";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(12, 382);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(94, 23);
            this.buttonBack.TabIndex = 18;
            this.buttonBack.Text = "< Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNext.Location = new System.Drawing.Point(112, 382);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(94, 23);
            this.buttonNext.TabIndex = 19;
            this.buttonNext.Text = "Next >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // timerPathCheck
            // 
            this.timerPathCheck.Tick += new System.EventHandler(this.timerPathCheck_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extensionToolStripMenuItem,
            this.keywordToolStripMenuItem});
            this.toolStripButtonAdd.Enabled = false;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(67, 22);
            this.toolStripButtonAdd.Text = "Add...";
            // 
            // extensionToolStripMenuItem
            // 
            this.extensionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extensionToolStripMenuItem.Image")));
            this.extensionToolStripMenuItem.Name = "extensionToolStripMenuItem";
            this.extensionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extensionToolStripMenuItem.Text = "Extension";
            this.extensionToolStripMenuItem.Click += new System.EventHandler(this.extensionToolStripMenuItem_Click);
            // 
            // keywordToolStripMenuItem
            // 
            this.keywordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("keywordToolStripMenuItem.Image")));
            this.keywordToolStripMenuItem.Name = "keywordToolStripMenuItem";
            this.keywordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keywordToolStripMenuItem.Text = "Keyword";
            this.keywordToolStripMenuItem.Click += new System.EventHandler(this.keywordToolStripMenuItem_Click);
            // 
            // TaskDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(641, 417);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.tabControlTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(651, 447);
            this.Name = "TaskDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Editor";
            this.Load += new System.EventHandler(this.NewTask_Load);
            this.tabControlTask.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.groupBoxAntivirus.ResumeLayout(false);
            this.groupBoxAntivirus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxTaskName.ResumeLayout(false);
            this.groupBoxTaskName.PerformLayout();
            this.tabPageTargets.ResumeLayout(false);
            this.tabPageTargets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewTargets)).EndInit();
            this.toolStripTargets.ResumeLayout(false);
            this.toolStripTargets.PerformLayout();
            this.tabPageSignatures.ResumeLayout(false);
            this.tabPageSignatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewElements)).EndInit();
            this.toolStripSignatures.ResumeLayout(false);
            this.toolStripSignatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalPath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControlTask;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageTargets;
        private System.Windows.Forms.GroupBox groupBoxTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxQuickTarget;
        private System.Windows.Forms.ToolStrip toolStripTargets;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddPath;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNetworkPath;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemovePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRecursive;
        private System.Windows.Forms.TabPage tabPageSignatures;
        private System.Windows.Forms.Timer timerPathCheck;
        private System.Windows.Forms.OpenFileDialog openFileDialogBinary;
        private System.Windows.Forms.ToolStrip toolStripSignatures;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddSignature;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxParallel;
        private BrightIdeasSoftware.ObjectListView listViewTargets;
        private BrightIdeasSoftware.OLVColumn olvColumnPath;
        private BrightIdeasSoftware.OLVColumn olvColumnLocal;
        private BrightIdeasSoftware.OLVColumn olvColumnRecursive;
        private System.Windows.Forms.GroupBox groupBoxAntivirus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAntivirus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFile;
        private BrightIdeasSoftware.ObjectListView listViewElements;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxElementName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripMenuItem extensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keywordToolStripMenuItem;
    }
}