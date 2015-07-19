using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cleaner.Core
{
    public class StaticInfos
    {
        public static List<string> PutWay { get; set; }
        public static List<string> ClotheType { get; set; }

        public static DataTable ClotheTypeDataTable { get; set; }
        static StaticInfos()
        {
            ClotheTypeDataTable = SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/clothes.txt");
        }
    }
}
