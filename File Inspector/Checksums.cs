using System;
using System.Drawing;
using System.Windows.Forms;
using EdUtils.Filesystem;

namespace File_Inspector
{
    public partial class Checksums : Form
    {
        private FileItem fileItem;

        public Checksums(FileItem fileItem)
        {
            InitializeComponent();
            this.fileItem = fileItem;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Marquee;
            buttonCalculate.Enabled = false;
            buttonCopy.Enabled = false;
            buttonClose.Enabled = false;
            labelSum.Text = "Calculating checksum. One moment, please...";
            labelSum.ForeColor = SystemColors.ControlDark;

            backgroundWorkerSum.RunWorkerAsync();
        }

        private void backgroundWorkerSum_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string result = "Error while calculating hash sum.";

            if (radioButtonCRC32.Checked)
            {
                result = EdUtils.Helpers.Checksums.GetChecksumFromFile(fileItem, EdUtils.Helpers.Checksums.ChecksumType.CRC32);
            }

            if (radioButtonMD5.Checked)
            {
                result = EdUtils.Helpers.Checksums.GetChecksumFromFile(fileItem, EdUtils.Helpers.Checksums.ChecksumType.MD5);
            }

            if (radioButtonSHA1.Checked)
            {
                result = EdUtils.Helpers.Checksums.GetChecksumFromFile(fileItem, EdUtils.Helpers.Checksums.ChecksumType.SHA1);
            }

            e.Result = result;
        }

        private void backgroundWorkerSum_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            if (e.Result != null)
            {
                labelSum.Text = (string)e.Result;
                labelSum.Text = labelSum.Text.ToUpper();
                labelSum.ForeColor = SystemColors.ControlText;
            }
            else
            {
                labelSum.Text = "Checksum Failed. Is the file readable?";
                labelSum.ForeColor = SystemColors.ControlDark;
            }
            
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
            buttonCalculate.Enabled = true;
            buttonClose.Enabled = true;
            buttonCopy.Enabled = true;
            labelSum.Enabled = true;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelSum.Text);
        }
    }
}
