using Roo.Data;
using Roo.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FreeRoo
{
    public class SiteStartor
    {
        public static SiteStartor Default
        {
            get { return new SiteStartor(); }
        }

        public virtual void Start()
        {

            //设置网站信息
            this.SetSiteInfo();

            //加载插件
            this.LoadPlugins();

            //设置数据库配置
            this.SetSqlConfig();

            //加载模型
            this.LoadModel();
        }

        public virtual void SetSiteInfo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + SystemCoreStrings.FILE_CORE_SITEINFO;
            if (File.Exists(path) && SystemTool.HasInstalled)
                Runtime.SiteInfo = Roo.Data.DataConverter.JsonToObject<SiteInfo>(File.ReadAllText(path));
        }

        public virtual void LoadPlugins()
        {
            string pluginDir = AppDomain.CurrentDomain.BaseDirectory + 
                Runtime.SystemStrings.DIR_PRIVATE_PLUGIN;
            if (!Directory.Exists(pluginDir))
                return;

            DirectoryInfo[] dirs = new DirectoryInfo(pluginDir).GetDirectories();
            Runtime.Plugins = new List<PluginInfo>();

            foreach (var item in dirs)
            {
                Runtime.Plugins.Add(PluginInfo.Load(item.Name));
            }
        }
        public virtual void SetSqlConfig()
        {
            string sqlConfigPath = AppDomain.CurrentDomain.BaseDirectory + SystemCoreStrings.FILE_CORE_SQLCONFIG;
            if (File.Exists(sqlConfigPath))
                Runtime.SqlConfig = Roo.Data.DataConverter.JsonToObject<SqlConfig>(File.ReadAllText(sqlConfigPath, Encoding.Default));
        }
        public virtual void LoadModel()
        {
            ModelPool.Default = new ModelPool();
        }
        public virtual void ReStart()
        {
            this.Start();
        }
    }
}
