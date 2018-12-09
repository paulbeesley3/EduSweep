namespace Signature_Studio.Forms
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
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAnIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSignatures = new System.Windows.Forms.GroupBox();
            this.listViewSignatures = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCreator = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnElementCount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCreated = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnModified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripRepository = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.statusStripFolder = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripTop.SuspendLayout();
            this.groupBoxSignatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewSignatures)).BeginInit();
            this.toolStripRepository.SuspendLayout();
            this.statusStripFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(775, 24);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectHomepageToolStripMenuItem,
            this.documentationToolStripMenuItem,
            this.reportAnIssueToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // projectHomepageToolStripMenuItem
            // 
            this.projectHomepageToolStripMenuItem.Name = "projectHomepageToolStripMenuItem";
            this.projectHomepageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.projectHomepageToolStripMenuItem.Text = "Project Homepage";
            this.projectHomepageToolStripMenuItem.Click += new System.EventHandler(this.projectHomepageToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // reportAnIssueToolStripMenuItem
            // 
            this.reportAnIssueToolStripMenuItem.Name = "reportAnIssueToolStripMenuItem";
            this.reportAnIssueToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.reportAnIssueToolStripMenuItem.Text = "Report an Issue";
            this.reportAnIssueToolStripMenuItem.Click += new System.EventHandler(this.reportAnIssueToolStripMenuItem_Click);
            // 
            // groupBoxSignatures
            // 
            this.groupBoxSignatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSignatures.Controls.Add(this.listViewSignatures);
            this.groupBoxSignatures.Controls.Add(this.toolStripRepository);
            this.groupBoxSignatures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSignatures.Location = new System.Drawing.Point(12, 27);
            this.groupBoxSignatures.Name = "groupBoxSignatures";
            this.groupBoxSignatures.Size = new System.Drawing.Size(751, 170);
            this.groupBoxSignatures.TabIndex = 1;
            this.groupBoxSignatures.TabStop = false;
            this.groupBoxSignatures.Text = "Custom Signatures";
            // 
            // listViewSignatures
            // 
            this.listViewSignatures.AllColumns.Add(this.olvColumnName);
            this.listViewSignatures.AllColumns.Add(this.olvColumnCreator);
            this.listViewSignatures.AllColumns.Add(this.olvColumnElementCount);
            this.listViewSignatures.AllColumns.Add(this.olvColumnCreated);
            this.listViewSignatures.AllColumns.Add(this.olvColumnModified);
            this.listViewSignatures.CellEditUseWholeCell = false;
            this.listViewSignatures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnCreator,
            this.olvColumnElementCount,
            this.olvColumnCreated,
            this.olvColumnModified});
            this.listViewSignatures.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewSignatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSignatures.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSignatures.FullRowSelect = true;
            this.listViewSignatures.Location = new System.Drawing.Point(3, 44);
            this.listViewSignatures.MultiSelect = false;
            this.listViewSignatures.Name = "listViewSignatures";
            this.listViewSignatures.Size = new System.Drawing.Size(745, 123);
            this.listViewSignatures.TabIndex = 0;
            this.listViewSignatures.UseCompatibleStateImageBehavior = false;
            this.listViewSignatures.View = System.Windows.Forms.View.Details;
            this.listViewSignatures.SelectedIndexChanged += new System.EventHandler(this.listViewSignatures_SelectedIndexChanged);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.Text = "Name";
            this.olvColumnName.UseInitialLetterForGroup = true;
            this.olvColumnName.Width = 302;
            // 
            // olvColumnCreator
            // 
            this.olvColumnCreator.AspectName = "Creator";
            this.olvColumnCreator.Text = "Creator";
            this.olvColumnCreator.Width = 120;
            // 
            // olvColumnElementCount
            // 
            this.olvColumnElementCount.AspectName = "Elements.Count";
            this.olvColumnElementCount.Text = "Elements";
            this.olvColumnElementCount.Width = 64;
            // 
            // olvColumnCreated
            // 
            this.olvColumnCreated.AspectName = "CreationTimeAsText";
            this.olvColumnCreated.Text = "Created";
            this.olvColumnCreated.Width = 155;
            // 
            // olvColumnModified
            // 
            this.olvColumnModified.AspectName = "LastWriteTimeAsText";
            this.olvColumnModified.Text = "Last Modified";
            this.olvColumnModified.Width = 172;
            // 
            // toolStripRepository
            // 
            this.toolStripRepository.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRepository.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripSeparator2,
            this.toolStripButtonRefresh});
            this.toolStripRepository.Location = new System.Drawing.Point(3, 19);
            this.toolStripRepository.Name = "toolStripRepository";
            this.toolStripRepository.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripRepository.Size = new System.Drawing.Size(745, 25);
            this.toolStripRepository.TabIndex = 2;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(123, 22);
            this.toolStripButtonNew.Text = "Create Signature...";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.Enabled = false;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonEdit.Text = "Edit...";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // statusStripFolder
            // 
            this.statusStripFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripFolder.Location = new System.Drawing.Point(0, 211);
            this.statusStripFolder.Name = "statusStripFolder";
            this.statusStripFolder.Size = new System.Drawing.Size(775, 22);
            this.statusStripFolder.TabIndex = 3;
            this.statusStripFolder.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel.Text = "Working Folder";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 233);
            this.Controls.Add(this.statusStripFolder);
            this.Controls.Add(this.groupBoxSignatures);
            this.Controls.Add(this.menuStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTop;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(687, 256);
            this.Name = "FormMain";
            this.Text = "EduSweep Signature Studio";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.groupBoxSignatures.ResumeLayout(false);
            this.groupBoxSignatures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewSignatures)).EndInit();
            this.toolStripRepository.ResumeLayout(false);
            this.toolStripRepository.PerformLayout();
            this.statusStripFolder.ResumeLayout(false);
            this.statusStripFolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxSignatures;
        private System.Windows.Forms.ToolStrip toolStripRepository;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private BrightIdeasSoftware.ObjectListView listViewSignatures;
        private System.Windows.Forms.StatusStrip statusStripFolder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnCreator;
        private BrightIdeasSoftware.OLVColumn olvColumnElementCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private BrightIdeasSoftware.OLVColumn olvColumnCreated;
        private BrightIdeasSoftware.OLVColumn olvColumnModified;
        private System.Windows.Forms.ToolStripMenuItem projectHomepageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportAnIssueToolStripMenuItem;
    }
}