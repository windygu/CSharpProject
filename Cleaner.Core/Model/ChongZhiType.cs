using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("ChongZhiType", "ChonZhiMoney")]
    public class ChongZhiType
    {
        [DataField("DOUBLE")]
        public double ChonZhiMoney { get; set; }

        [DataField("DOUBLE")]
        public double ZengSongMoney { get; set; }
    }
}
