using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roo.Data.ManagerClient
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlConfig config = new SqlConfig(DataDriverType.Sqlite, this.txtDataPre.Text, "", this.txtDBPath.Text);
            DataOperator dop = new DataOperator(config);

            Compile.CSharpCodeCompiler compiler = new Compile.CSharpCodeCompiler();
            
            foreach(var item in this.lbxModels.Items)
            {
                try
                {
                    var assembly = compiler.Compile(File.ReadAllText(item.ToString()));

                    foreach (var type in assembly.GetTypes())
                    {
                        dop.CreateTable(type);
                    }
                    MessageBox.Show("操作成功！");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.ShowDialog();
            this.lbxModels.Items.AddRange(open.FileNames);
        }

        private void Create_Load(object sender, EventArgs e)
        {
            this.txtDBPath.Text = AppDomain.CurrentDomain.BaseDirectory + "db.db";
        }

        private void btnBrowserDBPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog open = new SaveFileDialog();
            open.ShowDialog();
            this.txtDBPath.Text = open.FileName;
        }
    }
}
