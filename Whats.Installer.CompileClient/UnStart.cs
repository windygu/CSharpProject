using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.Installer.CompileClient
{
    public partial class UnStart : Form
    {
        public UnStart()
        {
            InitializeComponent();
        }

        private void btnUnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确定要卸载吗？你的应用程序和数据都会被删除并且不可恢复！", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Helper.Kill();

                    string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "/Cleaner/";
                    if (Directory.Exists(startMenuDir))
                        Directory.Delete(startMenuDir, true);
                    string programDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/Cleaner/";
                    if (Directory.Exists(programDir))
                        Directory.Delete(programDir, true);
                    string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/CleanerData/";
                    if (Directory.Exists(dataDir))
                        Directory.Delete(dataDir, true);
                    MessageBox.Show("卸载成功！");
                }
                else
                    MessageBox.Show("结束卸载！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("卸载过程中出现错误！您可以联系作者手工卸载！" + ex.Message + ex.StackTrace);
            }
        }
    }
}
