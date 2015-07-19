using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("XiaCi", "XiaCiID")]
    public class XiaCi
    {
        [DataField("NVARCHAR(50)", IsPrimary = true, Description = "编号")]
        public string XiaCiID { get; set; }

        [DataField("NVARCHAR(50)", Description = "瑕疵")]
        public string XiaCiContent { get; set; }
    }
}
