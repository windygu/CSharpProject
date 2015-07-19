using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;

namespace Whats.Installer.Client
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            string workDir = AppDomain.CurrentDomain.BaseDirectory + "/installer_tmp/";
            if (Directory.Exists(workDir))
                Directory.CreateDirectory(workDir);

            FileStream fs = new FileStream(Application.ExecutablePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader reader = new BinaryReader(fs);
            MessageBox.Show("exeLength:" + fs.Length);
            fs.Position = fs.Length - 20 + 7;
            int exeLength = int.Parse(reader.ReadString());
            MessageBox.Show("exe Length:" + exeLength);
            long start = exeLength;
            MessageBox.Show("start : " + start);
            fs.Position = start;
            MessageBox.Show("position" + fs.Position);
            string instruction = reader.ReadString();
            MessageBox.Show("instruction : " + instruction);

            File.WriteAllText(workDir + "instruction.tmp", instruction);
            string config = reader.ReadString();
            MessageBox.Show("config:" + config);
            File.WriteAllText(workDir + "config.tmp", config);

            this.txtDescription.Text = instruction;

            Whats.Core.INI ini = new Core.INI(workDir + "config.tmp");
            StringCollection dirs = new StringCollection();
            ini.ReadSection("Dirs", dirs);
            foreach(var item in dirs)
            {
                Directory.CreateDirectory(item.Replace("~", workDir));
            }
            MessageBox.Show(dirs.ToString());
            StringCollection files = new StringCollection();
            ini.ReadSection("Files", files);
            foreach(var item in files)
            {
                FileInfo fileInfo = new FileInfo(item.Replace("~", workDir));
                if (!fileInfo.Directory.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                var bytes = reader.ReadBytes(ini.ReadInteger("Files", item, 0));
                File.WriteAllBytes(fileInfo.FullName, bytes);
            }

            reader.Close();
            //Directory.Delete(workDir, true);
        }
    }
}
