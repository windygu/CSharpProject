using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Whats.UI.WinForm.UIListView<Cleaner.Core.User> lv = new Whats.UI.WinForm.UIListView<Cleaner.Core.User>();
            Roo.Data.SqlConfig config = new Roo.Data.SqlConfig(Roo.Data.DataDriverType.Sqlite,
                "UCC_", "", "~db.db");
            Roo.Data.DataOperator dop = new Roo.Data.DataOperator(config);
            var list = dop.Select<Cleaner.Core.User>();
            lv.Bind(list);
            this.Controls.Add(lv);
            lv.Dock = DockStyle.Fill;
            var temp=lv.Edit(0);
            MessageBox.Show(temp.ToString());
        }
    }
}
