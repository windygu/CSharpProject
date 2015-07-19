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
    public partial class YiFuLeiXing : Form
    {
        public static YiFuPriceType Result;
        public YiFuLeiXing()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            this.flowLayoutPanel1.Controls.Clear();

            var list = UccRuntime.Dop.Select<YiFuPriceType>();
            for (int i = 0; i < list.Count; i++)
            {
                RadioButton box = new RadioButton();
                box.Width = 200;
                box.Text = list[i].YiFuName;
                this.flowLayoutPanel1.Controls.Add(box);
            }
        }
        private void YiFuLeiXing_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
            this.flowLayoutPanel1.Width = this.Width;
            this.flowLayoutPanel1.Height = this.Height - 200;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = new YiFuPriceType();
            foreach(var item in this.flowLayoutPanel1.Controls)
            {
                var button = item as RadioButton;
                if (button.Checked)
                {
                    var list = UccRuntime.Dop.Select<YiFuPriceType>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (button.Text == list[i].YiFuName)
                        {
                            Result = list[i];
                        }
                    }
                }
            }
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            YiFuPriceTypeAddForm form = new YiFuPriceTypeAddForm();
            form.ShowDialog();
            this.LoadData();
        }

        private void YiFuLeiXing_SizeChanged(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Width = this.Width;
            this.flowLayoutPanel1.Height = this.Height - 200;
            this.btnAdd.Top = this.Height - 100;
            this.btnOK.Top = this.Height - 100;
        }
    }
}
