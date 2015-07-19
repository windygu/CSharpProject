using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;

namespace NEWUCC
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        public void Bind(User user)
        {
            this.txtUserID.Text = user.UserID;
            this.txtUserName.Text = user.UserName;
            this.txtAddress.Text = user.Address;
            this.txtPhone.Text = user.PhoneNo;
            this.txtMoney.Text = user.Money.ToString();
            this.txtBeiZhu.Text = user.BeiZhu;
            this.cbxSex.Text = user.Sex;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user.UserName = this.txtUserName.Text;
            user.Address = this.txtAddress.Text;
            user.PhoneNo = this.txtPhone.Text;
            user.Money = double.Parse(this.txtMoney.Text);
            user.Sex = this.cbxSex.Text;
            user.BeiZhu = this.txtBeiZhu.Text;
            UccRuntime.Dop.Update(user);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
