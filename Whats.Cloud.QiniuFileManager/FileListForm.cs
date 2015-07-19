using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.IO;
using Qiniu.RS;
using Qiniu.RSF;
using Whats.UI.WinForm;

namespace Whats.Cloud.QiniuFileManager
{
    public partial class FileListForm : Form
    {
        public FileListForm()
        {
            InitializeComponent();
            this.Controls.Add(lv);
        }
        UIListView<DumpItem> lv = new UIListView<DumpItem>();
        private void FileListForm_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void FileListForm_SizeChanged(object sender, EventArgs e)
        {
            RenderLV();
        }
        void RenderLV()
        {
            lv.Width = this.Width - 30;
            lv.Height = this.Height - 80;
            lv.Location = new Point(0, 40);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        void Bind()
        {
            RSFClient rsf = new RSFClient(Runtime.Bucket);
            rsf.Prefix = this.txtPrefix.Text;
            DumpRet ret = rsf.ListPrefix(Runtime.Bucket);
            Dictionary<DateTime, DumpItem> dic = new Dictionary<DateTime, DumpItem>();
            foreach(var item in ret.Items)
            {
                dic.Add(new DateTime(item.PutTime), item);
            }
            List<DumpItem> list = new List<DumpItem>();
            var temp = dic.OrderBy(item => item.Key).Reverse().ToList();
            foreach(var item in temp)
            {
                list.Add(item.Value);
            }
            lv.Bind(list);
            RenderLV();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var domain = "7xja01.com1.z0.glb.clouddn.com";
            try
            {
                DumpItem item = this.lv.Edit(this.lv.SelectedItems[0].Index);
                string baseUrl = GetPolicy.MakeBaseUrl(domain, item.Key);
                string private_url = GetPolicy.MakeRequest(baseUrl);
                WebClient client = new WebClient();
                SaveFileDialog save=new SaveFileDialog();
                save.FileName = "";
                save.ShowDialog();
                if (string.IsNullOrEmpty(save.FileName))
                    return;
                client.DownloadFile(private_url, save.FileName);
                MessageBox.Show("操作成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message + ex.StackTrace);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.FileName = "";
                open.ShowDialog();
                if (string.IsNullOrEmpty(open.FileName) || !File.Exists(open.FileName))
                    return;
                var policy = new PutPolicy(Runtime.Bucket, 3600);
                string upToken = policy.Token();
                PutExtra extra = new PutExtra();
                IOClient client = new IOClient();

                string name = "db_" + System.Environment.MachineName + "_" +
                    Roo.Utils.StringBuilderHelper.GenerateStringID() + ".dbb";

                PutRet ret = client.PutFile(upToken, name, open.FileName, extra);
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message + ex.StackTrace);
            }
        }
    }
}
