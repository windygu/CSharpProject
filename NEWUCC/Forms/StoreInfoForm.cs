using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;
using Roo.Data;

namespace Cleaner
{
    public partial class StoreInfoForm : Form
    {
        public StoreInfoForm()
        {
            InitializeComponent();
        }

        private void StoreInfoForm_Load(object sender, EventArgs e)
        {
            this.txtStoreName.Text = UccRuntime.StoreInfo.Name;
            this.txtPhone.Text = UccRuntime.StoreInfo.PhoneNo;
            this.txtAddress.Text = UccRuntime.StoreInfo.Address;
            this.txtQRCode.Text = UccRuntime.StoreInfo.QRCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "store.json";
            UccRuntime.StoreInfo.Name = this.txtStoreName.Text;
            UccRuntime.StoreInfo.PhoneNo = this.txtPhone.Text;
            UccRuntime.StoreInfo.Address = this.txtAddress.Text;
            UccRuntime.StoreInfo.QRCode = this.txtQRCode.Text;
            File.WriteAllText(path,
                DataConverter.RenderJson(DataConverter.ObjectToJson(UccRuntime.StoreInfo)), Encoding.Default);
            MessageBox.Show("操作成功！");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "";
            open.ShowDialog();
            this.txtQRCode.Text = open.FileName;
        }
    }
}
