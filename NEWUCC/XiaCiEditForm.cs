using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;

namespace Cleaner
{
    public partial class XiaCiEditForm : Form
    {
        public static XiaCi Result;
        public XiaCiEditForm()
        {
            InitializeComponent();
        }

        private void XiaCiEditForm_Load(object sender, EventArgs e)
        {

        }
        public void Bind(XiaCi data)
        {
            Result = data;
            this.txtXiaCiContent.Text = data.XiaCiContent;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Result==null)
                Result = new XiaCi();
            Result.XiaCiContent = this.txtXiaCiContent.Text;
            this.Close();
        }
    }
}
