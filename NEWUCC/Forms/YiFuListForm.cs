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
    public partial class YiFuListForm : Form
    {
        public YiFuListForm()
        {
            InitializeComponent();
        }
        List<YiFu> YiFuList;
        Whats.UI.WinForm.UIListView<YiFu> lv = new Whats.UI.WinForm.UIListView<YiFu>();
        public void Bind(List<YiFu> data)
        {
            this.YiFuList = data;
            this.lbxList.Items.Clear();
            foreach (var item in data)
            {
                this.lbxList.Items.Add(item.ClotheID.PadRight(20) + item.ClotheType.Trim().PadRight(25) + item.State);
            }
            
            lv.Bind(data, new string[] { "ClotheID", "ClotheType", "State" });
            lv.Size = this.lbxList.Size;
            lv.Location = this.lbxList.Location;
            this.lbxList.Visible = false;
            this.Controls.Add(lv);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                YiFu data = new YiFu();
                data.ClotheID = this.txtYiFuID.Text;
                data.TicketID = this.txtTicketID.Text;
                var list = UccRuntime.Dop.Select<YiFu>(data, "", "", 0, 0);
                this.Bind(list);
            }
            catch(Exception ex)
            {
                MessageBox.Show("未找到或者操作失败！");
            }
        }

        private void YiFuListForm_Load(object sender, EventArgs e)
        {
            var list = UccRuntime.Dop.Select<YiFu>();
            Bind(list);
        }

        private void btnXiHao_Click(object sender, EventArgs e)
        {
            try
            {
                var data = this.lv.Edit(this.lv.SelectedItems[0].Index);
                data.State = "已洗";
                UccRuntime.Dop.Update(data);
                MessageBox.Show("操作成功！");
                this.Bind(this.YiFuList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！"+ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                YiFuForm form = new YiFuForm();
                form.Bind(this.lv.Edit(this.lv.SelectedItems[0].Index));
                form.ShowDialog();
            }
            catch
            {

            }
            
        }
    }
}
