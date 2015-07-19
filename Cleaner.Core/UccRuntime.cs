using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Roo.Data;

namespace Cleaner.Core
{
    public class UccRuntime
    {
        public static SqlConfig SqlConfig;
        public static DataOperator Dop;
        public static StoreInfo StoreInfo;
        static UccRuntime()
        {
            string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/CleanerData/";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);
            if (!File.Exists(dataDir + "db.db") && File.Exists(AppDomain.CurrentDomain.BaseDirectory + "db.db"))
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + "db.db", dataDir + "db.db");

            SqlConfig = new SqlConfig(DataDriverType.Sqlite, "UCC_", "", dataDir + "db.db");
            Dop = new DataOperator(SqlConfig);
            string path = AppDomain.CurrentDomain.BaseDirectory + "store.json";
            if (!File.Exists(path))
            {
                StoreInfo = new StoreInfo();
                StoreInfo.Name = "美国UCC国际洗衣";
                StoreInfo.PhoneNo = "13761561263";
                StoreInfo.Address = "闵行区金平路19号近鹤庆路";
                File.WriteAllText(path, Roo.Data.DataConverter.RenderJson(Roo.Data.DataConverter.ObjectToJson(StoreInfo)), Encoding.Default);
            }
            else
            {
                StoreInfo = DataConverter.JsonToObject<StoreInfo>(File.ReadAllText(path, Encoding.Default));
            }
        }
    }
}
