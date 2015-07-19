using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roo.Data
{
    /// <summary>
    /// 模型数据字段标识属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class DataFieldAttribute : Attribute
    {
        public DataFieldAttribute(string sqlTypeResult = "",
            bool isPrimary = false, bool isIdentity = false, string description = "")
        {
            this.SqlTypeResult = sqlTypeResult;
            this.Description = description;
            this.IsPrimary = isPrimary;
            this.IsIdentity = isIdentity;
        }
        public bool IsIdentity { get; set; }
        
        public string Description { get; set; }

        public string SqlTypeResult { get; set; }

        public bool IsPrimary { get; set; }

    }
}
