using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Roo.Utils;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Roo.Data
{
    /// <summary>
    /// 数据库相关配置
    /// </summary>
    public class SqlConfig
    {
        public SqlConfig()
        {
            this.DataBasePath = "~db.db";
            this.PassWord = "";
            this.PreFix = "Roo_";
            this.DataDriverType = DataDriverType.Sqlite;
        }

        public SqlConfig(DataDriverType dataDriverType, string preFix, string pwd, string dbPath)
        {
            this.DataDriverType = dataDriverType;
            this.PreFix = preFix;
            this.PassWord = pwd;
            this.DataBasePath = dbPath;
        }
        
        [ScriptIgnore]
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public string ConnectionString
        {
            get 
            {
                DataOperator dop = new DataOperator(this);
                return dop.SqlBuilder.ConnectionString(); 
            }
        }

        #region InstallNeccessary
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataDriverType DataDriverType { get; set; }        
        /// <summary>
        /// 数据库表名前缀
        /// </summary>
        public string PreFix { get; set; }
        /// <summary>
        /// 数据库路径
        /// </summary>
        public string DataBasePath { get; set; }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public string PassWord { get; set; }
        #endregion

        public void Save(string path)
        {
            string json = Roo.Data.DataConverter.ObjectToJson(this);
            File.WriteAllText(path, json, Encoding.Default);
        }

    }
}