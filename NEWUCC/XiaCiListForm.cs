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
    public partial class XiaCiListForm : Form
    {
        public XiaCi[] Result;
        public XiaCiListForm()
        {
            InitializeComponent();
            this.Controls.Add(lv);
            lv.Location = this.listView1.Location;
            lv.Size = this.listView1.Size;
            this.listView1.Visible = false;
            lv.CheckBoxes = true;
        }
        Whats.UI.WinForm.UIListView<XiaCi> lv = new Whats.UI.WinForm.UIListView<XiaCi>();
        private void XiaCiListForm_Load(object sender, EventArgs e)
        {
            var data = UccRuntime.Dop.SelectAll<XiaCi>(new XiaCi());
            this.Bind(data);
        }
        void Flush()
        {
            var data = UccRuntime.Dop.SelectAll<XiaCi>(new XiaCi());
            this.Bind(data);
        }
        void Bind(List<XiaCi> data)
        {
            lv.Bind(data);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            XiaCiEditForm form = new XiaCiEditForm();
            XiaCiEditForm.Result = null;
            form.ShowDialog();
            if (XiaCiEditForm.Result != null)
            {
                UccRuntime.Dop.Insert(XiaCiEditForm.Result);
                MessageBox.Show("添加成功！");
            }
            Flush();
        }

        private void btnEidt_Click(object sender, EventArgs e)
        {
            XiaCiEditForm form = new XiaCiEditForm();
            try
            {
                form.Bind(lv.Data[lv.SelectedItems[0].Index]);
            }
            catch
            {

            }
            form.ShowDialog();
            UccRuntime.Dop.Update(XiaCiEditForm.Result);
            MessageBox.Show("修改成功！");
            Flush();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var list = new List<XiaCi>();
            for(int i=0;i<lv.SelectedItems.Count;i++)
            {
                list.Add(lv.Data[lv.SelectedItems[i].Index]);
            }
            Result = list.ToArray();
        }
    }
}
