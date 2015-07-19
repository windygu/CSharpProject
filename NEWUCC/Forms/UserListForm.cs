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
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }
        List<User> UserList = new List<User>();
        private void UserList_Load(object sender, EventArgs e)
        {
            var list = UccRuntime.Dop.Select(new User(), "", "", 0, 0);
            this.Bind(list);
        }

        public void Bind(List<User> data)
        {
            this.UserList = data;
            this.lbxUserList.Items.Clear();
            foreach (var item in UserList)
            {
                string text = item.UserID.PadRight(30, ' ') + item.UserName;
                this.lbxUserList.Items.Add(text);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            UccRuntime.Dop.Delete(UserList[this.lbxUserList.SelectedIndex]);
            this.UserList.RemoveAt(this.lbxUserList.SelectedIndex);
            this.lbxUserList.Items.RemoveAt(this.lbxUserList.SelectedIndex);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Bind(this.UserList[this.lbxUserList.SelectedIndex]);
            form.ShowDialog();
        }

        private void btnChongZhi_Click(object sender, EventArgs e)
        {
            ChongZhi form = new ChongZhi();
            form.Bind(this.UserList[this.lbxUserList.SelectedIndex].UserID);
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user.UserName = this.txtUserName.Text;
            var list = UccRuntime.Dop.Select(user, "", "", 0, 0);
            this.Bind(list);
        }

    }
}
