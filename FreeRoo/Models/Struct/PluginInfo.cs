using System;
using System.Collections.Generic;
using System.Xml;
using Roo.Utils;

namespace FreeRoo
{
    /// <summary>
    /// 插件信息配置
    /// </summary>
    public class PluginInfo : ProductionInfo
    {
        public string WorkDir { get; set; }
        public string Dll { get; set; }
        public string Title { get; set; }
        public List<AppInfo> Apps { get; set; }
        public static PluginInfo Load(string pluginName)
        {
            PluginInfo p = new PluginInfo();
            p.Name = pluginName;
            XmlDocument doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + "/Configs/plugins.config");

            XmlElement xeInfo = doc.SelectSingleNode("Plugin/Info") as XmlElement;
            p.Dll = xeInfo.GetAttribute("dll");
            p.Title = xeInfo.GetAttribute("title");
            p.Home = xeInfo.GetAttribute("home");
            p.Author = xeInfo.GetAttribute("author");
            p.Title = xeInfo.GetAttribute("title");
            p.Name = xeInfo.GetAttribute("name");

            XmlNodeList appsList = doc.SelectNodes("Plugin/Apps/App");
            p.Apps = new List<AppInfo>();
            
            foreach (var item in appsList)
            {
                var xe = item as XmlElement;
                AppInfo app = new AppInfo();
                app.Name = xe.GetAttribute("name");
                app.Title = xe.GetAttribute("title");
                app.Url = xe.GetAttribute("url");
                app.Icon = xe.GetAttribute("icon");
                app.WorkDir = p.WorkDir;
                p.Apps.Add(app);
            }
            return p;
        }
        public AppInfo GetAppInfo(string appName)
        {
            foreach (var app in Apps)
            {
                if (app.Name == appName)
                    return app;
            }
            throw new Exception("不存在指定名称的应用！" + appName);
        }
    }
}
