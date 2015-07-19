using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whats.License
{
    public partial class LicenseBox : Form
    {
        public LicenseBox()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtLicense.Text) || string.IsNullOrEmpty(this.txtPhone.Text))
                {
                    MessageBox.Show("正版授权码和获取正版授权码所时的手机号码不能为空！");
                    return;
                }
                if (LicenseManager.CheckRegister(this.txtLicense.Text, this.txtPhone.Text))
                {
                    LicenseManager.Register(this.txtLicense.Text, this.txtPhone.Text);
                    MessageBox.Show("正版授权成功！你可以正常使用本软件！");
                }
                else
                {
                    MessageBox.Show("请确定你已经填写了正确的正版授权码和您获取授权码时的手机号码！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("注册失败！请联系软件作者！" + ex.Message + ex.StackTrace);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            BuyLicenseBox form = new BuyLicenseBox();
            form.ShowDialog();
        }

        private void btnShiYong_Click(object sender, EventArgs e)
        {
            LicenseManager.Register(LicenseManager.Create(this.txtPhone.Text).Key, this.txtPhone.Text);
        }
    }
}
