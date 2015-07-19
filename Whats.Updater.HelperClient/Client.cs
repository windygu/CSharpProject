using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whats.Updater;

namespace Updater.HelperClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            updater.Config.Domain = "http://localhost:9999";
        }
        Whats.Updater.Updater updater = new Whats.Updater.Updater();
        private void btnCreate_Click(object sender, EventArgs e)
        {   
            updater.Config.RemoteUrl = this.txtRemoteUrl.Text;
            updater.Config.LocalDir = this.txtLocaDir.Text;
            updater.CreateNewVersionDescription(this.txtLocaDir.Text + "/update/version.json");
            MessageBox.Show("操作成功！");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            this.txtLocaDir.Text = open.SelectedPath;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updater.Config.RemoteUrl = this.txtRemoteUrl.Text;
            updater.Update();
            MessageBox.Show("操作成功！");
        }

        private void btnBrowserUpdate_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            this.txtRemoteUrl.Text = open.FileName;
        }

        private void btnLocalUpdate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            this.txtLocalUpdate.Text = open.SelectedPath;
        }
    }
}
