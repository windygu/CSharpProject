using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRoo
{
    public class IDGetter
    {
        public static string GUID { get { return Guid.NewGuid().ToString(); } }

        public static string TIME_ID { get { return DateTime.Now.ToString("yyyyMMddHHmmssffff"); } }
    }
}
