using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;
using Roo.Data;

namespace NEWUCC
{
    public partial class UCC : Form
    {
        public UCC()
        {
            InitializeComponent();
        }

        private void btnShouYi_Click(object sender, EventArgs e)
        {
            ShouYiForm form = new ShouYiForm();
            form.ShowDialog();
        }

        private void btnQuYi_Click(object sender, EventArgs e)
        {
            ShouYiForm form = new ShouYiForm();
            form.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
        }

        private void btnChongZhi_Click(object sender, EventArgs e)
        {
            ChongZhi form = new ChongZhi();
            form.ShowDialog();
        }

        private void UCC_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.GetWorkingArea(this).Width - this.Width) / 2, 0);
            this.Height = 150;

            if(Whats.App.AppRuntime.Settings.IsAutoCloudBackupData)
            {
                string pathDataBackuper = AppDomain.CurrentDomain.BaseDirectory + "DataBackuper.exe";
                if (!File.Exists(pathDataBackuper))
                    return;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = pathDataBackuper;
                startInfo.Arguments = "auto";
                Process.Start(startInfo);
            }
            if(Whats.App.AppRuntime.Settings.IsAutoCheckUpdate)
            {
                string pathUpdateExe = AppDomain.CurrentDomain.BaseDirectory + "Updater.exe";
                if (!File.Exists(pathUpdateExe))
                    return;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = pathUpdateExe;
                startInfo.Arguments = "auto";
                Process.Start(startInfo);
            }

            //string pathUpdater = AppDomain.CurrentDomain.BaseDirectory + "Updater.exe";
            //if (!File.Exists(pathUpdater))
            //    return;

            //ProcessStartInfo updateInfo = new ProcessStartInfo();
            //updateInfo.FileName = pathUpdater;
            //System.Diagnostics.Process.Start(updateInfo);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Updater.exe";
            if (!File.Exists(path))
                return;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            System.Diagnostics.Process.Start(startInfo);
        }

        private void btnDataInit_Click(object sender, EventArgs e)
        {
            if (File.Exists(UccRuntime.SqlConfig.DataBasePath.Replace("~", AppDomain.CurrentDomain.BaseDirectory)))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (MessageBox.Show("数据库已经存在，确定删除重新建立？", "数据库已经存在，确定删除重新建立？,这是一个不可以恢复的操作，操作完成后以前的数据将会丢失！", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }

            }
            File.Delete(UccRuntime.SqlConfig.DataBasePath.Replace("~", AppDomain.CurrentDomain.BaseDirectory));

            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);

            dop.CreateTable<User>();
            dop.CreateTable<YiFu>();
            dop.CreateTable<ShouYi>();
            dop.CreateTable<MoneyHistory>();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            
        }
        bool isSimple = false;
        private void btnTools_Click(object sender, EventArgs e)
        {
            if(isSimple)
            {
                isSimple = false;
                this.Height = 150;
            }
            else
            {
                isSimple = true;
                this.Height = 420;
            }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserListForm form = new UserListForm();
            form.ShowDialog();
        }

        private void btnYiFuList_Click(object sender, EventArgs e)
        {
            YiFuListForm form = new YiFuListForm();
            form.ShowDialog();
        }

        private void btnTicketList_Click(object sender, EventArgs e)
        {
            ShouYiListForm form = new ShouYiListForm();
            form.ShowDialog();
        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            NewUCCDataCreator.Creator form = new NewUCCDataCreator.Creator();
            form.ShowDialog();
        }

        private void btnPriceList_Click(object sender, EventArgs e)
        {
            YiFuPriceList form = new YiFuPriceList();
            form.ShowDialog();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/DataBackuper.exe";
            if (!File.Exists(path))
                return;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            System.Diagnostics.Process.Start(startInfo);
        }

        private void txtStoreInfo_Click(object sender, EventArgs e)
        {
            Cleaner.StoreInfoForm form = new Cleaner.StoreInfoForm();
            form.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Cleaner.SettingsForm form = new Cleaner.SettingsForm();
            form.ShowDialog();
        }

        private void txtKouFei_Click(object sender, EventArgs e)
        {
            Cleaner.PrintMoneyTicketForm form = new Cleaner.PrintMoneyTicketForm();
            form.ShowDialog();
        }

        private void btnMoneyHistoryList_Click(object sender, EventArgs e)
        {
            Cleaner.MoneyHistoryListForm form = new Cleaner.MoneyHistoryListForm();
            form.ShowDialog();
        }

        private void btnXiaCi_Click(object sender, EventArgs e)
        {
            Cleaner.XiaCiListForm form = new Cleaner.XiaCiListForm();
            form.ShowDialog();
        }
    }
}
