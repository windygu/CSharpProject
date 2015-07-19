using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("PinPai","PinPaiID")]
    public class PinPai
    {
        [DataField("NVARCHAR(50)")]
        public string PinPaiID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string PinPaiName { get; set; }

        
    }
}
