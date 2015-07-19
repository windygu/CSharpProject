using System;
using Roo.Data;

namespace Whats.Cloud
{
    [DataObject("BackUpInfo","BackUpID")]
    public class BackUpInfo
    {
        [DataField("NVARCHAR(50)")]
        public string BackUpID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string FileName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string StoreName { get; set; }

        [DataField("DATETIME")]
        public DateTime BackUpTime { get; set; }
    }
}
