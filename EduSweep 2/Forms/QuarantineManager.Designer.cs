namespace EduSweep_2.Forms
{
    partial class QuarantineManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuarantineManager));
            this.statusStripQuarantine = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.objectListViewFiles = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnExtension = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOwner = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxQuarantine = new System.Windows.Forms.GroupBox();
            this.toolStripQuarantine = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenOriginalLocation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonOnline = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemGoogle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDDG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonExtensions = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemExtFilExt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExtFileInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExtFES = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripQuarantine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxQuarantine.SuspendLayout();
            this.toolStripQuarantine.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripQuarantine
            // 
            this.statusStripQuarantine.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripQuarantine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount,
            this.toolStripStatusLabelSpacer});
            this.statusStripQuarantine.Location = new System.Drawing.Point(0, 523);
            this.statusStripQuarantine.Name = "statusStripQuarantine";
            this.statusStripQuarantine.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStripQuarantine.Size = new System.Drawing.Size(1236, 32);
            this.statusStripQuarantine.TabIndex = 0;
            this.statusStripQuarantine.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabelCount.Text = "Ready";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(1153, 25);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // objectListViewFiles
            // 
            this.objectListViewFiles.AllColumns.Add(this.olvColumnName);
            this.objectListViewFiles.AllColumns.Add(this.olvColumnExtension);
            this.objectListViewFiles.AllColumns.Add(this.olvColumnLocation);
            this.objectListViewFiles.AllColumns.Add(this.olvColumnOwner);
            this.objectListViewFiles.AllColumns.Add(this.olvColumnSize);
            this.objectListViewFiles.AllColumns.Add(this.olvColumnAge);
            this.objectListViewFiles.AllowDrop = true;
            this.objectListViewFiles.CellEditUseWholeCell = false;
            this.objectListViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnExtension,
            this.olvColumnLocation,
            this.olvColumnOwner,
            this.olvColumnSize,
            this.olvColumnAge});
            this.objectListViewFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewFiles.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectListViewFiles.FullRowSelect = true;
            this.objectListViewFiles.HasCollapsibleGroups = false;
            this.objectListViewFiles.HideSelection = false;
            this.objectListViewFiles.Location = new System.Drawing.Point(4, 58);
            this.objectListViewFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.objectListViewFiles.Name = "objectListViewFiles";
            this.objectListViewFiles.Size = new System.Drawing.Size(1192, 352);
            this.objectListViewFiles.TabIndex = 2;
            this.objectListViewFiles.UseCompatibleStateImageBehavior = false;
            this.objectListViewFiles.UseExplorerTheme = true;
            this.objectListViewFiles.View = System.Windows.Forms.View.Details;
            this.objectListViewFiles.SelectedIndexChanged += new System.EventHandler(this.objectListViewFiles_SelectedIndexChanged);
            this.objectListViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.objectListViewFiles_DragDrop);
            this.objectListViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.objectListViewFiles_DragEnter);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "OriginalName";
            this.olvColumnName.FillsFreeSpace = true;
            this.olvColumnName.MinimumWidth = 50;
            this.olvColumnName.Text = "Name";
            this.olvColumnName.UseInitialLetterForGroup = true;
            this.olvColumnName.Width = 167;
            // 
            // olvColumnExtension
            // 
            this.olvColumnExtension.AspectName = "Extension.Name";
            this.olvColumnExtension.FillsFreeSpace = true;
            this.olvColumnExtension.MinimumWidth = 50;
            this.olvColumnExtension.Text = "Extension";
            // 
            // olvColumnLocation
            // 
            this.olvColumnLocation.AspectName = "OriginalDirectoryPath";
            this.olvColumnLocation.FillsFreeSpace = true;
            this.olvColumnLocation.MinimumWidth = 50;
            this.olvColumnLocation.Text = "Original Location";
            this.olvColumnLocation.Width = 292;
            // 
            // olvColumnOwner
            // 
            this.olvColumnOwner.AspectName = "OriginalOwner";
            this.olvColumnOwner.FillsFreeSpace = true;
            this.olvColumnOwner.MinimumWidth = 50;
            this.olvColumnOwner.Text = "Original Owner";
            this.olvColumnOwner.Width = 99;
            // 
            // olvColumnSize
            // 
            this.olvColumnSize.AspectName = "Length";
            this.olvColumnSize.FillsFreeSpace = true;
            this.olvColumnSize.MinimumWidth = 50;
            this.olvColumnSize.Text = "Size";
            this.olvColumnSize.Width = 73;
            // 
            // olvColumnAge
            // 
            this.olvColumnAge.AspectName = "AgeAsText";
            this.olvColumnAge.FillsFreeSpace = true;
            this.olvColumnAge.MinimumWidth = 50;
            this.olvColumnAge.Text = "Age";
            this.olvColumnAge.Width = 72;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1119, 46);
            this.label2.TabIndex = 50;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelHeader.Location = new System.Drawing.Point(98, 14);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(236, 32);
            this.labelHeader.TabIndex = 49;
            this.labelHeader.Text = "Quarantine Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxQuarantine
            // 
            this.groupBoxQuarantine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuarantine.Controls.Add(this.objectListViewFiles);
            this.groupBoxQuarantine.Controls.Add(this.toolStripQuarantine);
            this.groupBoxQuarantine.Location = new System.Drawing.Point(18, 102);
            this.groupBoxQuarantine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxQuarantine.Name = "groupBoxQuarantine";
            this.groupBoxQuarantine.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxQuarantine.Size = new System.Drawing.Size(1200, 415);
            this.groupBoxQuarantine.TabIndex = 51;
            this.groupBoxQuarantine.TabStop = false;
            this.groupBoxQuarantine.Text = "Quarantine Files";
            // 
            // toolStripQuarantine
            // 
            this.toolStripQuarantine.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripQuarantine.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripQuarantine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDetails,
            this.toolStripButtonOpenOriginalLocation,
            this.toolStripSeparator1,
            this.toolStripButtonAdd,
            this.toolStripButtonRestore,
            this.toolStripButtonDelete,
            this.toolStripSeparator2,
            this.toolStripDropDownButtonOnline,
            this.toolStripDropDownButtonExtensions});
            this.toolStripQuarantine.Location = new System.Drawing.Point(4, 24);
            this.toolStripQuarantine.Name = "toolStripQuarantine";
            this.toolStripQuarantine.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripQuarantine.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripQuarantine.Size = new System.Drawing.Size(1192, 34);
            this.toolStripQuarantine.TabIndex = 3;
            this.toolStripQuarantine.Text = "toolStrip1";
            // 
            // toolStripButtonDetails
            // 
            this.toolStripButtonDetails.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDetails.Image")));
            this.toolStripButtonDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDetails.Name = "toolStripButtonDetails";
            this.toolStripButtonDetails.Size = new System.Drawing.Size(128, 29);
            this.toolStripButtonDetails.Text = "Inspect File";
            this.toolStripButtonDetails.ToolTipText = "Get more information on this file";
            this.toolStripButtonDetails.Click += new System.EventHandler(this.toolStripButtonDetails_Click);
            // 
            // toolStripButtonOpenOriginalLocation
            // 
            this.toolStripButtonOpenOriginalLocation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpenOriginalLocation.Image")));
            this.toolStripButtonOpenOriginalLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenOriginalLocation.Name = "toolStripButtonOpenOriginalLocation";
            this.toolStripButtonOpenOriginalLocation.Size = new System.Drawing.Size(223, 29);
            this.toolStripButtonOpenOriginalLocation.Text = "Open Original Location";
            this.toolStripButtonOpenOriginalLocation.ToolTipText = "Open the folder where this file originated";
            this.toolStripButtonOpenOriginalLocation.Click += new System.EventHandler(this.toolStripButtonOpenOriginalLocation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(74, 29);
            this.toolStripButtonAdd.Text = "Add";
            this.toolStripButtonAdd.ToolTipText = "Add files to quarantine";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonRestore
            // 
            this.toolStripButtonRestore.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestore.Image")));
            this.toolStripButtonRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestore.Name = "toolStripButtonRestore";
            this.toolStripButtonRestore.Size = new System.Drawing.Size(99, 29);
            this.toolStripButtonRestore.Text = "Restore";
            this.toolStripButtonRestore.ToolTipText = "Restore files to their original locations";
            this.toolStripButtonRestore.Click += new System.EventHandler(this.toolStripButtonRestore_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(90, 29);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.ToolTipText = "Delete files permanently";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripDropDownButtonOnline
            // 
            this.toolStripDropDownButtonOnline.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGoogle,
            this.toolStripMenuItemBing,
            this.toolStripMenuItemDDG});
            this.toolStripDropDownButtonOnline.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonOnline.Image")));
            this.toolStripDropDownButtonOnline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonOnline.Name = "toolStripDropDownButtonOnline";
            this.toolStripDropDownButtonOnline.Size = new System.Drawing.Size(181, 29);
            this.toolStripDropDownButtonOnline.Text = "Filename Search";
            this.toolStripDropDownButtonOnline.ToolTipText = "Search for this file name";
            // 
            // toolStripMenuItemGoogle
            // 
            this.toolStripMenuItemGoogle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemGoogle.Image")));
            this.toolStripMenuItemGoogle.Name = "toolStripMenuItemGoogle";
            this.toolStripMenuItemGoogle.Size = new System.Drawing.Size(217, 34);
            this.toolStripMenuItemGoogle.Text = "Google";
            this.toolStripMenuItemGoogle.Click += new System.EventHandler(this.toolStripMenuItemGoogle_Click);
            // 
            // toolStripMenuItemBing
            // 
            this.toolStripMenuItemBing.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemBing.Image")));
            this.toolStripMenuItemBing.Name = "toolStripMenuItemBing";
            this.toolStripMenuItemBing.Size = new System.Drawing.Size(217, 34);
            this.toolStripMenuItemBing.Text = "Bing";
            this.toolStripMenuItemBing.Click += new System.EventHandler(this.toolStripMenuItemBing_Click);
            // 
            // toolStripMenuItemDDG
            // 
            this.toolStripMenuItemDDG.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemDDG.Image")));
            this.toolStripMenuItemDDG.Name = "toolStripMenuItemDDG";
            this.toolStripMenuItemDDG.Size = new System.Drawing.Size(217, 34);
            this.toolStripMenuItemDDG.Text = "DuckDuckGo";
            this.toolStripMenuItemDDG.Click += new System.EventHandler(this.toolStripMenuItemDDG_Click);
            // 
            // toolStripDropDownButtonExtensions
            // 
            this.toolStripDropDownButtonExtensions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExtFilExt,
            this.toolStripMenuItemExtFileInfo,
            this.toolStripMenuItemExtFES});
            this.toolStripDropDownButtonExtensions.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonExtensions.Image")));
            this.toolStripDropDownButtonExtensions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonExtensions.Name = "toolStripDropDownButtonExtensions";
            this.toolStripDropDownButtonExtensions.Size = new System.Drawing.Size(186, 29);
            this.toolStripDropDownButtonExtensions.Text = "Extension Search";
            this.toolStripDropDownButtonExtensions.ToolTipText = "Search for this file\'s extension";
            // 
            // toolStripMenuItemExtFilExt
            // 
            this.toolStripMenuItemExtFilExt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExtFilExt.Image")));
            this.toolStripMenuItemExtFilExt.Name = "toolStripMenuItemExtFilExt";
            this.toolStripMenuItemExtFilExt.Size = new System.Drawing.Size(277, 34);
            this.toolStripMenuItemExtFilExt.Text = "FILExt.com";
            this.toolStripMenuItemExtFilExt.Click += new System.EventHandler(this.toolStripMenuItemExtFilExt_Click);
            // 
            // toolStripMenuItemExtFileInfo
            // 
            this.toolStripMenuItemExtFileInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExtFileInfo.Image")));
            this.toolStripMenuItemExtFileInfo.Name = "toolStripMenuItemExtFileInfo";
            this.toolStripMenuItemExtFileInfo.Size = new System.Drawing.Size(277, 34);
            this.toolStripMenuItemExtFileInfo.Text = "Fileinfo.net";
            this.toolStripMenuItemExtFileInfo.Click += new System.EventHandler(this.toolStripMenuItemExtFileInfo_Click);
            // 
            // toolStripMenuItemExtFES
            // 
            this.toolStripMenuItemExtFES.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemExtFES.Image")));
            this.toolStripMenuItemExtFES.Name = "toolStripMenuItemExtFES";
            this.toolStripMenuItemExtFES.Size = new System.Drawing.Size(277, 34);
            this.toolStripMenuItemExtFES.Text = "File Extension Seeker";
            this.toolStripMenuItemExtFES.Click += new System.EventHandler(this.toolStripMenuItemExtFES_Click);
            // 
            // QuarantineManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 555);
            this.Controls.Add(this.groupBoxQuarantine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStripQuarantine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1249, 585);
            this.Name = "QuarantineManager";
            this.Text = "Quarantine Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuarantineManager_FormClosing);
            this.Load += new System.EventHandler(this.Quarantine_Load);
            this.statusStripQuarantine.ResumeLayout(false);
            this.statusStripQuarantine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxQuarantine.ResumeLayout(false);
            this.groupBoxQuarantine.PerformLayout();
            this.toolStripQuarantine.ResumeLayout(false);
            this.toolStripQuarantine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripQuarantine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private BrightIdeasSoftware.ObjectListView objectListViewFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxQuarantine;
        private System.Windows.Forms.ToolStrip toolStripQuarantine;
        private System.Windows.Forms.ToolStripButton toolStripButtonDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenOriginalLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestore;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonOnline;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGoogle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBing;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDDG;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonExtensions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExtFilExt;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExtFileInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExtFES;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnLocation;
        private BrightIdeasSoftware.OLVColumn olvColumnSize;
        private BrightIdeasSoftware.OLVColumn olvColumnOwner;
        private BrightIdeasSoftware.OLVColumn olvColumnAge;
        private BrightIdeasSoftware.OLVColumn olvColumnExtension;
    }
}