using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roo.Data
{
    public class SqlBuilderCreator
    {
        public static ISqlBuilder Get(SqlConfig config)
        {
            switch (config.DataDriverType)
            {
                case DataDriverType.Sqlite:
                    return new SqliteSqlBuilder(config);
            }
            return null;
        }
    }
}
