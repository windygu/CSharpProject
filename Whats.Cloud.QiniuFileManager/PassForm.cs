using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whats.Cloud.QiniuFileManager
{
    public partial class PassForm : Form
    {
        public PassForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Runtime.ACCESS_KEY = this.txtACCESSKEY.Text;
            Runtime.SECRET_KEY = this.txtSECRETKEY.Text;
            Runtime.Bucket = this.txtBucket.Text;
            Runtime.Operator = this.txtOperator.Text;
            Runtime.Pass = this.txtPass.Text;

            Qiniu.Conf.Config.ACCESS_KEY = Runtime.ACCESS_KEY;
            Qiniu.Conf.Config.SECRET_KEY = Runtime.SECRET_KEY;

            FileListForm form = new FileListForm();
            form.Show();
            form.FormClosed += form_FormClosed;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void PassForm_Load(object sender, EventArgs e)
        {

        }
    }
}
