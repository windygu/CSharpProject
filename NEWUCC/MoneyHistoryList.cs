using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;

namespace Cleaner
{
    public partial class MoneyHistoryList : Form
    {
        public MoneyHistoryList()
        {
            InitializeComponent();
            this.Controls.Add(lv);
            lv.Location = this.listView1.Location;
            lv.Size = this.listView1.Size;
            this.listView1.Visible = false;
        }
        Whats.UI.WinForm.UIListView<MoneyHistory> lv = new Whats.UI.WinForm.UIListView<MoneyHistory>();
        private void MoneyHistoryList_Load(object sender, EventArgs e)
        {
            var data = UccRuntime.Dop.SelectAll(new MoneyHistory());
            this.Bind(data);
        }
        void Bind(List<MoneyHistory> data)
        {
            lv.Bind(data);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.UserID = this.txtUserID.Text;
            u = UccRuntime.Dop.SelectSingle(u) as User;
            if(u==null)
            {
                MessageBox.Show("会员不存在！请输入正确的会员卡号！");
                return;
            }
            MoneyHistory history = new MoneyHistory();
            history.UserID = u.UserID;
            var list = UccRuntime.Dop.SelectAll<MoneyHistory>(history);
            this.Bind(list);
        }
    }
}
