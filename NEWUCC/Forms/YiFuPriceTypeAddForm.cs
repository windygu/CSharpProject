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
    public partial class YiFuPriceTypeAddForm : Form
    {
        public YiFuPriceTypeAddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            YiFuPriceType item = new YiFuPriceType();
            item.YiFuName = this.txtName.Text;
            item.YiFuPriceID = UccRuntime.Dop.Count<YiFuPriceType>().ToString();
            item.DanWei = this.txtDanWei.Text;
            item.Price = this.txtPrice.Text;
            item.IsZheKou = this.cbxIsZheKou.SelectedIndex;
            UccRuntime.Dop.Insert(item);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
