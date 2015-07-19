using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Reflection;
using System.Text;
using System.Data.Sql;

namespace Roo.Data
{
    public class SqliteSqlBuilder : ISqlBuilder
    {
        private SqlConfig SqlConfig;
        
        public SqliteSqlBuilder(SqlConfig sqlConfig)
        {
            this.SqlConfig = sqlConfig;
        }

        #region PublicMethod
        public string ConnectionString()
        {
            SqliteConnectionStringBuilder sb = new SqliteConnectionStringBuilder();
            sb.DataSource = SqlConfig.DataBasePath.Replace("~", AppDomain.CurrentDomain.BaseDirectory);
            if (!string.IsNullOrEmpty(SqlConfig.PassWord))
                sb.Password = SqlConfig.PassWord;
            sb.Version = 3;
            string conn_string = sb.ToString();
            return conn_string;
        }
        
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 判断是否为所属类型的默认值
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private bool IsEmpty(object o)
        {
            if (o is string)
                return string.IsNullOrEmpty(o as string);
            if (o is int)
                return (int)o == default(int);
            if (o is double)
                return (double)o == default(double);
            if (o is DateTime)
                return (DateTime)o == default(DateTime);

            return o == null;
        }
        private string GetPrimaryKey(string[] keys)
        {
            string primaryKeyS = ",\r\n\tPRIMARY KEY";
            for (int j = 0; j < keys.Length; j++)
            {
                if (j == 0)
                    primaryKeyS += "(" + keys[j];
                else if (j == keys.Length - 1)
                    primaryKeyS += "," + keys[j] + ")";
                else
                    primaryKeyS += "," + keys[j];
            }
            return primaryKeyS;
        }
        /// <summary>
        /// 获取字段最终填入SQL语句中的值
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetValue(PropertyInfo propertyInfo, object data)
        {
            var o = propertyInfo.GetValue(data, null);
            if (propertyInfo.PropertyType.FullName == typeof(string).FullName)
                return "'" + o + "'";
            else if (propertyInfo.PropertyType.FullName == DateTime.Now.GetType().FullName)
                return "'" + ((DateTime)o).ToString("s") + "'";
            else
                return o.ToString();
        }

        #endregion

        public string Select(object data, string where, string orderBy, int count, int start)
        {
            DataObjectAttribute dataObject = data.GetType().GetCustomAttributes(typeof(DataObjectAttribute), false)[0] as DataObjectAttribute;
            StringBuilder sb = new StringBuilder("SELECT * FROM " + SqlConfig.PreFix + dataObject.Table);
            PropertyInfo[] propertyInfos = data.GetType().GetProperties();
            Dictionary<PropertyInfo, object> hasValue = new Dictionary<PropertyInfo, object>();

            foreach (PropertyInfo item in propertyInfos)
            {
                var value = item.GetValue(data, null);
                if (!IsEmpty(value))
                    hasValue.Add(item, value);
            }
            List<PropertyInfo> list = new List<PropertyInfo>(hasValue.Keys);

            for (int i = 0; i < list.Count; i++)
            {
                PropertyInfo item = list[i];
                object value = hasValue[item];

                if (i == 0)
                    sb.Append(" WHERE " + item.Name + " = " + GetValue(item, data) + " ");
                else
                    sb.Append(" AND " + item.Name + " = " + GetValue(item, data) + " ");

            }
            if (list.Count > 0 && !string.IsNullOrEmpty(where))
                sb.Append(" AND " + where);
            else if (list.Count == 0 && !string.IsNullOrEmpty(where))
                sb.Append(" WHERE " + where);
            sb.Append(!string.IsNullOrEmpty(orderBy) ? " ORDER BY " + orderBy : "");
            sb.Append(count > 0 && start >= 0 ? " LIMIT " + count + " OFFSET " + start : "");
            return sb.ToString();
        }
        
        public string InsertInto(object data)
        {
            DataObjectAttribute dataObject = data.GetType().GetCustomAttributes(typeof(DataObjectAttribute), false)[0] as DataObjectAttribute;
            string tableName = dataObject.Table;
            PropertyInfo[] propertyInfos = data.GetType().GetProperties();
            StringBuilder sb = new StringBuilder("INSERT INTO " + SqlConfig.PreFix + tableName);
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (i == 0)
                    sb.Append(" (" + propertyInfos[i].Name);
                else if (i == propertyInfos.Length - 1)
                    sb.Append("," + propertyInfos[i].Name + ")");
                else
                    sb.Append("," + propertyInfos[i].Name);
            }
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (i == 0)
                    sb.Append(" VALUES(" + GetValue(propertyInfos[i], data));
                else if (i == propertyInfos.Length - 1)
                    sb.Append(" ," + GetValue(propertyInfos[i], data) + ")");
                else
                    sb.Append(" ," + GetValue(propertyInfos[i], data));
            }
            return sb.ToString();
        }

        public string Delete(object data)
        {
            DataObjectAttribute dataObject = data.GetType().GetCustomAttributes(typeof(DataObjectAttribute), false)[0] as DataObjectAttribute;
            string[] keys = dataObject.KeyS.Split(',');
            string tableName = dataObject.Table;

            StringBuilder sb = new StringBuilder("DELETE FROM " + SqlConfig.PreFix + tableName);
            for (int i = 0; i < keys.Length; i++)
            {
                PropertyInfo f = data.GetType().GetProperty(keys[i]);
                if (i == 0)
                    sb.Append(" WHERE " + keys[i] + " = " + GetValue(f, data) + " ");
                else
                    sb.Append(" AND " + keys[i] + " = " + GetValue(f, data) + " ");
            }
            return sb.ToString();
        }

        public string Count(Type type)
        {
            return "SELECT COUNT(*) FROM " + SqlConfig.PreFix + type.Name;
        }

        public string CreateTable(Type type)
        {
            DataObjectAttribute dataAttribute = type.GetCustomAttributes(typeof(DataObjectAttribute), false)[0] as DataObjectAttribute;
            string[] keys = dataAttribute.KeyS.Split(',');
            StringBuilder sb = new StringBuilder("CREATE TABLE " + SqlConfig.PreFix + dataAttribute.Table);
            PropertyInfo[] propertyInfos = type.GetProperties();
            
            //对于每个字段进行操作
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                //获取当前字段属性
                object[] fieldAttributes = propertyInfos[i].GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (fieldAttributes.Length != 0)
                {
                    var fieldAttribute = fieldAttributes[0] as DataFieldAttribute;
                    if (keys.Length > 1)    //不止一个字段作为主键
                    {
                        if (i == 0 && i != propertyInfos.Length - 1)
                            sb.Append("\r\n(\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult);
                        else if (i > 0 && i != propertyInfos.Length - 1)
                            sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult);
                        else if (i > 0 && i == propertyInfos.Length - 1)
                        {
                            sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult);
                            var primaryKeyS = GetPrimaryKey(keys);
                            sb.Append(primaryKeyS + "\r\n)\r\n");
                        }
                    }
                    else
                    {
                        if (keys[0].Equals(propertyInfos[i].Name))
                        {
                            if (i == 0 && i != propertyInfos.Length - 1)
                                sb.Append("\r\n(\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult + " PRIMARY KEY");
                            else if (i > 0 && i != propertyInfos.Length - 1)
                                sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult + " PRIMARY KEY");
                            else if (i == propertyInfos.Length - 1)
                                sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult + " PRIMARY KEY" + "\r\n)\r\n");
                        }
                        else
                        {
                            if (i == 0 && i != propertyInfos.Length - 1)
                                sb.Append("\r\n(\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult);
                            else if (i > 0 && i != propertyInfos.Length - 1)
                                sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult);
                            else if (i == propertyInfos.Length - 1)
                                sb.Append(",\r\n\t" + propertyInfos[i].Name + " " + fieldAttribute.SqlTypeResult + "\r\n)\r\n");
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public string Update(object data)
        {
            DataObjectAttribute dataObject = data.GetType().GetCustomAttributes(typeof(DataObjectAttribute), false)[0] as DataObjectAttribute;
            string[] keys = dataObject.KeyS.Split(',');
            string tableName = dataObject.Table;
            PropertyInfo[] propertyInfos = data.GetType().GetProperties();
            StringBuilder sb = new StringBuilder("UPDATE " + SqlConfig.PreFix + tableName);

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (i == 0)
                    sb.Append(" SET " + propertyInfos[i].Name + " = " + GetValue(propertyInfos[i], data));
                else
                    sb.Append("," + propertyInfos[i].Name + " = " + GetValue(propertyInfos[i], data));
            }

            for (int i = 0; i < keys.Length; i++)
            {
                PropertyInfo f = data.GetType().GetProperty(keys[i]);
                if (i == 0)
                    sb.Append(" WHERE " + keys[i] + " = " + GetValue(f, data) + " ");
                else
                    sb.Append(" AND " + keys[i] + " = " + GetValue(f, data) + " ");
            }
            return sb.ToString();
        }

        #region ISqlBuilder 成员

        public string Insert<T>(T data)
        {
            return this.InsertInto(data);
        }

        public string CreateTable<T>()
        {
            return this.CreateTable(typeof(T));
        }

        public string Count<T>()
        {
            return this.Count(typeof(T));
        }

        public string Select<T>()
        {
            return this.Select<T>("", "", 0, 0);
        }

        public string Select<T>(int count)
        {
            return this.Select<T>(count, 0);
        }

        public string Select<T>(int count, int start)
        {
            return this.Select<T>("", "", count, start);
        }

        public string Select<T>(string where)
        {
            return this.Select<T>(where, 1);
        }

        public string Select<T>(string where, int count)
        {
            return this.Select<T>(where, count, 0);
        }

        public string Select<T>(string where, int count, int start)
        {
            return this.Select<T>(where, "", count, start);
        }

        public string Select<T>(string where, string orderby, int count)
        {
            return this.Select<T>(where, orderby, count, 0);
        }

        public string Select<T>(string where, string orderby, int count, int start)
        {
            return this.Select(Activator.CreateInstance<T>(), where, orderby, count, start);
        }

        #endregion

        #region ISqlBuilder 成员


        public string Delete<T>(T data)
        {
            return this.Delete(data);
        }

        #endregion
    }
}
