using System;
using System.IO;
using Roo.Data;

namespace FreeRoo
{
    /// <summary>
    /// CMS安装类
    /// </summary>
    public class Installer
    {
        public Installer()
        {
            
        }

        public void Install(SqlConfig config, User user)
        {
            Runtime.SqlConfig = config;

            DataOperator dop = new DataOperator(Runtime.SqlConfig);

            //创建数据库
            string db_path = Runtime.SqlConfig.DataBasePath.Replace("~", AppDomain.CurrentDomain.BaseDirectory);

            if (!Installer.HasInstall && File.Exists(db_path))
                File.Delete(db_path);

            dop.DataDriver.CreateDataBase(db_path, Runtime.SqlConfig.PassWord);

            //创建表：User
            dop.CreateTable<User>();
            dop.Insert(user);
            //创建表：Article
            dop.CreateTable<Article>();
            //创建表：Category
            dop.CreateTable<Category>();

            //保存数据库配置
            string sql_config_path = AppDomain.CurrentDomain.BaseDirectory + SystemCoreStrings.FILE_CORE_SQLCONFIG;
            Runtime.SqlConfig.Save(sql_config_path);

            //创建安装安全锁
            File.Create(AppDomain.CurrentDomain.BaseDirectory + SystemCoreStrings.FILE_CORE_INSTALL_LOCK);
        }

        public static bool HasInstall
        {
            get { return File.Exists(AppDomain.CurrentDomain.BaseDirectory + SystemCoreStrings.FILE_CORE_INSTALL_LOCK); }
        }
    }
}
