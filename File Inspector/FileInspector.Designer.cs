namespace File_Inspector
{
    partial class FileInspector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileInspector));
            this.groupBoxAnalysis = new System.Windows.Forms.GroupBox();
            this.listViewAnalysis = new System.Windows.Forms.ListView();
            this.columnHeaderProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorkerPopulate = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripInspector = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButtonview = new System.Windows.Forms.ToolStripSplitButton();
            this.openWithNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSums = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
            this.statusStripInspector = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelScan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarTaskProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.labelMajorStatus = new System.Windows.Forms.Label();
            this.labelMinorStatus = new System.Windows.Forms.Label();
            this.pictureBoxSummary = new System.Windows.Forms.PictureBox();
            this.groupBoxAnalysis.SuspendLayout();
            this.toolStripInspector.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStripInspector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAnalysis
            // 
            this.groupBoxAnalysis.Controls.Add(this.listViewAnalysis);
            this.groupBoxAnalysis.Location = new System.Drawing.Point(12, 79);
            this.groupBoxAnalysis.Name = "groupBoxAnalysis";
            this.groupBoxAnalysis.Size = new System.Drawing.Size(550, 290);
            this.groupBoxAnalysis.TabIndex = 1;
            this.groupBoxAnalysis.TabStop = false;
            this.groupBoxAnalysis.Text = "File Properties";
            // 
            // listViewAnalysis
            // 
            this.listViewAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProperty,
            this.columnHeaderValue});
            this.listViewAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAnalysis.FullRowSelect = true;
            this.listViewAnalysis.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAnalysis.Location = new System.Drawing.Point(3, 16);
            this.listViewAnalysis.MultiSelect = false;
            this.listViewAnalysis.Name = "listViewAnalysis";
            this.listViewAnalysis.Size = new System.Drawing.Size(544, 271);
            this.listViewAnalysis.TabIndex = 5;
            this.listViewAnalysis.UseCompatibleStateImageBehavior = false;
            this.listViewAnalysis.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProperty
            // 
            this.columnHeaderProperty.Text = "Property";
            this.columnHeaderProperty.Width = 153;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 372;
            // 
            // backgroundWorkerPopulate
            // 
            this.backgroundWorkerPopulate.WorkerSupportsCancellation = true;
            this.backgroundWorkerPopulate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPopulate_DoWork);
            this.backgroundWorkerPopulate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPopulate_RunWorkerCompleted);
            // 
            // toolStripInspector
            // 
            this.toolStripInspector.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripInspector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonDelete,
            this.toolStripSplitButtonview,
            this.toolStripSeparator3,
            this.toolStripButtonSums});
            this.toolStripInspector.Location = new System.Drawing.Point(0, 0);
            this.toolStripInspector.Name = "toolStripInspector";
            this.toolStripInspector.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripInspector.Size = new System.Drawing.Size(575, 25);
            this.toolStripInspector.TabIndex = 8;
            this.toolStripInspector.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonOpen.Text = "Open...";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Enabled = false;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonDelete.Text = "Delete File";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSplitButtonview
            // 
            this.toolStripSplitButtonview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWithNotepadToolStripMenuItem});
            this.toolStripSplitButtonview.Enabled = false;
            this.toolStripSplitButtonview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonview.Image")));
            this.toolStripSplitButtonview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonview.Name = "toolStripSplitButtonview";
            this.toolStripSplitButtonview.Size = new System.Drawing.Size(100, 22);
            this.toolStripSplitButtonview.Text = "Execute File";
            this.toolStripSplitButtonview.ButtonClick += new System.EventHandler(this.toolStripSplitButtonview_ButtonClick);
            // 
            // openWithNotepadToolStripMenuItem
            // 
            this.openWithNotepadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openWithNotepadToolStripMenuItem.Image")));
            this.openWithNotepadToolStripMenuItem.Name = "openWithNotepadToolStripMenuItem";
            this.openWithNotepadToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openWithNotepadToolStripMenuItem.Text = "View with Notepad";
            this.openWithNotepadToolStripMenuItem.Click += new System.EventHandler(this.openWithNotepadToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSums
            // 
            this.toolStripButtonSums.Enabled = false;
            this.toolStripButtonSums.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSums.Image")));
            this.toolStripButtonSums.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSums.Name = "toolStripButtonSums";
            this.toolStripButtonSums.Size = new System.Drawing.Size(109, 22);
            this.toolStripButtonSums.Text = "File Checksums";
            this.toolStripButtonSums.Click += new System.EventHandler(this.toolStripButtonSums_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxDetails);
            this.groupBox2.Location = new System.Drawing.Point(12, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 139);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Analysis";
            // 
            // richTextBoxDetails
            // 
            this.richTextBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetails.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxDetails.Name = "richTextBoxDetails";
            this.richTextBoxDetails.ReadOnly = true;
            this.richTextBoxDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxDetails.ShortcutsEnabled = false;
            this.richTextBoxDetails.Size = new System.Drawing.Size(544, 120);
            this.richTextBoxDetails.TabIndex = 1;
            this.richTextBoxDetails.Text = "";
            // 
            // statusStripInspector
            // 
            this.statusStripInspector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelScan,
            this.toolStripStatusLabelSpacer,
            this.progressBarTaskProgress});
            this.statusStripInspector.Location = new System.Drawing.Point(0, 524);
            this.statusStripInspector.Name = "statusStripInspector";
            this.statusStripInspector.Size = new System.Drawing.Size(575, 22);
            this.statusStripInspector.SizingGrip = false;
            this.statusStripInspector.TabIndex = 49;
            // 
            // toolStripStatusLabelScan
            // 
            this.toolStripStatusLabelScan.AutoSize = false;
            this.toolStripStatusLabelScan.Name = "toolStripStatusLabelScan";
            this.toolStripStatusLabelScan.Size = new System.Drawing.Size(425, 17);
            this.toolStripStatusLabelScan.Text = "Ready";
            this.toolStripStatusLabelScan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // progressBarTaskProgress
            // 
            this.progressBarTaskProgress.Name = "progressBarTaskProgress";
            this.progressBarTaskProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // labelMajorStatus
            // 
            this.labelMajorStatus.AutoSize = true;
            this.labelMajorStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMajorStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.labelMajorStatus.Location = new System.Drawing.Point(51, 34);
            this.labelMajorStatus.Name = "labelMajorStatus";
            this.labelMajorStatus.Size = new System.Drawing.Size(102, 21);
            this.labelMajorStatus.TabIndex = 52;
            this.labelMajorStatus.Text = "File Inspector";
            // 
            // labelMinorStatus
            // 
            this.labelMinorStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinorStatus.Location = new System.Drawing.Point(52, 55);
            this.labelMinorStatus.Name = "labelMinorStatus";
            this.labelMinorStatus.Size = new System.Drawing.Size(483, 21);
            this.labelMinorStatus.TabIndex = 51;
            this.labelMinorStatus.Text = "Displays the properties of a given file and determines possible file types based " +
    "on content.";
            // 
            // pictureBoxSummary
            // 
            this.pictureBoxSummary.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSummary.Image")));
            this.pictureBoxSummary.Location = new System.Drawing.Point(12, 38);
            this.pictureBoxSummary.Name = "pictureBoxSummary";
            this.pictureBoxSummary.Size = new System.Drawing.Size(35, 32);
            this.pictureBoxSummary.TabIndex = 50;
            this.pictureBoxSummary.TabStop = false;
            // 
            // FileInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 546);
            this.Controls.Add(this.labelMajorStatus);
            this.Controls.Add(this.labelMinorStatus);
            this.Controls.Add(this.pictureBoxSummary);
            this.Controls.Add(this.statusStripInspector);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxAnalysis);
            this.Controls.Add(this.toolStripInspector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileInspector";
            this.Text = "File Inspector";
            this.Load += new System.EventHandler(this.FileInspector_Load);
            this.groupBoxAnalysis.ResumeLayout(false);
            this.toolStripInspector.ResumeLayout(false);
            this.toolStripInspector.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStripInspector.ResumeLayout(false);
            this.statusStripInspector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAnalysis;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPopulate;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStripInspector;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ListView listViewAnalysis;
        private System.Windows.Forms.ColumnHeader columnHeaderProperty;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonview;
        private System.Windows.Forms.ToolStripMenuItem openWithNotepadToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripInspector;
        private System.Windows.Forms.ToolStripProgressBar progressBarTaskProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelScan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.Label labelMajorStatus;
        private System.Windows.Forms.Label labelMinorStatus;
        private System.Windows.Forms.PictureBox pictureBoxSummary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSums;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
    }
}