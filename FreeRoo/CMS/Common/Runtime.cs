using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Roo.Data;

namespace FreeRoo
{
    /// <summary>
    /// 代表内容管理系统的运行时
    /// </summary>
    public static class Runtime
    {
        /// <summary>
        /// 开发模式，开启后每次运行都是默认配置
        /// </summary>
        public static bool IsDevelopping { get; set; }

        public static SystemStrings SystemStrings { get; set; }

        public static SiteInfo SiteInfo { get; set; }

        public static SqlConfig SqlConfig { get; set; }

        public static List<PluginInfo> Plugins { get; set; }

        static Runtime()
        {
            IsDevelopping = true;
            SiteInfo = new SiteInfo();
            SqlConfig = new SqlConfig();
            Plugins = new List<PluginInfo>();
        }
    }
}
