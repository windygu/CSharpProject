using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;

namespace FreeRoo
{
    /// <summary>
    /// 栏目模型
    /// </summary>
    [DataObject("Category", "CategoryName")]
    public class Category
    {

        [DataField("NVARCHAR(50)", IsPrimary = true)]
        public string CategoryName { get; set; }

        [DataField("NVARCHAR(50)")]
        public string CTitle { get; set; }

        [DataField("NVARCHAR(50)")]
        public string CParentName { get; set; }
    }
}
