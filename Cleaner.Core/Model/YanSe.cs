using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("YanSe", "YanSeID")]
    public class YanSe
    {
        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string YanSeID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string YanSeName { get; set; }
    }
}
