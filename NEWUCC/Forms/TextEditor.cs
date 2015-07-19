using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEWUCC
{
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }
        public void Bind(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                this.Path = path;
                StreamReader reader = new StreamReader(path, Encoding.Default);
                this.txtContent.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
        private string Path = "";
        private void btnEditor_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(this.Path);
            writer.Write(this.txtContent.Text);
            writer.Close();
            MessageBox.Show("操作成功！");
        }
    }
}
