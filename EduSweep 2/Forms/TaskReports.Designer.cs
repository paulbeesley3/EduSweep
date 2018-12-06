namespace EduSweep_2.Forms
{
    partial class TaskReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskReports));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewReports = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDuration = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnRunner = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStripReports = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.statusStripReports = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowserReport = new System.Windows.Forms.WebBrowser();
            this.saveFileDialogReport = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewReports)).BeginInit();
            this.toolStripReports.SuspendLayout();
            this.statusStripReports.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewReports);
            this.groupBox2.Controls.Add(this.toolStripReports);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 194);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Reports";
            // 
            // listViewReports
            // 
            this.listViewReports.AllColumns.Add(this.olvColumnName);
            this.listViewReports.AllColumns.Add(this.olvColumnDate);
            this.listViewReports.AllColumns.Add(this.olvColumnDuration);
            this.listViewReports.AllColumns.Add(this.olvColumnRunner);
            this.listViewReports.AllColumns.Add(this.olvColumnAge);
            this.listViewReports.CellEditUseWholeCell = false;
            this.listViewReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnDate,
            this.olvColumnDuration,
            this.olvColumnRunner,
            this.olvColumnAge});
            this.listViewReports.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReports.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewReports.FullRowSelect = true;
            this.listViewReports.HasCollapsibleGroups = false;
            this.listViewReports.Location = new System.Drawing.Point(3, 41);
            this.listViewReports.MultiSelect = false;
            this.listViewReports.Name = "listViewReports";
            this.listViewReports.Size = new System.Drawing.Size(657, 150);
            this.listViewReports.TabIndex = 6;
            this.listViewReports.UseCompatibleStateImageBehavior = false;
            this.listViewReports.View = System.Windows.Forms.View.Details;
            this.listViewReports.SelectedIndexChanged += new System.EventHandler(this.listViewReports_SelectedIndexChanged);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Task.Name";
            this.olvColumnName.FillsFreeSpace = true;
            this.olvColumnName.MinimumWidth = 50;
            this.olvColumnName.Text = "Task Name";
            this.olvColumnName.UseInitialLetterForGroup = true;
            // 
            // olvColumnDate
            // 
            this.olvColumnDate.AspectName = "Task.LastCompletionTimeAsText";
            this.olvColumnDate.FillsFreeSpace = true;
            this.olvColumnDate.MinimumWidth = 50;
            this.olvColumnDate.Text = "Completed";
            // 
            // olvColumnDuration
            // 
            this.olvColumnDuration.AspectName = "Task.DurationAsText";
            this.olvColumnDuration.FillsFreeSpace = true;
            this.olvColumnDuration.MinimumWidth = 50;
            this.olvColumnDuration.Text = "Duration";
            // 
            // olvColumnRunner
            // 
            this.olvColumnRunner.AspectName = "Task.LastRunOwner";
            this.olvColumnRunner.FillsFreeSpace = true;
            this.olvColumnRunner.MinimumWidth = 50;
            this.olvColumnRunner.Text = "Run By";
            // 
            // olvColumnAge
            // 
            this.olvColumnAge.AspectName = "AgeAsText";
            this.olvColumnAge.FillsFreeSpace = true;
            this.olvColumnAge.MinimumWidth = 50;
            this.olvColumnAge.Text = "Age";
            // 
            // toolStripReports
            // 
            this.toolStripReports.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripReports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPrint,
            this.toolStripButtonPrintPreview,
            this.toolStripSeparator2,
            this.toolStripButtonDelete,
            this.toolStripButtonSave});
            this.toolStripReports.Location = new System.Drawing.Point(3, 16);
            this.toolStripReports.Name = "toolStripReports";
            this.toolStripReports.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripReports.Size = new System.Drawing.Size(657, 25);
            this.toolStripReports.TabIndex = 5;
            this.toolStripReports.Text = "toolStrip1";
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.Enabled = false;
            this.toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrint.Image")));
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonPrint.Text = "Print";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // toolStripButtonPrintPreview
            // 
            this.toolStripButtonPrintPreview.Enabled = false;
            this.toolStripButtonPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrintPreview.Image")));
            this.toolStripButtonPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrintPreview.Name = "toolStripButtonPrintPreview";
            this.toolStripButtonPrintPreview.Size = new System.Drawing.Size(96, 22);
            this.toolStripButtonPrintPreview.Text = "Print Preview";
            this.toolStripButtonPrintPreview.Click += new System.EventHandler(this.toolStripButtonPrintPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click_1);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(121, 22);
            this.toolStripButtonSave.Text = "Save as Web Page";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonBrowser_Click);
            // 
            // statusStripReports
            // 
            this.statusStripReports.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount,
            this.toolStripStatusLabelSpacer});
            this.statusStripReports.Location = new System.Drawing.Point(0, 599);
            this.statusStripReports.Name = "statusStripReports";
            this.statusStripReports.Size = new System.Drawing.Size(684, 22);
            this.statusStripReports.TabIndex = 2;
            this.statusStripReports.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelCount.Text = "Ready";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(630, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.webBrowserReport);
            this.groupBox1.Location = new System.Drawing.Point(12, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 323);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Contents";
            // 
            // webBrowserReport
            // 
            this.webBrowserReport.AllowWebBrowserDrop = false;
            this.webBrowserReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserReport.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserReport.Location = new System.Drawing.Point(3, 16);
            this.webBrowserReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserReport.Name = "webBrowserReport";
            this.webBrowserReport.ScriptErrorsSuppressed = true;
            this.webBrowserReport.Size = new System.Drawing.Size(657, 304);
            this.webBrowserReport.TabIndex = 2;
            this.webBrowserReport.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserReport.WebBrowserShortcutsEnabled = false;
            // 
            // saveFileDialogReport
            // 
            this.saveFileDialogReport.DefaultExt = "html";
            this.saveFileDialogReport.FileName = "report.html";
            this.saveFileDialogReport.Title = "Save as Web Page";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(609, 30);
            this.label2.TabIndex = 53;
            this.label2.Text = "A report is produced each time a scan task completes. Reports contain information" +
    " about the scan and details of any detected items.";
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
            this.labelHeader.Size = new System.Drawing.Size(123, 21);
            this.labelHeader.TabIndex = 52;
            this.labelHeader.Text = "Report Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // TaskReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 621);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStripReports);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 660);
            this.Name = "TaskReports";
            this.Text = "Report Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskReports_FormClosing);
            this.Load += new System.EventHandler(this.TaskReports_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listViewReports)).EndInit();
            this.toolStripReports.ResumeLayout(false);
            this.toolStripReports.PerformLayout();
            this.statusStripReports.ResumeLayout(false);
            this.statusStripReports.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStripReports;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowserReport;
        private System.Windows.Forms.ToolStrip toolStripReports;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrintPreview;
        private System.Windows.Forms.SaveFileDialog saveFileDialogReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BrightIdeasSoftware.ObjectListView listViewReports;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnDate;
        private BrightIdeasSoftware.OLVColumn olvColumnDuration;
        private BrightIdeasSoftware.OLVColumn olvColumnRunner;
        private BrightIdeasSoftware.OLVColumn olvColumnAge;
    }
}