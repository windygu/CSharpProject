using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;

namespace Whats.App
{
    public class AppRuntime
    {
        public static AppInfo AppInfo { get; set; }
        public static Settings Settings { get; set; }

        static AppRuntime()
        {
            string appInfoJsonPath = AppDomain.CurrentDomain.BaseDirectory + "app/app.json";
            if(File.Exists(appInfoJsonPath))
            {
                AppInfo = DataConverter.JsonToObject<AppInfo>(File.ReadAllText(appInfoJsonPath, Encoding.Default));
            }
            else
            {
                AppInfo = new AppInfo();

            }
            string appSettings = AppDomain.CurrentDomain.BaseDirectory + "app/settings.json";
            if (File.Exists(appSettings))
            {
                Settings = DataConverter.JsonToObject<Settings>(File.ReadAllText(appSettings, Encoding.Default));
            }
            else
            {
                Settings = new Settings();

            }
            AppHelper.Save(AppInfo, Settings);

        }
    }
}
