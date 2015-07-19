using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.DataBackupClient
{
    public partial class LocalDataBackup : Form
    {
        public LocalDataBackup()
        {
            InitializeComponent();
        }

        private void DataBackUpForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(this.txtBackUpDir.Text + "db_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".dbb");
            if (!file.Directory.Exists)
                Directory.CreateDirectory(file.Directory.FullName);

            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "db.db", file.FullName, false);
        }

        private void btnBrowserBackUpDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            this.txtBackUpDir.Text = open.SelectedPath;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "db.db", save.FileName, false);
        }

        private void btnCloud_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请联系软件作者！");
        }

    }
}
