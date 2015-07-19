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
    public partial class YiFuPinPai : Form
    {
        public static string Result { get; set; }
        public YiFuPinPai()
        {
            InitializeComponent();
            LoadData();
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

            var list = UccRuntime.Dop.Select<PinPai>();
            for (int i = 0; i < list.Count; i++)
            {
                RadioButton r = new RadioButton();
                r.Text = list[i].PinPaiName;
                this.flowLayoutPanel1.Controls.Add(r);
            }
        }

        private void YiFuPinPai_Load(object sender, EventArgs e)
        {
            
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PinPaiAddForm form = new PinPaiAddForm();
            form.ShowDialog();
            this.LoadData();
        }
    }
}
