using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("XiaCi", "XiaCiID")]
    public class XiaCi
    {
        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string XiaCiID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string XiaCiContent { get; set; }
    }
}
