namespace File_Inspector
{
    partial class Checksums
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checksums));
            this.radioButtonCRC32 = new System.Windows.Forms.RadioButton();
            this.radioButtonMD5 = new System.Windows.Forms.RadioButton();
            this.radioButtonSHA1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerSum = new System.ComponentModel.BackgroundWorker();
            this.labelSum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonCRC32
            // 
            this.radioButtonCRC32.AutoSize = true;
            this.radioButtonCRC32.Location = new System.Drawing.Point(6, 79);
            this.radioButtonCRC32.Name = "radioButtonCRC32";
            this.radioButtonCRC32.Size = new System.Drawing.Size(59, 17);
            this.radioButtonCRC32.TabIndex = 2;
            this.radioButtonCRC32.Text = "CRC32";
            this.radioButtonCRC32.UseVisualStyleBackColor = true;
            // 
            // radioButtonMD5
            // 
            this.radioButtonMD5.AutoSize = true;
            this.radioButtonMD5.Checked = true;
            this.radioButtonMD5.Location = new System.Drawing.Point(71, 79);
            this.radioButtonMD5.Name = "radioButtonMD5";
            this.radioButtonMD5.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMD5.TabIndex = 3;
            this.radioButtonMD5.TabStop = true;
            this.radioButtonMD5.Text = "MD5";
            this.radioButtonMD5.UseVisualStyleBackColor = true;
            // 
            // radioButtonSHA1
            // 
            this.radioButtonSHA1.AutoSize = true;
            this.radioButtonSHA1.Location = new System.Drawing.Point(125, 79);
            this.radioButtonSHA1.Name = "radioButtonSHA1";
            this.radioButtonSHA1.Size = new System.Drawing.Size(53, 17);
            this.radioButtonSHA1.TabIndex = 4;
            this.radioButtonSHA1.Text = "SHA1";
            this.radioButtonSHA1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 33);
            this.label2.TabIndex = 58;
            this.label2.Text = "A checksum can be used to verify that the contents of a file are unchanged from w" +
                "hen its original checksum was created.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(66, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 21);
            this.label3.TabIndex = 57;
            this.label3.Text = "Create checksums for this file";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(343, 76);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(355, 178);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSum);
            this.groupBox1.Controls.Add(this.buttonCopy);
            this.groupBox1.Controls.Add(this.radioButtonMD5);
            this.groupBox1.Controls.Add(this.radioButtonCRC32);
            this.groupBox1.Controls.Add(this.radioButtonSHA1);
            this.groupBox1.Controls.Add(this.buttonCalculate);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 106);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Checksum";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Enabled = false;
            this.buttonCopy.Location = new System.Drawing.Point(262, 76);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 5;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 183);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(337, 13);
            this.progressBar.TabIndex = 60;
            // 
            // backgroundWorkerSum
            // 
            this.backgroundWorkerSum.WorkerSupportsCancellation = true;
            this.backgroundWorkerSum.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSum_DoWork);
            this.backgroundWorkerSum.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSum_RunWorkerCompleted);
            // 
            // labelSum
            // 
            this.labelSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSum.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSum.Location = new System.Drawing.Point(6, 26);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(412, 23);
            this.labelSum.TabIndex = 7;
            this.labelSum.Text = "Checksum will be displayed here";
            this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Checksums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 211);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Checksums";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Checksums";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonCRC32;
        private System.Windows.Forms.RadioButton radioButtonMD5;
        private System.Windows.Forms.RadioButton radioButtonSHA1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSum;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelSum;

    }
}