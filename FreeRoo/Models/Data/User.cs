using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;

namespace FreeRoo
{
    /// <summary>
    /// 用户模型
    /// </summary>
    [DataObject("User", "UserID")]
    public class User
    {
        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string UserID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UPWD { get; set; }

        [DataField("INT")]
        public int USex { get; set; }

        [DataField("INT")]
        public int UType { get; set; }
    }
}
