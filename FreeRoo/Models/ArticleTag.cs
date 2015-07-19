using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roo.Data;

namespace FreeRoo
{
    [DataObject("ArticleTag","TagName")]
    public class ArticleTag
    {
        [DataField("NVARCHAR(50)")]
        public string TagName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string TagTitle { get; set; }
    }
}