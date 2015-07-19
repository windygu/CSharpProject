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
    public partial class YiFuYanSe : Form
    {
        public static string Result { get; set; }
        public YiFuYanSe()
        {
            InitializeComponent();
        }
        public void Bind(string data)
        {
            foreach (var item in this.flowLayoutPanel1.Controls)
            {
                var r = item as RadioButton;
                if (r.Text == data)
                    r.Checked = true;
            }
        }
        public void LoadData()
        {
            this.flowLayoutPanel1.Controls.Clear();

            var list = UccRuntime.Dop.Select<YanSe>();
            for (int i = 0; i < list.Count; i++)
            {
                RadioButton r = new RadioButton();
                r.Text = list[i].YanSeName;
                this.flowLayoutPanel1.Controls.Add(r);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = "";
            foreach (var item in this.flowLayoutPanel1.Controls)
            {
                var r = item as RadioButton;
                if (r.Checked)
                    Result = r.Text;
            }
            this.Close();
        }

        private void YiFuYanSe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            YanSeAddForm form = new YanSeAddForm();
            form.ShowDialog();
            this.LoadData();
        }
    }
}
