using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whats.App
{
    public class AppInfo
    {
        public int Version { get; set; }
        public string AppTitle { get; set; }
        public string Author { get; set; }
        public string HomePage { get; set; }
        public string Copyright { get; set; }
        public string ExeName { get; set; }
        public string AppName { get; set; }
        public string UpdateExe { get; set; }
        public string UnInstallExe { get; set; }
        public string InstallPath { get; set; }
        public string DataPath { get; set; }
        public string SettingsPath { get; set; }
        public string VersionUrl { get; set; }
        public AppInfo()
        {
            this.Version = 1;
            this.AppTitle = "杰洁洗衣店管理软件";
            this.Author = "卢杰杰";
            this.HomePage = "http://freeroo.software";
            this.Copyright = "Copyright 版权所有";
            this.ExeName = "Cleaner.exe";
            this.AppName = "Cleaner";
            this.UpdateExe = AppDomain.CurrentDomain.BaseDirectory + "Update.exe";
            this.UnInstallExe = AppDomain.CurrentDomain.BaseDirectory + "UnInstall.exe";
            this.DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/" + this.AppName + "Data";
            this.InstallPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/" + this.AppName;
            this.SettingsPath = AppDomain.CurrentDomain.BaseDirectory + "config/settings.json";
            this.VersionUrl = "http://update.freeroo.xyz/" + AppName + "/version.json";
        }
    }
}
