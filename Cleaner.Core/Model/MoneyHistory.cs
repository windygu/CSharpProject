using System;
using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("MoneyHistory", "MoneyID")]
    public class MoneyHistory
    {
        [DataField("NVARCHAR(50)", Description = "记录编号")]
        public string MoneyID { get; set; }

        [DataField("NVARCHAR(50)", Description = "会员编号")]
        public string UserID { get; set; }

        [DataField("NVARCHAR(50)", Description = "会员名称")]
        public string UserName { get; set; }

        [DataField("DOUBLE", Description = "实收")]
        public double ShiShouMoney { get; set; }        //实际收入

        [DataField("DOUBLE", Description = "赠送")]
        public double ZengSongMoney { get; set; }       //赠送

        [DataField("DOUBLE", Description = "记录前余额")]
        public double BeforeMoney { get; set; }         //充值前

        [DataField("DOUBLE", Description = "金额")]
        public double Money { get; set; }               //现在余额

        [DataField("DATETIME", Description = "时间")]
        public DateTime MoneyTime { get; set; }         //充值时间

        [DataField("NVARCHAR(50)", Description = "备注")]
        public string BeiZhu { get; set; }

    }
}
