namespace Signature_Studio.Forms
{
    partial class SignatureEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignatureEditor));
            this.labelMinor = new System.Windows.Forms.Label();
            this.labelMajor = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxKeywords = new System.Windows.Forms.GroupBox();
            this.listViewKeywords = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnKeyword = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripKeywords = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddKeyword = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRemoveKeyword = new System.Windows.Forms.ToolStripButton();
            this.groupBoxMD5 = new System.Windows.Forms.GroupBox();
            this.listViewFiles = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripFiles = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFile = new System.Windows.Forms.ToolStripButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelSignatureTitle = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.toolStripButtonAddExtension = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveExtension = new System.Windows.Forms.ToolStripButton();
            this.groupBoxExtensions = new System.Windows.Forms.GroupBox();
            this.listViewExtensions = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnExtension = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripExtensions = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxExtension = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBoxKeywords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewKeywords)).BeginInit();
            this.toolStripKeywords.SuspendLayout();
            this.groupBoxMD5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewFiles)).BeginInit();
            this.toolStripFiles.SuspendLayout();
            this.groupBoxExtensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewExtensions)).BeginInit();
            this.toolStripExtensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMinor
            // 
            this.labelMinor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinor.Location = new System.Drawing.Point(99, 46);
            this.labelMinor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinor.Name = "labelMinor";
            this.labelMinor.Size = new System.Drawing.Size(510, 46);
            this.labelMinor.TabIndex = 50;
            this.labelMinor.Text = "Build your signature by adding signature elements. Set a name and, optionally, a " +
    "category and description before saving.";
            // 
            // labelMajor
            // 
            this.labelMajor.AutoSize = true;
            this.labelMajor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelMajor.Location = new System.Drawing.Point(98, 14);
            this.labelMajor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(186, 32);
            this.labelMajor.TabIndex = 49;
            this.labelMajor.Text = "Signature Editor";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(18, 18);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(72, 74);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 48;
            this.pictureBoxLogo.TabStop = false;
            // 
            // groupBoxKeywords
            // 
            this.groupBoxKeywords.Controls.Add(this.listViewKeywords);
            this.groupBoxKeywords.Controls.Add(this.toolStripKeywords);
            this.groupBoxKeywords.Location = new System.Drawing.Point(18, 529);
            this.groupBoxKeywords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxKeywords.Name = "groupBoxKeywords";
            this.groupBoxKeywords.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxKeywords.Size = new System.Drawing.Size(591, 208);
            this.groupBoxKeywords.TabIndex = 52;
            this.groupBoxKeywords.TabStop = false;
            this.groupBoxKeywords.Text = "Filename Keywords";
            // 
            // listViewKeywords
            // 
            this.listViewKeywords.AllColumns.Add(this.olvColumnKeyword);
            this.listViewKeywords.CellEditUseWholeCell = false;
            this.listViewKeywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnKeyword});
            this.listViewKeywords.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewKeywords.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewKeywords.FullRowSelect = true;
            this.listViewKeywords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewKeywords.HideSelection = false;
            this.listViewKeywords.Location = new System.Drawing.Point(4, 58);
            this.listViewKeywords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewKeywords.MultiSelect = false;
            this.listViewKeywords.Name = "listViewKeywords";
            this.listViewKeywords.ShowGroups = false;
            this.listViewKeywords.Size = new System.Drawing.Size(583, 145);
            this.listViewKeywords.TabIndex = 2;
            this.listViewKeywords.UseCompatibleStateImageBehavior = false;
            this.listViewKeywords.View = System.Windows.Forms.View.Details;
            this.listViewKeywords.SelectedIndexChanged += new System.EventHandler(this.listViewKeywords_SelectedIndexChanged);
            // 
            // olvColumnKeyword
            // 
            this.olvColumnKeyword.AspectName = "Word";
            this.olvColumnKeyword.FillsFreeSpace = true;
            // 
            // toolStripKeywords
            // 
            this.toolStripKeywords.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripKeywords.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripKeywords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxKeyword,
            this.toolStripButtonAddKeyword,
            this.toolStripSeparator2,
            this.toolStripButtonRemoveKeyword});
            this.toolStripKeywords.Location = new System.Drawing.Point(4, 24);
            this.toolStripKeywords.Name = "toolStripKeywords";
            this.toolStripKeywords.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripKeywords.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripKeywords.Size = new System.Drawing.Size(583, 34);
            this.toolStripKeywords.TabIndex = 0;
            this.toolStripKeywords.Text = "toolStrip2";
            // 
            // toolStripTextBoxKeyword
            // 
            this.toolStripTextBoxKeyword.Name = "toolStripTextBoxKeyword";
            this.toolStripTextBoxKeyword.Size = new System.Drawing.Size(223, 34);
            this.toolStripTextBoxKeyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxKeyword_KeyUp);
            this.toolStripTextBoxKeyword.TextChanged += new System.EventHandler(this.toolStripTextBoxKeyword_TextChanged);
            // 
            // toolStripButtonAddKeyword
            // 
            this.toolStripButtonAddKeyword.Enabled = false;
            this.toolStripButtonAddKeyword.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddKeyword.Image")));
            this.toolStripButtonAddKeyword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddKeyword.Name = "toolStripButtonAddKeyword";
            this.toolStripButtonAddKeyword.Size = new System.Drawing.Size(74, 29);
            this.toolStripButtonAddKeyword.Text = "Add";
            this.toolStripButtonAddKeyword.Click += new System.EventHandler(this.toolStripButtonAddKeyword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripButtonRemoveKeyword
            // 
            this.toolStripButtonRemoveKeyword.Enabled = false;
            this.toolStripButtonRemoveKeyword.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveKeyword.Image")));
            this.toolStripButtonRemoveKeyword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveKeyword.Name = "toolStripButtonRemoveKeyword";
            this.toolStripButtonRemoveKeyword.Size = new System.Drawing.Size(104, 29);
            this.toolStripButtonRemoveKeyword.Text = "Remove";
            this.toolStripButtonRemoveKeyword.Click += new System.EventHandler(this.toolStripButtonRemoveKeyword_Click);
            // 
            // groupBoxMD5
            // 
            this.groupBoxMD5.Controls.Add(this.listViewFiles);
            this.groupBoxMD5.Controls.Add(this.toolStripFiles);
            this.groupBoxMD5.Location = new System.Drawing.Point(18, 746);
            this.groupBoxMD5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMD5.Name = "groupBoxMD5";
            this.groupBoxMD5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMD5.Size = new System.Drawing.Size(591, 208);
            this.groupBoxMD5.TabIndex = 53;
            this.groupBoxMD5.TabStop = false;
            this.groupBoxMD5.Text = "Specific Files";
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllColumns.Add(this.olvColumnFileName);
            this.listViewFiles.CellEditUseWholeCell = false;
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnFileName});
            this.listViewFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(4, 58);
            this.listViewFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewFiles.MultiSelect = false;
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.ShowGroups = false;
            this.listViewFiles.Size = new System.Drawing.Size(583, 145);
            this.listViewFiles.TabIndex = 2;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            // 
            // olvColumnFileName
            // 
            this.olvColumnFileName.AspectName = "AbsolutePath";
            this.olvColumnFileName.FillsFreeSpace = true;
            // 
            // toolStripFiles
            // 
            this.toolStripFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFiles.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFile,
            this.toolStripButtonRemoveFile});
            this.toolStripFiles.Location = new System.Drawing.Point(4, 24);
            this.toolStripFiles.Name = "toolStripFiles";
            this.toolStripFiles.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripFiles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripFiles.Size = new System.Drawing.Size(583, 34);
            this.toolStripFiles.TabIndex = 0;
            this.toolStripFiles.Text = "toolStrip1";
            // 
            // toolStripButtonAddFile
            // 
            this.toolStripButtonAddFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFile.Image")));
            this.toolStripButtonAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFile.Name = "toolStripButtonAddFile";
            this.toolStripButtonAddFile.Size = new System.Drawing.Size(117, 29);
            this.toolStripButtonAddFile.Text = "Add File...";
            this.toolStripButtonAddFile.Click += new System.EventHandler(this.toolStripButtonAddFile_Click);
            // 
            // toolStripButtonRemoveFile
            // 
            this.toolStripButtonRemoveFile.Enabled = false;
            this.toolStripButtonRemoveFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveFile.Image")));
            this.toolStripButtonRemoveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveFile.Name = "toolStripButtonRemoveFile";
            this.toolStripButtonRemoveFile.Size = new System.Drawing.Size(104, 29);
            this.toolStripButtonRemoveFile.Text = "Remove";
            this.toolStripButtonRemoveFile.Click += new System.EventHandler(this.toolStripButtonRemoveFile_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(496, 963);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 35);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Location = new System.Drawing.Point(375, 963);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(112, 35);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelSignatureTitle
            // 
            this.labelSignatureTitle.AutoSize = true;
            this.labelSignatureTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignatureTitle.Location = new System.Drawing.Point(18, 109);
            this.labelSignatureTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSignatureTitle.Name = "labelSignatureTitle";
            this.labelSignatureTitle.Size = new System.Drawing.Size(59, 25);
            this.labelSignatureTitle.TabIndex = 57;
            this.labelSignatureTitle.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(22, 137);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(580, 26);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // toolStripButtonAddExtension
            // 
            this.toolStripButtonAddExtension.Enabled = false;
            this.toolStripButtonAddExtension.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddExtension.Image")));
            this.toolStripButtonAddExtension.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddExtension.Name = "toolStripButtonAddExtension";
            this.toolStripButtonAddExtension.Size = new System.Drawing.Size(74, 29);
            this.toolStripButtonAddExtension.Text = "Add";
            this.toolStripButtonAddExtension.Click += new System.EventHandler(this.toolStripButtonAddExtension_Click);
            // 
            // toolStripButtonRemoveExtension
            // 
            this.toolStripButtonRemoveExtension.Enabled = false;
            this.toolStripButtonRemoveExtension.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveExtension.Image")));
            this.toolStripButtonRemoveExtension.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveExtension.Name = "toolStripButtonRemoveExtension";
            this.toolStripButtonRemoveExtension.Size = new System.Drawing.Size(104, 29);
            this.toolStripButtonRemoveExtension.Text = "Remove";
            this.toolStripButtonRemoveExtension.Click += new System.EventHandler(this.toolStripButtonRemoveExtension_Click);
            // 
            // groupBoxExtensions
            // 
            this.groupBoxExtensions.Controls.Add(this.listViewExtensions);
            this.groupBoxExtensions.Controls.Add(this.toolStripExtensions);
            this.groupBoxExtensions.Location = new System.Drawing.Point(18, 312);
            this.groupBoxExtensions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxExtensions.Name = "groupBoxExtensions";
            this.groupBoxExtensions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxExtensions.Size = new System.Drawing.Size(591, 208);
            this.groupBoxExtensions.TabIndex = 51;
            this.groupBoxExtensions.TabStop = false;
            this.groupBoxExtensions.Text = "File Extensions";
            // 
            // listViewExtensions
            // 
            this.listViewExtensions.AllColumns.Add(this.olvColumnExtension);
            this.listViewExtensions.CellEditUseWholeCell = false;
            this.listViewExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnExtension});
            this.listViewExtensions.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewExtensions.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewExtensions.FullRowSelect = true;
            this.listViewExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewExtensions.HideSelection = false;
            this.listViewExtensions.Location = new System.Drawing.Point(4, 58);
            this.listViewExtensions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewExtensions.MultiSelect = false;
            this.listViewExtensions.Name = "listViewExtensions";
            this.listViewExtensions.ShowGroups = false;
            this.listViewExtensions.Size = new System.Drawing.Size(583, 145);
            this.listViewExtensions.TabIndex = 1;
            this.listViewExtensions.UseCompatibleStateImageBehavior = false;
            this.listViewExtensions.View = System.Windows.Forms.View.Details;
            this.listViewExtensions.SelectedIndexChanged += new System.EventHandler(this.listViewExtensions_SelectedIndexChanged);
            // 
            // olvColumnExtension
            // 
            this.olvColumnExtension.AspectName = "Extension.Name";
            this.olvColumnExtension.FillsFreeSpace = true;
            // 
            // toolStripExtensions
            // 
            this.toolStripExtensions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripExtensions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripExtensions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxExtension,
            this.toolStripButtonAddExtension,
            this.toolStripSeparator1,
            this.toolStripButtonRemoveExtension});
            this.toolStripExtensions.Location = new System.Drawing.Point(4, 24);
            this.toolStripExtensions.Name = "toolStripExtensions";
            this.toolStripExtensions.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripExtensions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripExtensions.Size = new System.Drawing.Size(583, 34);
            this.toolStripExtensions.TabIndex = 0;
            this.toolStripExtensions.Text = "toolStrip3";
            // 
            // toolStripTextBoxExtension
            // 
            this.toolStripTextBoxExtension.Name = "toolStripTextBoxExtension";
            this.toolStripTextBoxExtension.Size = new System.Drawing.Size(148, 34);
            this.toolStripTextBoxExtension.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxExtension_KeyUp);
            this.toolStripTextBoxExtension.TextChanged += new System.EventHandler(this.toolStripTextBoxExtension_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(22, 263);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(580, 29);
            this.textBoxDescription.TabIndex = 2;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 235);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 59;
            this.label1.Text = "Description (Optional)";
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(22, 200);
            this.textBoxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(580, 26);
            this.textBoxCategory.TabIndex = 1;
            this.textBoxCategory.TextChanged += new System.EventHandler(this.textBoxCategory_TextChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategory.Location = new System.Drawing.Point(18, 172);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(168, 25);
            this.labelCategory.TabIndex = 61;
            this.labelCategory.Text = "Category (Optional)";
            // 
            // SignatureEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 1014);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelSignatureTitle);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxMD5);
            this.Controls.Add(this.groupBoxKeywords);
            this.Controls.Add(this.groupBoxExtensions);
            this.Controls.Add(this.labelMinor);
            this.Controls.Add(this.labelMajor);
            this.Controls.Add(this.pictureBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SignatureEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signature Editor";
            this.Load += new System.EventHandler(this.SignatureEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxKeywords.ResumeLayout(false);
            this.groupBoxKeywords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewKeywords)).EndInit();
            this.toolStripKeywords.ResumeLayout(false);
            this.toolStripKeywords.PerformLayout();
            this.groupBoxMD5.ResumeLayout(false);
            this.groupBoxMD5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewFiles)).EndInit();
            this.toolStripFiles.ResumeLayout(false);
            this.toolStripFiles.PerformLayout();
            this.groupBoxExtensions.ResumeLayout(false);
            this.groupBoxExtensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewExtensions)).EndInit();
            this.toolStripExtensions.ResumeLayout(false);
            this.toolStripExtensions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinor;
        private System.Windows.Forms.Label labelMajor;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.GroupBox groupBoxKeywords;
        private System.Windows.Forms.GroupBox groupBoxMD5;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ToolStrip toolStripKeywords;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddKeyword;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveKeyword;
        private System.Windows.Forms.ToolStrip toolStripFiles;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFile;
        private System.Windows.Forms.Label labelSignatureTitle;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddExtension;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveExtension;
        private System.Windows.Forms.GroupBox groupBoxExtensions;
        private System.Windows.Forms.ToolStrip toolStripExtensions;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView listViewExtensions;
        private BrightIdeasSoftware.ObjectListView listViewKeywords;
        private BrightIdeasSoftware.ObjectListView listViewFiles;
        private BrightIdeasSoftware.OLVColumn olvColumnFileName;
        private BrightIdeasSoftware.OLVColumn olvColumnKeyword;
        private BrightIdeasSoftware.OLVColumn olvColumnExtension;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxExtension;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKeyword;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label labelCategory;
    }
}

