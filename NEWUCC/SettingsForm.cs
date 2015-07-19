using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Whats.App;

namespace Cleaner
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppRuntime.Settings.IsAutoCheckUpdate = this.cbxInAutoCheckUpdate.Checked;
            AppRuntime.Settings.IsAutoCloudBackupData = this.cbxIsAutoCloudBackupData.Checked;
            AppRuntime.Settings.IsAutoStart = this.cbxIsAutoStart.Checked;
            AppRuntime.Settings.IsInDeskTop = this.cbxIsInDeskTop.Checked;
            AppRuntime.Settings.IsInStartMenu = this.cbxIsInStartMenu.Checked;

            AppHelper.Register();

            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.cbxInAutoCheckUpdate.Checked = AppRuntime.Settings.IsAutoCheckUpdate;
            this.cbxIsAutoCloudBackupData.Checked = AppRuntime.Settings.IsAutoCloudBackupData;
            this.cbxIsAutoStart.Checked = AppRuntime.Settings.IsAutoStart;
            this.cbxIsInDeskTop.Checked = AppRuntime.Settings.IsInDeskTop;
            this.cbxIsInStartMenu.Checked = AppRuntime.Settings.IsInStartMenu;
        }
    }
}
