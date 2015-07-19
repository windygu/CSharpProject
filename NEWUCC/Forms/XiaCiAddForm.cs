using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;

namespace NEWUCC
{
    public partial class XiaCiAddForm : Form
    {
        public XiaCiAddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            XiaCi item = new XiaCi();
            item.XiaCiID = UccRuntime.Dop.Count<XiaCi>().ToString();
            item.XiaCiContent = this.txtContent.Text;
            UccRuntime.Dop.Insert(item);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
