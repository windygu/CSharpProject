using System;
using System.Windows.Forms;

namespace Whats.UpdaterClient
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            try
            {
                if (Runtime.Updater.HasNewVersion)
                {
                    if (MessageBox.Show("有新版本，是否立即更新！", "更新提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    else
                        this.Close();
                }
                else
                {
                    if (Environment.GetCommandLineArgs() == null || Environment.GetCommandLineArgs().Length <= 0)
                        MessageBox.Show("已经是最新版本！");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("软件版本更新检测失败，请检查是否连接互联网！");
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确定您已经备份数据！是否立即更新？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                Runtime.Updater.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show("更新失败！请检查网络连接或者请联系软件作者！");
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
