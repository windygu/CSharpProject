using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whats.Installer.CompileClient
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            this.txtInstruction.Text = Properties.Resources.Instruction;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (this.btnInstall.Text == "安装成功！")
                return;
            try
            {
                this.btnInstall.Text = "正在安装...";
                string installPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/Cleaner/";

                string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/CleanerData/";
                    if (!Directory.Exists(dataDir))
                        Directory.CreateDirectory(dataDir);

                if (!Directory.Exists(installPath))
                    Directory.CreateDirectory(installPath);
                else
                {
                    if (!File.Exists(dataDir + "db.db") && File.Exists(installPath + "db.db"))
                        File.Move(installPath + "db.db", dataDir + "db.db");

                    if (MessageBox.Show("已经安装了，是否覆盖安装！覆盖安装请确定您已经备份了数据！", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Helper.Kill();

                        Directory.Delete(installPath, true);
                        Directory.CreateDirectory(installPath);
                    }
                    else
                        this.Close();
                }
                File.WriteAllBytes(installPath + "install.tmp", Properties.Resources.File);
                UnZipHelper.UnZip(installPath + "install.tmp", installPath);
                
                File.Delete(installPath + "install.tmp");

                if (!File.Exists(dataDir + "db.db") && File.Exists(installPath + "db.db"))
                    File.Copy(installPath + "db.db", dataDir + "db.db");

                Shortcut sc = new Shortcut();
                sc.Path = installPath + "Cleaner.exe";
                sc.Arguments = "";
                sc.WorkingDirectory = installPath;
                sc.Description = "杰洁洗衣店管理软件";
                string lnkPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/杰洁洗衣店管理软件.lnk";
                if (File.Exists(lnkPath))
                    File.Delete(lnkPath);
                sc.Save(lnkPath);

                string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "/Cleaner/";
                if (!Directory.Exists(startMenuDir))
                    Directory.CreateDirectory(startMenuDir);

                File.Copy(lnkPath, startMenuDir + "/杰洁洗衣店管理软件.lnk", true);

                MessageBox.Show("安装成功！");
                this.btnInstall.Text = "安装成功！";
            }
            catch(Exception ex)
            {
                MessageBox.Show("安装失败！" + ex.Message + ex.StackTrace);
            }
            
        }
    }
}
