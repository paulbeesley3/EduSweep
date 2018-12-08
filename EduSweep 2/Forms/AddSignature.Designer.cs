namespace EduSweep_2.Forms
{
    partial class AddSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSignature));
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonBuiltin = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.comboBoxSignatures = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDetectionCount = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Signatures are ready-to-use lists of detectable items that you can quickly add to" +
    " your task.";
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
            this.labelHeader.Size = new System.Drawing.Size(134, 21);
            this.labelHeader.TabIndex = 49;
            this.labelHeader.Text = "Select a Signature";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(315, 268);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(107, 23);
            this.buttonClose.TabIndex = 53;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(202, 268);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(107, 23);
            this.buttonAdd.TabIndex = 54;
            this.buttonAdd.Text = "Add to Task";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonCustom);
            this.groupBox1.Controls.Add(this.radioButtonBuiltin);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Controls.Add(this.comboBoxSignatures);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 75);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Signatures";
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(111, 46);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(60, 17);
            this.radioButtonCustom.TabIndex = 55;
            this.radioButtonCustom.Text = "Custom";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.radioButtonCustom_CheckedChanged);
            // 
            // radioButtonBuiltin
            // 
            this.radioButtonBuiltin.AutoSize = true;
            this.radioButtonBuiltin.Location = new System.Drawing.Point(48, 46);
            this.radioButtonBuiltin.Name = "radioButtonBuiltin";
            this.radioButtonBuiltin.Size = new System.Drawing.Size(57, 17);
            this.radioButtonBuiltin.TabIndex = 54;
            this.radioButtonBuiltin.Text = "Built-In";
            this.radioButtonBuiltin.UseVisualStyleBackColor = true;
            this.radioButtonBuiltin.CheckedChanged += new System.EventHandler(this.radioButtonBuiltin_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(6, 46);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAll.TabIndex = 53;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // comboBoxSignatures
            // 
            this.comboBoxSignatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSignatures.FormattingEnabled = true;
            this.comboBoxSignatures.Location = new System.Drawing.Point(6, 19);
            this.comboBoxSignatures.Name = "comboBoxSignatures";
            this.comboBoxSignatures.Size = new System.Drawing.Size(398, 21);
            this.comboBoxSignatures.Sorted = true;
            this.comboBoxSignatures.TabIndex = 52;
            this.comboBoxSignatures.SelectedIndexChanged += new System.EventHandler(this.comboBoxSignatures_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDetectionCount);
            this.groupBox2.Controls.Add(this.textBoxDescription);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 115);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // labelDetectionCount
            // 
            this.labelDetectionCount.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelDetectionCount.Location = new System.Drawing.Point(6, 93);
            this.labelDetectionCount.Name = "labelDetectionCount";
            this.labelDetectionCount.Size = new System.Drawing.Size(398, 19);
            this.labelDetectionCount.TabIndex = 54;
            this.labelDetectionCount.Text = "Element Count";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDescription.Location = new System.Drawing.Point(6, 19);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(398, 71);
            this.textBoxDescription.TabIndex = 0;
            // 
            // AddSignature
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(436, 304);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSignature";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signature Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddSignature_FormClosed);
            this.Load += new System.EventHandler(this.AddSignature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSignatures;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDetectionCount;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.RadioButton radioButtonBuiltin;
        private System.Windows.Forms.RadioButton radioButtonAll;
    }
}