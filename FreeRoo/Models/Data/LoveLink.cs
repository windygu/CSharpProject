using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roo.Data;

namespace FreeRoo
{
    [DataObject("LoveLink", "LinkName")]
    public class LoveLink
    {

        [DataField("NVARCHAR(50)")]
        public string LTitle { get; set; }

        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string LinkName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string LHref { get; set; }
    }
}
