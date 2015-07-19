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
using Whats.Core;
using Roo.Loger;

namespace Whats.Installer.Creator
{
    public partial class Creator : Form
    {
        public Creator()
        {
            InitializeComponent();
        }
        List<string> files = new List<string>();
        string dirPath;
        string copyright;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            Create(save.FileName);
            MessageBox.Show("操作成功！");
        }
        void Create(string path)
        {
            string config = GetFileDescription();
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(fs);

            byte[] exe = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Whats.Installer.Client.exe");
            Loger.Event("exe length:" + exe.Length);
            writer.Write(exe);

            writer.Write(copyright);
            Loger.Event("instruction" + copyright);
            writer.Write(config);
            MessageBox.Show("config:"+config);
            foreach(var item in files)
            {
                if (File.Exists(item.Replace("~", dirPath)))
                    writer.Write(File.ReadAllBytes(item.Replace("~", dirPath)));    
            }
            writer.Write(exe.Length.ToString().PadRight(10));
            Loger.Event("fs length:" + fs.Length);
            Loger.Event("fs - exe :" + (fs.Length - exe.Length));
            writer.Close();
            fs.Close();
        }
        string GetFileDescription()
        {
            var iniPath = AppDomain.CurrentDomain.BaseDirectory + "config.tmp";
            if (File.Exists(iniPath))
                File.Delete(iniPath);
            INI ini = new INI(iniPath);

            long lenth = 0;
            foreach (var item in files)
            {
                string path = item.Replace("~", dirPath);
                FileInfo fileInfo = new FileInfo(path);
                if (!string.IsNullOrEmpty(fileInfo.Extension))
                {
                    lenth += fileInfo.Length;
                    ini.WriteInteger("Files", item, (int)fileInfo.Length);
                }
                else
                    ini.WriteInteger("Dirs", item, 0);

            }
            lenth += copyright.Length;
            ini.WriteInteger("Info", "Length", (int)lenth);

            return File.ReadAllText(iniPath, Encoding.UTF8);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            dirPath = open.SelectedPath;
            var list = Directory.GetFileSystemEntries(dirPath, "*", SearchOption.AllDirectories);
            this.lbxFiles.Items.Clear();
            foreach(var item in list)
            {
                var temp = item.Replace(dirPath, "~");
                temp = temp.Replace("\\", "/");
                files.Add(temp);
                this.lbxFiles.Items.Add(temp);
            }
            
        }

        private void btnCopyright_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            copyright = File.ReadAllText(open.FileName, Encoding.Default);
        }
    }
}
