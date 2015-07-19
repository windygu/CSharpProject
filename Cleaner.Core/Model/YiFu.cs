using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("YiFu", "ClotheID")]
    public class YiFu
    {
        [DataField("NVARCHAR(50)", IsPrimary = true, Description = "衣服编号")]
        public string ClotheID { get; set; }

        [DataField("NVARCHAR(50)", Description = "衣服名称")]
        public string ClotheType { get; set; }

        [DataField("NVARCHAR(50)", Description = "瑕疵")]
        public string XiaCi { get; set; }

        [DataField("NVARCHAR(50)", Description = "价格")]
        public string Price { get; set; }

        [DataField("NVARCHAR(50)", Description = "衣单号码")]
        public string TicketID { get; set; }

        [DataField("NVARCHAR(50)", Description = "颜色")]
        public string Color { get; set; }

        [DataField("NVARCHAR(50)", Description = "状态")]
        public string State { get; set; }

        [DataField("NVARCHAR(50)", Description = "品牌")]
        public string PinPai { get; set; }

        [DataField("NVARCHAR(50)", Description = "备注")]
        public string BeiZhu { get; set; }
    }
}
