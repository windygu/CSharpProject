using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roo.Data
{
    public class DataDriverBuilder
    {
        public static IDataDriver Get(SqlConfig config, ISqlBuilder sqlBuilder)
        {
            switch (config.DataDriverType)
            {
                case DataDriverType.Sqlite:
                    return new SqliteDriver(config, sqlBuilder);
            }
            return null;
        }
    }
}
