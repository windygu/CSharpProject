using System;

namespace Roo.Data
{
    /// <summary>
    /// 模型标识属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DataObjectAttribute : Attribute
    {
        public DataObjectAttribute(string table, string KeyS)
        {
            this.Table = table;
            this.KeyS = KeyS;
        }

        public string Table { get; set; }

        public string KeyS { get; set; }
    }
}
