using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whats.Updater;

namespace Whats.UpdaterClient
{
    public class Runtime
    {
        public static Whats.Updater.Updater Updater = new Whats.Updater.Updater();
        static Runtime()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/update/update.json";

            FileInfo info = new FileInfo(path);
            if (!Directory.Exists(info.Directory.FullName))
                Directory.CreateDirectory(info.Directory.FullName);

            if (File.Exists(path))
            {
                Updater.Config = UpdateConfig.FromeFile(path);
            }
            else
            {
                Updater.Config = new UpdateConfig();
                Updater.Config.Domain = "http://update.freeroo.xyz/cleaner/";
                Updater.Config.RemoteUrl = "http://update.freeroo.xyz/cleaner/version.json";
                Updater.Config.LocalDir = AppDomain.CurrentDomain.BaseDirectory;
                Updater.Config.Save(path);
            }
        }
            
    }
}
