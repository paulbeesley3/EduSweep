namespace EduSweep_2.Forms
{
    partial class ProgramSettings
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
                clamServerTestCancelToken.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramSettings));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageQuarantine = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelQuarantineSize = new System.Windows.Forms.Label();
            this.labelQuarantineCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.progressBarQuarantinePurge = new System.Windows.Forms.ProgressBar();
            this.buttonPurgeQuarantine = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkBoxQuarantineCleanup = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.quarantineAgeLimit = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.labelReportSize = new System.Windows.Forms.Label();
            this.labelReportCount = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.progressBarReportsPurge = new System.Windows.Forms.ProgressBar();
            this.buttonPurgeReports = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxReportCleanup = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.reportAgeLimit = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPageVirus = new System.Windows.Forms.TabPage();
            this.groupBoxServerTest = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServerPing = new System.Windows.Forms.TextBox();
            this.labelConnectionTest = new System.Windows.Forms.Label();
            this.buttonServerTest = new System.Windows.Forms.Button();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableClamAV = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownServerPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageLogging = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxLogLevel = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPageLanguage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialogDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorkerPurge = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tabPageQuarantine.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quarantineAgeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportAgeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPageVirus.SuspendLayout();
            this.groupBoxServerTest.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServerPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageLogging.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPageLanguage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(317, 375);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSave.Location = new System.Drawing.Point(236, 375);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageQuarantine);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageVirus);
            this.tabControl.Controls.Add(this.tabPageLogging);
            this.tabControl.Controls.Add(this.tabPageLanguage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(381, 357);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageQuarantine
            // 
            this.tabPageQuarantine.Controls.Add(this.groupBox3);
            this.tabPageQuarantine.Controls.Add(this.groupBox9);
            this.tabPageQuarantine.Controls.Add(this.label13);
            this.tabPageQuarantine.Controls.Add(this.label14);
            this.tabPageQuarantine.Controls.Add(this.pictureBox4);
            this.tabPageQuarantine.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuarantine.Name = "tabPageQuarantine";
            this.tabPageQuarantine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuarantine.Size = new System.Drawing.Size(373, 331);
            this.tabPageQuarantine.TabIndex = 4;
            this.tabPageQuarantine.Text = "Quarantine";
            this.tabPageQuarantine.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelQuarantineSize);
            this.groupBox3.Controls.Add(this.labelQuarantineCount);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.progressBarQuarantinePurge);
            this.groupBox3.Controls.Add(this.buttonPurgeQuarantine);
            this.groupBox3.Location = new System.Drawing.Point(6, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 158);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual Cleanup";
            // 
            // labelQuarantineSize
            // 
            this.labelQuarantineSize.AutoSize = true;
            this.labelQuarantineSize.Location = new System.Drawing.Point(7, 82);
            this.labelQuarantineSize.Name = "labelQuarantineSize";
            this.labelQuarantineSize.Size = new System.Drawing.Size(211, 13);
            this.labelQuarantineSize.TabIndex = 63;
            this.labelQuarantineSize.Text = "0.0MB of space is being used by these files";
            // 
            // labelQuarantineCount
            // 
            this.labelQuarantineCount.AutoSize = true;
            this.labelQuarantineCount.Location = new System.Drawing.Point(7, 56);
            this.labelQuarantineCount.Name = "labelQuarantineCount";
            this.labelQuarantineCount.Size = new System.Drawing.Size(147, 13);
            this.labelQuarantineCount.TabIndex = 62;
            this.labelQuarantineCount.Text = "0 items currently in quarantine";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(345, 40);
            this.label20.TabIndex = 61;
            this.label20.Text = "The quarantine folder can be emptied from here. This will remove all quarantine i" +
    "tems, regardless of their age.";
            // 
            // progressBarQuarantinePurge
            // 
            this.progressBarQuarantinePurge.Location = new System.Drawing.Point(6, 110);
            this.progressBarQuarantinePurge.Name = "progressBarQuarantinePurge";
            this.progressBarQuarantinePurge.Size = new System.Drawing.Size(345, 13);
            this.progressBarQuarantinePurge.TabIndex = 1;
            // 
            // buttonPurgeQuarantine
            // 
            this.buttonPurgeQuarantine.Location = new System.Drawing.Point(6, 129);
            this.buttonPurgeQuarantine.Name = "buttonPurgeQuarantine";
            this.buttonPurgeQuarantine.Size = new System.Drawing.Size(347, 23);
            this.buttonPurgeQuarantine.TabIndex = 9;
            this.buttonPurgeQuarantine.Text = "Empty Quarantine";
            this.buttonPurgeQuarantine.UseVisualStyleBackColor = true;
            this.buttonPurgeQuarantine.Click += new System.EventHandler(this.buttonPurgeQuarantine_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.checkBoxQuarantineCleanup);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.quarantineAgeLimit);
            this.groupBox9.Location = new System.Drawing.Point(6, 65);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(361, 96);
            this.groupBox9.TabIndex = 61;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Automatic Cleanup";
            // 
            // checkBoxQuarantineCleanup
            // 
            this.checkBoxQuarantineCleanup.AutoSize = true;
            this.checkBoxQuarantineCleanup.Location = new System.Drawing.Point(6, 27);
            this.checkBoxQuarantineCleanup.Name = "checkBoxQuarantineCleanup";
            this.checkBoxQuarantineCleanup.Size = new System.Drawing.Size(223, 17);
            this.checkBoxQuarantineCleanup.TabIndex = 7;
            this.checkBoxQuarantineCleanup.Text = "Clear out old quarantine files automatically";
            this.checkBoxQuarantineCleanup.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Maximum File Age (Days)";
            // 
            // quarantineAgeLimit
            // 
            this.quarantineAgeLimit.Location = new System.Drawing.Point(6, 70);
            this.quarantineAgeLimit.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.quarantineAgeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quarantineAgeLimit.Name = "quarantineAgeLimit";
            this.quarantineAgeLimit.Size = new System.Drawing.Size(347, 20);
            this.quarantineAgeLimit.TabIndex = 8;
            this.quarantineAgeLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(63, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(310, 32);
            this.label13.TabIndex = 60;
            this.label13.Text = "Files in quarantine can be removed automatically after a certain period.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label14.Location = new System.Drawing.Point(62, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(184, 21);
            this.label14.TabIndex = 59;
            this.label14.Text = "Quarantine Management";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(8, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.TabIndex = 58;
            this.pictureBox4.TabStop = false;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.groupBox11);
            this.tabPageReports.Controls.Add(this.groupBox2);
            this.tabPageReports.Controls.Add(this.label9);
            this.tabPageReports.Controls.Add(this.label10);
            this.tabPageReports.Controls.Add(this.pictureBox3);
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(373, 331);
            this.tabPageReports.TabIndex = 3;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.labelReportSize);
            this.groupBox11.Controls.Add(this.labelReportCount);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Controls.Add(this.progressBarReportsPurge);
            this.groupBox11.Controls.Add(this.buttonPurgeReports);
            this.groupBox11.Location = new System.Drawing.Point(6, 167);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(361, 158);
            this.groupBox11.TabIndex = 63;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Manual Cleanup";
            // 
            // labelReportSize
            // 
            this.labelReportSize.AutoSize = true;
            this.labelReportSize.Location = new System.Drawing.Point(7, 82);
            this.labelReportSize.Name = "labelReportSize";
            this.labelReportSize.Size = new System.Drawing.Size(211, 13);
            this.labelReportSize.TabIndex = 63;
            this.labelReportSize.Text = "0.0MB of space is being used by these files";
            // 
            // labelReportCount
            // 
            this.labelReportCount.AutoSize = true;
            this.labelReportCount.Location = new System.Drawing.Point(7, 56);
            this.labelReportCount.Name = "labelReportCount";
            this.labelReportCount.Size = new System.Drawing.Size(141, 13);
            this.labelReportCount.TabIndex = 62;
            this.labelReportCount.Text = "0 reports are currently stored";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(345, 40);
            this.label31.TabIndex = 61;
            this.label31.Text = "The reports folder can be emptied from here. This will remove all reports, regard" +
    "less of their age.";
            // 
            // progressBarReportsPurge
            // 
            this.progressBarReportsPurge.Location = new System.Drawing.Point(6, 110);
            this.progressBarReportsPurge.Name = "progressBarReportsPurge";
            this.progressBarReportsPurge.Size = new System.Drawing.Size(345, 13);
            this.progressBarReportsPurge.TabIndex = 1;
            // 
            // buttonPurgeReports
            // 
            this.buttonPurgeReports.Location = new System.Drawing.Point(6, 129);
            this.buttonPurgeReports.Name = "buttonPurgeReports";
            this.buttonPurgeReports.Size = new System.Drawing.Size(347, 23);
            this.buttonPurgeReports.TabIndex = 12;
            this.buttonPurgeReports.Text = "Remove All Reports";
            this.buttonPurgeReports.UseVisualStyleBackColor = true;
            this.buttonPurgeReports.Click += new System.EventHandler(this.buttonPurgeReports_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxReportCleanup);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.reportAgeLimit);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 96);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automatic Cleanup";
            // 
            // checkBoxReportCleanup
            // 
            this.checkBoxReportCleanup.AutoSize = true;
            this.checkBoxReportCleanup.Location = new System.Drawing.Point(6, 27);
            this.checkBoxReportCleanup.Name = "checkBoxReportCleanup";
            this.checkBoxReportCleanup.Size = new System.Drawing.Size(184, 17);
            this.checkBoxReportCleanup.TabIndex = 10;
            this.checkBoxReportCleanup.Text = "Clear out old reports automatically";
            this.checkBoxReportCleanup.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Maximum Report Age (Days)";
            // 
            // reportAgeLimit
            // 
            this.reportAgeLimit.Location = new System.Drawing.Point(6, 70);
            this.reportAgeLimit.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.reportAgeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reportAgeLimit.Name = "reportAgeLimit";
            this.reportAgeLimit.Size = new System.Drawing.Size(347, 20);
            this.reportAgeLimit.TabIndex = 11;
            this.reportAgeLimit.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(63, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 32);
            this.label9.TabIndex = 55;
            this.label9.Text = "Reports are created after each task completes and can be removed automatically af" +
    "ter a certain period.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label10.Location = new System.Drawing.Point(62, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 21);
            this.label10.TabIndex = 54;
            this.label10.Text = "Report Management";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 53;
            this.pictureBox3.TabStop = false;
            // 
            // tabPageVirus
            // 
            this.tabPageVirus.Controls.Add(this.groupBoxServerTest);
            this.tabPageVirus.Controls.Add(this.groupBoxServer);
            this.tabPageVirus.Controls.Add(this.label5);
            this.tabPageVirus.Controls.Add(this.label6);
            this.tabPageVirus.Controls.Add(this.pictureBox1);
            this.tabPageVirus.Location = new System.Drawing.Point(4, 22);
            this.tabPageVirus.Name = "tabPageVirus";
            this.tabPageVirus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVirus.Size = new System.Drawing.Size(373, 331);
            this.tabPageVirus.TabIndex = 5;
            this.tabPageVirus.Text = "Antivirus";
            this.tabPageVirus.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerTest
            // 
            this.groupBoxServerTest.Controls.Add(this.label1);
            this.groupBoxServerTest.Controls.Add(this.textBoxServerPing);
            this.groupBoxServerTest.Controls.Add(this.labelConnectionTest);
            this.groupBoxServerTest.Controls.Add(this.buttonServerTest);
            this.groupBoxServerTest.Location = new System.Drawing.Point(6, 169);
            this.groupBoxServerTest.Name = "groupBoxServerTest";
            this.groupBoxServerTest.Size = new System.Drawing.Size(361, 156);
            this.groupBoxServerTest.TabIndex = 67;
            this.groupBoxServerTest.TabStop = false;
            this.groupBoxServerTest.Text = "Connection Test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Test Result";
            // 
            // textBoxServerPing
            // 
            this.textBoxServerPing.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxServerPing.Location = new System.Drawing.Point(6, 79);
            this.textBoxServerPing.Name = "textBoxServerPing";
            this.textBoxServerPing.ReadOnly = true;
            this.textBoxServerPing.Size = new System.Drawing.Size(347, 20);
            this.textBoxServerPing.TabIndex = 62;
            // 
            // labelConnectionTest
            // 
            this.labelConnectionTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionTest.Location = new System.Drawing.Point(6, 16);
            this.labelConnectionTest.Name = "labelConnectionTest";
            this.labelConnectionTest.Size = new System.Drawing.Size(345, 34);
            this.labelConnectionTest.TabIndex = 61;
            this.labelConnectionTest.Text = "Performs a check of the server settings by attempting to connect to a ClamAV serv" +
    "er and retrieve its version information.";
            // 
            // buttonServerTest
            // 
            this.buttonServerTest.Location = new System.Drawing.Point(6, 105);
            this.buttonServerTest.Name = "buttonServerTest";
            this.buttonServerTest.Size = new System.Drawing.Size(347, 23);
            this.buttonServerTest.TabIndex = 9;
            this.buttonServerTest.Text = "Test Connection";
            this.buttonServerTest.UseVisualStyleBackColor = true;
            this.buttonServerTest.Click += new System.EventHandler(this.buttonServerTest_Click);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.checkBoxEnableClamAV);
            this.groupBoxServer.Controls.Add(this.label7);
            this.groupBoxServer.Controls.Add(this.textBoxServer);
            this.groupBoxServer.Controls.Add(this.label4);
            this.groupBoxServer.Controls.Add(this.numericUpDownServerPort);
            this.groupBoxServer.Location = new System.Drawing.Point(6, 65);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(361, 98);
            this.groupBoxServer.TabIndex = 66;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Clamd Server";
            // 
            // checkBoxEnableClamAV
            // 
            this.checkBoxEnableClamAV.AutoSize = true;
            this.checkBoxEnableClamAV.Location = new System.Drawing.Point(9, 22);
            this.checkBoxEnableClamAV.Name = "checkBoxEnableClamAV";
            this.checkBoxEnableClamAV.Size = new System.Drawing.Size(193, 17);
            this.checkBoxEnableClamAV.TabIndex = 40;
            this.checkBoxEnableClamAV.Text = "Enable ClamAV antivirus integration";
            this.checkBoxEnableClamAV.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "IP Address / Hostname";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(9, 65);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(262, 20);
            this.textBoxServer.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Port";
            // 
            // numericUpDownServerPort
            // 
            this.numericUpDownServerPort.Location = new System.Drawing.Point(277, 65);
            this.numericUpDownServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownServerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownServerPort.Name = "numericUpDownServerPort";
            this.numericUpDownServerPort.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownServerPort.TabIndex = 8;
            this.numericUpDownServerPort.Value = new decimal(new int[] {
            3310,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 32);
            this.label5.TabIndex = 65;
            this.label5.Text = "Connect to a ClamAV (clamd) server to enable support for virus scanning on detect" +
    "ed files.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label6.Location = new System.Drawing.Point(62, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 21);
            this.label6.TabIndex = 64;
            this.label6.Text = "Antivirus Integration";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // tabPageLogging
            // 
            this.tabPageLogging.Controls.Add(this.groupBox1);
            this.tabPageLogging.Controls.Add(this.label3);
            this.tabPageLogging.Controls.Add(this.label8);
            this.tabPageLogging.Controls.Add(this.pictureBox2);
            this.tabPageLogging.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogging.Name = "tabPageLogging";
            this.tabPageLogging.Size = new System.Drawing.Size(373, 331);
            this.tabPageLogging.TabIndex = 7;
            this.tabPageLogging.Text = "Logging";
            this.tabPageLogging.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxLogLevel);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(6, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 138);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging Level";
            // 
            // comboBoxLogLevel
            // 
            this.comboBoxLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogLevel.FormattingEnabled = true;
            this.comboBoxLogLevel.Items.AddRange(new object[] {
            "Minimal",
            "Standard (Recommended)",
            "Enhanced"});
            this.comboBoxLogLevel.Location = new System.Drawing.Point(6, 111);
            this.comboBoxLogLevel.Name = "comboBoxLogLevel";
            this.comboBoxLogLevel.Size = new System.Drawing.Size(349, 21);
            this.comboBoxLogLevel.TabIndex = 63;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(347, 92);
            this.label17.TabIndex = 62;
            this.label17.Text = resources.GetString("label17.Text");
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 32);
            this.label3.TabIndex = 63;
            this.label3.Text = "Adjust the granularity of events logged by the application and scan engine.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label8.Location = new System.Drawing.Point(62, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 21);
            this.label8.TabIndex = 62;
            this.label8.Text = "Logging and Instrumentation";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // tabPageLanguage
            // 
            this.tabPageLanguage.Controls.Add(this.groupBox4);
            this.tabPageLanguage.Controls.Add(this.label15);
            this.tabPageLanguage.Controls.Add(this.label16);
            this.tabPageLanguage.Controls.Add(this.pictureBox5);
            this.tabPageLanguage.Location = new System.Drawing.Point(4, 22);
            this.tabPageLanguage.Name = "tabPageLanguage";
            this.tabPageLanguage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLanguage.Size = new System.Drawing.Size(373, 331);
            this.tabPageLanguage.TabIndex = 6;
            this.tabPageLanguage.Text = "Language";
            this.tabPageLanguage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.comboBoxLanguage);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(6, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 104);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Language";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(345, 23);
            this.label18.TabIndex = 64;
            this.label18.Text = "Additional languages coming soon.\r\n";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English (British)"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(6, 54);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(349, 21);
            this.comboBoxLanguage.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 35);
            this.label2.TabIndex = 62;
            this.label2.Text = "Choose your preferred language that will be used for displaying text throughout t" +
    "he application.";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(63, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(304, 32);
            this.label15.TabIndex = 63;
            this.label15.Text = "Customise EduSweep to suit your language and international preferences.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label16.Location = new System.Drawing.Point(62, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(200, 21);
            this.label16.TabIndex = 62;
            this.label16.Text = "Language and International";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(8, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 48);
            this.pictureBox5.TabIndex = 61;
            this.pictureBox5.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(295, 17);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "Enable FeatherWeight Mode (Recommended for servers)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialogDirectory
            // 
            this.folderBrowserDialogDirectory.Description = "Please select the new directory.";
            this.folderBrowserDialogDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // imageListStatus
            // 
            this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
            this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStatus.Images.SetKeyName(0, "emblem-default.png");
            this.imageListStatus.Images.SetKeyName(1, "emblem-danger.png");
            // 
            // backgroundWorkerPurge
            // 
            this.backgroundWorkerPurge.WorkerReportsProgress = true;
            this.backgroundWorkerPurge.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPurge_DoWork);
            this.backgroundWorkerPurge.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPurge_ProgressChanged);
            this.backgroundWorkerPurge.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPurge_RunWorkerCompleted);
            // 
            // ProgramSettings
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(404, 407);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramSettings_FormClosing);
            this.Load += new System.EventHandler(this.ProgramSettings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageQuarantine.ResumeLayout(false);
            this.tabPageQuarantine.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quarantineAgeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportAgeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPageVirus.ResumeLayout(false);
            this.tabPageVirus.PerformLayout();
            this.groupBoxServerTest.ResumeLayout(false);
            this.groupBoxServerTest.PerformLayout();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServerPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageLogging.ResumeLayout(false);
            this.tabPageLogging.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPageLanguage.ResumeLayout(false);
            this.tabPageLanguage.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.NumericUpDown reportAgeLimit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPageQuarantine;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown quarantineAgeLimit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxReportCleanup;
        private System.Windows.Forms.CheckBox checkBoxQuarantineCleanup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDirectory;
        private System.Windows.Forms.ImageList imageListStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelQuarantineSize;
        private System.Windows.Forms.Label labelQuarantineCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ProgressBar progressBarQuarantinePurge;
        private System.Windows.Forms.Button buttonPurgeQuarantine;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label labelReportSize;
        private System.Windows.Forms.Label labelReportCount;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ProgressBar progressBarReportsPurge;
        private System.Windows.Forms.Button buttonPurgeReports;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPurge;
        private System.Windows.Forms.TabPage tabPageVirus;
        private System.Windows.Forms.GroupBox groupBoxServerTest;
        private System.Windows.Forms.Label labelConnectionTest;
        private System.Windows.Forms.Button buttonServerTest;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownServerPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServerPing;
        private System.Windows.Forms.TabPage tabPageLogging;
        private System.Windows.Forms.TabPage tabPageLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxLogLevel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBoxEnableClamAV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
    }
}