using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Roo;

namespace Roo.Data.ManagerClient
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void btnCreateTableFromModelCode_Click(object sender, EventArgs e)
        {
            Create form = new Create();
            form.ShowDialog();
        }
    }
}
