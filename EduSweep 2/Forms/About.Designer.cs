namespace EduSweep_2.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxLicenseInfo = new System.Windows.Forms.GroupBox();
            this.richTextBoxCredits = new System.Windows.Forms.RichTextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxVersions = new System.Windows.Forms.GroupBox();
            this.listViewVersions = new System.Windows.Forms.ListView();
            this.columnHeaderComponent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxLicenseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBoxVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(12, 513);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(570, 25);
            this.buttonClose.TabIndex = 63;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // groupBoxLicenseInfo
            // 
            this.groupBoxLicenseInfo.Controls.Add(this.richTextBoxCredits);
            this.groupBoxLicenseInfo.Location = new System.Drawing.Point(12, 321);
            this.groupBoxLicenseInfo.Name = "groupBoxLicenseInfo";
            this.groupBoxLicenseInfo.Size = new System.Drawing.Size(570, 186);
            this.groupBoxLicenseInfo.TabIndex = 65;
            this.groupBoxLicenseInfo.TabStop = false;
            this.groupBoxLicenseInfo.Text = "Credits and License Information";
            // 
            // richTextBoxCredits
            // 
            this.richTextBoxCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCredits.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxCredits.Name = "richTextBoxCredits";
            this.richTextBoxCredits.ReadOnly = true;
            this.richTextBoxCredits.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxCredits.ShortcutsEnabled = false;
            this.richTextBoxCredits.Size = new System.Drawing.Size(564, 167);
            this.richTextBoxCredits.TabIndex = 0;
            this.richTextBoxCredits.Text = resources.GetString("richTextBoxCredits.Text");
            this.richTextBoxCredits.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxCredits_LinkClicked);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(594, 194);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 66;
            this.pictureBoxLogo.TabStop = false;
            // 
            // groupBoxVersions
            // 
            this.groupBoxVersions.Controls.Add(this.listViewVersions);
            this.groupBoxVersions.Location = new System.Drawing.Point(12, 200);
            this.groupBoxVersions.Name = "groupBoxVersions";
            this.groupBoxVersions.Size = new System.Drawing.Size(570, 115);
            this.groupBoxVersions.TabIndex = 67;
            this.groupBoxVersions.TabStop = false;
            this.groupBoxVersions.Text = "Versions";
            // 
            // listViewVersions
            // 
            this.listViewVersions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderComponent,
            this.columnHeaderVersion});
            this.listViewVersions.FullRowSelect = true;
            this.listViewVersions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewVersions.Location = new System.Drawing.Point(6, 19);
            this.listViewVersions.MultiSelect = false;
            this.listViewVersions.Name = "listViewVersions";
            this.listViewVersions.Scrollable = false;
            this.listViewVersions.Size = new System.Drawing.Size(558, 90);
            this.listViewVersions.TabIndex = 0;
            this.listViewVersions.UseCompatibleStateImageBehavior = false;
            this.listViewVersions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderComponent
            // 
            this.columnHeaderComponent.Text = "Component";
            this.columnHeaderComponent.Width = 454;
            // 
            // columnHeaderVersion
            // 
            this.columnHeaderVersion.Text = "Version";
            this.columnHeaderVersion.Width = 97;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(594, 546);
            this.Controls.Add(this.groupBoxVersions);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBoxLicenseInfo);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.groupBoxLicenseInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxVersions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxLicenseInfo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.GroupBox groupBoxVersions;
        private System.Windows.Forms.ListView listViewVersions;
        private System.Windows.Forms.ColumnHeader columnHeaderComponent;
        private System.Windows.Forms.ColumnHeader columnHeaderVersion;
        private System.Windows.Forms.RichTextBox richTextBoxCredits;
    }
}