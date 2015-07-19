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
    public partial class YiFuPriceTypeEditForm : Form
    {
        public static YiFuPriceType Result;
        public YiFuPriceTypeEditForm()
        {
            InitializeComponent();
        }
        public void Bind(YiFuPriceType yifuPrice)
        {
            Result =yifuPrice;
            this.txtPrice.Text = Result.Price;
            this.txtName.Text = Result.YiFuName;
            this.txtDanWei.Text = Result.DanWei;
            this.cbxIsZheKou.SelectedIndex = Result.IsZheKou;
        }
        private void YiFuPriceTypeEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Result.YiFuName = this.txtName.Text;
            Result.DanWei = this.txtDanWei.Text;
            Result.Price = this.txtPrice.Text;
            Result.IsZheKou = this.cbxIsZheKou.SelectedIndex;
            string sql = UccRuntime.Dop.SqlBuilder.Update(Result);
            UccRuntime.Dop.Update(Result);
            UccRuntime.Dop.Commit();
            MessageBox.Show("操作成功！");
            this.Close();
        }
    }
}
