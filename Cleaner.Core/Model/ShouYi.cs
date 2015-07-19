using System;
using Roo.Data;

namespace Cleaner.Core
{
    [DataObject("ShouYi", "TicketID")]
    public class ShouYi
    {
        [DataField("NVARCHAR(50)")]
        public string TicketID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UserID { get; set; }

        [DataField("NVARCHAR(50)")]
        public string UserName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Address { get; set; }

        [DataField("NVARCHAR(50)")]
        public string PhoneNo { get; set; }

        [DataField("NVARCHAR(50)")]
        public string PutWay { get; set; }

        [DataField("NVARCHAR(50)")]
        public string Price { get; set; }

        [DataField("NVARCHAR(50)")]
        public string State { get; set; }

        [DataField("NVARCHAR(50)")]
        public string MoneyState { get; set; }

        [DataField("DATETIME")]
        public DateTime ShouYiDateTime { get; set; }

        [DataField("DATETIME")]
        public DateTime QuYiDateTime { get; set; }

        [DataField("NVARCHAR(50)")]
        public string BeiZhu { get; set; }

        [DataField("DOUBLE")]
        public double ZheKou { get; set; }
    }
}
