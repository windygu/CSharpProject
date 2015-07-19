using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;
using Microsoft.Win32;
using System.IO;

namespace Whats.App
{
    public class AppHelper
    {
        public static void Register()
        {
            Register(AppRuntime.AppInfo, AppRuntime.Settings);
        }
        public static void Save()
        {
            Save(AppRuntime.AppInfo, AppRuntime.Settings);
        }
        public static void Register(AppInfo app, Settings settings)
        {
            RegistryKey root = Registry.LocalMachine;
            RegistryKey software = root.OpenSubKey("SOFTWARE", true);
            string[] software_items = software.GetSubKeyNames();
            var freeroo = software_items.FirstOrDefault(item => item == "FreeRoo");
            RegistryKey freeroo_reg;
            if(string.IsNullOrEmpty(freeroo))
            {
                freeroo_reg = software.CreateSubKey("FreeRoo", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            else
            {
                freeroo_reg = software.OpenSubKey("FreeRoo", true);
            }
            var freeroo_items = freeroo_reg.GetSubKeyNames();
            var result = freeroo_items.FirstOrDefault(item => item == app.AppName);
            if (string.IsNullOrEmpty(result))
            {
                RegistryKey app_key = freeroo_reg.CreateSubKey(app.AppName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                app_key.SetValue(app.AppName + "DataPath", app.DataPath);
                app_key.SetValue(app.AppName + "InstallPath", app.InstallPath);
                app_key.Close();
            }
            freeroo_reg.Close();
            software.Close();


            string lnkPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/" + AppRuntime.AppInfo.AppTitle + ".lnk";
            if(AppRuntime.Settings.IsInDeskTop)
            {
                Shortcut sc = new Shortcut();
                sc.Path = AppRuntime.AppInfo.InstallPath +"/"+ AppRuntime.AppInfo.ExeName;
                sc.Arguments = "";
                sc.WorkingDirectory = AppRuntime.AppInfo.InstallPath;
                sc.Description = AppRuntime.AppInfo.AppTitle;
                
                if (File.Exists(lnkPath))
                    File.Delete(lnkPath);
                sc.Save(lnkPath);
            }
            string startMenuDir = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "/" + AppRuntime.AppInfo.AppName;
            if (AppRuntime.Settings.IsInStartMenu)
            {
                
                if (!Directory.Exists(startMenuDir))
                    Directory.CreateDirectory(startMenuDir);

                File.Copy(lnkPath, startMenuDir + "/" + AppRuntime.AppInfo.AppTitle + ".lnk", true);
            }
            else
            {
                if(Directory.Exists(startMenuDir))
                {
                    Directory.Delete(startMenuDir, true);
                }
            }
            string autoStart = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "/" + AppRuntime.AppInfo.AppTitle + ".lnk";
            
            if(AppRuntime.Settings.IsAutoStart)
            {
                if (!File.Exists(autoStart))
                    File.Copy(lnkPath, autoStart);
            }
            else
            {
                if (File.Exists(autoStart))
                    File.Delete(autoStart);
            }
        }
        public static void Save(AppInfo app, Settings settings)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "config/app.json", DataConverter.RenderJson(DataConverter.ObjectToJson(app)));
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "config/settings.json", DataConverter.RenderJson(DataConverter.ObjectToJson(settings)));
        }
    }
}
