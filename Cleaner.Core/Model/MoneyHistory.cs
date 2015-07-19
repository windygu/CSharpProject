using System;
using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("MoneyHistory", "MoneyID")]
    public class MoneyHistory
    {
        [DataField("NVARCHAR(50)")]
        public string MoneyID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UserID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UserName { get; set; }

        [DataField("DOUBLE")]
        public double ShiShouMoney { get; set; }        //实际收入

        [DataField("DOUBLE")]
        public double ZengSongMoney { get; set; }       //赠送

        [DataField("DOUBLE")]
        public double BeforeMoney { get; set; }         //充值前

        [DataField("DOUBLE")]
        public double Money { get; set; }               //现在余额

        [DataField("DATETIME")]
        public DateTime MoneyTime { get; set; }         //充值时间

        [DataField("NVARCHAR(50)")]
        public string BeiZhu { get; set; }

    }
}
