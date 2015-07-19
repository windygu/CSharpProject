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
    public partial class PinPaiAddForm : Form
    {
        public PinPaiAddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PinPai item = new PinPai();
            item.PinPaiID = UccRuntime.Dop.Count<PinPai>().ToString();
            item.PinPaiName = this.txtContent.Text;
            UccRuntime.Dop.Insert(item);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
