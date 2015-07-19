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
    public partial class YanSeAddForm : Form
    {
        public YanSeAddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            YanSe item = new YanSe();
            item.YanSeID = UccRuntime.Dop.Count<YanSe>().ToString();
            item.YanSeName = this.txtContent.Text;
            UccRuntime.Dop.Insert(item);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
