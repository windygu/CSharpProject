using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whats.App
{
    public class Settings
    {
        /// <summary>
        /// 是否开机自启动
        /// </summary>
        public bool IsAutoStart { get; set; }
        /// <summary>
        /// 是否在快捷菜单
        /// </summary>
        public bool IsInQuickMenu { get; set; }
        /// <summary>
        /// 是否在开始菜单
        /// </summary>
        public bool IsInStartMenu { get; set; }
        /// <summary>
        /// 是否在桌面显示快捷方式
        /// </summary>
        public bool IsInDeskTop { get; set; }
        /// <summary>
        /// 是否自动云备份数据
        /// </summary>
        public bool IsAutoCloudBackupData { get; set; }
        /// <summary>
        /// 自动检测更新
        /// </summary>
        public bool IsAutoCheckUpdate { get; set; }
        public Settings()
        {
            this.IsAutoStart = false;
            this.IsInDeskTop = true;
            this.IsInStartMenu = true;
            this.IsInQuickMenu = false;
            this.IsAutoCloudBackupData = true;
            this.IsAutoCheckUpdate = true;
        }
    }
}
