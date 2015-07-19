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
    public partial class YiFuPriceList : Form
    {
        public YiFuPriceList()
        {
            InitializeComponent();
        }
        List<YiFuPriceType> list;
        public void LoadData()
        {
            list = UccRuntime.Dop.Select<YiFuPriceType>();
            this.lbxList.Items.Clear();
            foreach (var item in list)
            {
                this.lbxList.Items.Add(item.YiFuName);
            }
        }
        private void YiFuPriceList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lbxList_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                YiFuPriceTypeEditForm form = new YiFuPriceTypeEditForm();
                form.Bind(list[this.lbxList.SelectedIndex]);
                form.ShowDialog();
            }
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            YiFuPriceTypeAddForm form = new YiFuPriceTypeAddForm();
            form.ShowDialog();
            this.LoadData();
        }
    }
}
