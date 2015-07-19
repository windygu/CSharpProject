using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whats.License;

namespace Whats.License.Client
{
    public partial class LicenseClient : Form
    {
        public LicenseClient()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.txtLicense.Text = LicenseManager.Create(this.txtPhone.Text, this.txtPirvateKey.Text).Key;
        }

        private void LicenseClient_Load(object sender, EventArgs e)
        {
            this.txtPublicKey.Text = "CLEANER1";
            this.txtPirvateKey.Text = "FREEROO1";
            this.txtPhone.Text = "18516520360";
        }

        private void txtDe_Click(object sender, EventArgs e)
        {
            this.txtDE_PHONE.Text = LicenseManager.DeCreate(this.txtLicense.Text, this.txtPirvateKey.Text);
        }
    }
}
