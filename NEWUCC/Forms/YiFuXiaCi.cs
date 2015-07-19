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
    public partial class YiFuXiaCi : Form
    {
        public static string Result { get; set; }
        public YiFuXiaCi()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            this.flowLayoutPanel1.Controls.Clear();
            var list = UccRuntime.Dop.Select<XiaCi>();
            for (int i = 0; i < list.Count; i++)
            {
                CheckBox box = new CheckBox();
                box.Text = list[i].XiaCiContent;
                box.Width = 200;
                this.flowLayoutPanel1.Controls.Add(box);
            }
        }
        public void Bind(string data)
        {
            var datas = data.Split(',');
            foreach(var item in this.flowLayoutPanel1.Controls)
            {
                var box = item as CheckBox;
                foreach(var d in datas)
                {
                    if (d == box.Text)
                        box.Checked = true;
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = "";
            foreach (var item in this.flowLayoutPanel1.Controls)
            {
                var box = item as CheckBox;
                if (box.Checked)
                    Result += box.Text + ",";
            }
            this.Close();
        }

        private void YiFuXiaCi_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TextEditor editor = new TextEditor();
            //editor.Bind(AppDomain.CurrentDomain.BaseDirectory + "/data/clothes_error.txt");
            //editor.ShowDialog();
            XiaCiAddForm form = new XiaCiAddForm();
            form.ShowDialog();

            LoadData();
        }
    }
}
