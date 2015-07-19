using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.Installer.CompileClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            form.Show();
            form.FormClosed += form_FormClosed;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            UnStart form = new UnStart();
            form.Show();
            form.FormClosed += form_FormClosed;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
