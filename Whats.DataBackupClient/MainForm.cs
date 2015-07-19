using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cleaner.Core;

namespace Whats.DataBackupClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("软件名称：freeroo数据安全管理软件");
            sb.AppendLine("软件作者：卢杰杰");
            sb.AppendLine("软件版本：1.0.0");
            sb.AppendLine("官方网站：freeroo.software");
            MessageBox.Show(sb.ToString());
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("此功能为高级功能，请联系软件作者进行帮助操作！");
            sb.AppendLine("您在使用本软件的过程中可能遇到数据丢失误删数据库等操作");
            sb.AppendLine("此功能可以恢复您的备份数据，前提是您已经进行过备份！");
            sb.AppendLine("如果硬盘损坏或者是重装系统导致数据丢失");
            sb.AppendLine("您一定要有云备份或者曾经导出过本地备份才能恢复数据！");
            MessageBox.Show(sb.ToString());
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            try
            {
                var drives = DriveInfo.GetDrives();
                foreach (var item in drives)
                {
                    if (item.DriveType == DriveType.Fixed)
                    {
                        if (item.Name.IndexOf("d:") > -1)
                        {
                            DirectoryInfo info = new DirectoryInfo("D:/CLEANERDATA/");
                            if (!info.Exists)
                                Directory.CreateDirectory(info.FullName);
                            File.SetAttributes(info.FullName, FileAttributes.Hidden);
                            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "db.db",
                                info.FullName + "db_" + Environment.MachineName + "_" +
                                Roo.Utils.StringBuilderHelper.GenerateStringID() + ".dbb");
                        }
                    }
                }
                MessageBox.Show("备份成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("备份失败，请联系软件作者！");
            }
            
        }

        private void btnCloud_Click(object sender, EventArgs e)
        {
            try
            {
                QiNiuBackupHelper.Backup();
                MessageBox.Show("云备份成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("云备份需要网络通畅，请确定您已经连接到互联网！");
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnLocalAdvanced_Click(object sender, EventArgs e)
        {

        }

        private void btnCloudAdvanced_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs() != null && Environment.GetCommandLineArgs().Length > 1)
            {
                if (Environment.GetCommandLineArgs()[1] == "auto")
                {
                    AutoBackup();
                }
            }
        }
        void AutoBackup()
        {
            try
            {
                QiNiuBackupHelper.Backup();
                MessageBox.Show("自动云备份成功！");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("云备份需要网络通畅，请确定您已经连接到互联网！");
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }
    }
}
