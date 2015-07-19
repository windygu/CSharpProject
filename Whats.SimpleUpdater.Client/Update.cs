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
using Roo.Data;
using System.Diagnostics;

namespace Whats.SimpleUpdater.Client
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (update != null)
                {
                    if (update.Version > App.AppRuntime.AppInfo.Version)
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile(update.FileUrl, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/更新程序.exe");
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/更新程序.exe";
                        Process.Start(startInfo);
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("更新失败！请确定您已经链接互联网！" + ex.Message + ex.StackTrace);
            }
        }
        SimpleUpdateDescription update = null;
        private void Update_Load(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "update/version.json", 
                    Roo.Data.DataConverter.RenderJson(Roo.Data.DataConverter.ObjectToJson(new SimpleUpdateDescription())));

                WebRequest request = WebRequest.Create(App.AppRuntime.AppInfo.VersionUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string json = reader.ReadToEnd();
                update = DataConverter.JsonToObject<SimpleUpdateDescription>(json);

                if (update.Version > App.AppRuntime.AppInfo.Version)
                {
                    MessageBox.Show("本软件有可用的更新！", "提示");
                    this.txtContent.AppendText("最新版本：" + update.Version + "\r\n");
                    this.txtContent.AppendText("当前版本：" + App.AppRuntime.AppInfo.Version + "\r\n");

                    this.txtContent.AppendText(update.Description);
                }
                else
                {
                    MessageBox.Show("已经是最新版本！", "提示");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("检测更新失败！请确定您已经链接互联网！" + ex.Message + ex.StackTrace);
                this.Close();
            }
        }
    }
}
