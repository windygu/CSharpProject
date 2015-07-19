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
    public partial class ShouYiListForm : Form
    {
        public ShouYiListForm()
        {
            InitializeComponent();
        }
        private List<ShouYi> List;
        public void Bind(List<ShouYi> data)
        {
            this.List = data;
            this.lbxList.Items.Clear();
            foreach (var item in data)
            {
                this.lbxList.Items.Add(item.TicketID.PadRight(30) + item.State);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShouYi data = new ShouYi();
            data.TicketID = this.txtTicketID.Text;
            data.UserID = this.txtUserID.Text;
            data.UserName = this.txtUserName.Text;
            data.PhoneNo = this.txtPhoneNo.Text;
            var list = UccRuntime.Dop.Select(data, "", "QuYiDateTime ASC", 0, 0);
            this.Bind(list);
        }

        private void ShouYiListForm_Load(object sender, EventArgs e)
        {
            var list = UccRuntime.Dop.Select<ShouYi>();
            this.Bind(list);
        }

        private void btnXiHao_Click(object sender, EventArgs e)
        {
            try
            {
                this.List[this.lbxList.SelectedIndex].State = "未取";
                UccRuntime.Dop.Update(this.List[this.lbxList.SelectedIndex]);
                MessageBox.Show("操作成功！");
                this.Bind(this.List);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！", ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ShouYiForm form = new ShouYiForm();
            form.Bind(this.List[this.lbxList.SelectedIndex]);
            form.ShowDialog();
        }
    }
}
