using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("PriceTable", "YiFuPriceID")]
    public class YiFuPriceType
    {
        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string YiFuPriceID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string YiFuName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string DanWei { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Price { get; set; }

        [DataField("INT")]
        public int IsZheKou { get; set; }

        [DataField("NVARCHAR(50)")]
        public int Cat { get; set; }

    }
}
