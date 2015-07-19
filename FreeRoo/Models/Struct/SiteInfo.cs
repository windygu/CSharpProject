using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Utils;
using System.IO;

namespace FreeRoo
{
    /// <summary>
    /// 站点信息模型
    /// </summary>
    public class SiteInfo
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Domain { get; set; }
        public string CopyRight { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public string TongJi { get; set; }

        public virtual void Save()
        {
            string json =Roo.Data.DataConverter.ObjectToJson(this);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "/Configs/SiteInfo.config", json, Encoding.UTF8);
        }
    }
}
