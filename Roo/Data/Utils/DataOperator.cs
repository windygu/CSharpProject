using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Roo.Data
{
    public class DataOperator
    {
        public IDataDriver DataDriver { get; set; }

        public ISqlBuilder SqlBuilder { get; set; }

        private SqlConfig Config;
        
        public DataOperator(SqlConfig sqlConfig)
        {
            this.Config = sqlConfig;
            this.SqlBuilder = SqlBuilderCreator.Get(this.Config);
            this.DataDriver = DataDriverBuilder.Get(this.Config, this.SqlBuilder);
            this.InsertIntoBuilder = new StringBuilder();
        }
        
        #region PublicMethod
        
        public void Delete(object data)
        {
            string sql = this.SqlBuilder.Delete(data);
            this.DataDriver.ExecuteNonQuery(sql);
        }
        public void Delete<T>(T data)
        {
            string sql = this.SqlBuilder.Delete<T>(data);
        }
        private StringBuilder InsertIntoBuilder;
        public void Insert(object data)
        {
            string sql = this.SqlBuilder.InsertInto(data);
            this.InsertIntoBuilder.Append(sql + ";");
        }
        public void Insert<T>(T data)
        {
            string sql = this.SqlBuilder.Insert<T>(data);
            this.InsertIntoBuilder.Append(sql + ";");
        }
        public void Commit()
        {
            this.DataDriver.ExcuteTransaction(this.InsertIntoBuilder.ToString());
            this.InsertIntoBuilder = new StringBuilder();
        }
        public void Update(object data)
        {
            string sql = this.SqlBuilder.Update(data);
            this.DataDriver.ExecuteNonQuery(sql);
        }
        public void Update<T>(T data)
        {
            string sql = this.SqlBuilder.Update(data);
            this.DataDriver.ExecuteNonQuery(sql);
        }
        public object SelectSingle(object data, string where = "")
        {
            var result = this.Select(data, where, "", 1, 0);
            if (result.Count > 0)
                return result[0];
            else
                return null;
        }
        public T Select<T>(T data)
        {
            return (T)this.SelectSingle(data);
        }
        public List<T> Select<T>()
        {
            return this.Select<T>((T)Activator.CreateInstance<T>(), "", "", 0, 0);
        }
        public T SelectSingle<T>(string where = "")
        {
            var result = this.Select<T>((T)Activator.CreateInstance(typeof(T)), "", "", 1, 0);
            if (result.Count > 0)
                return result[0];
            else
                return default(T);
        }
        public List<object> SelectAll(object data, string where="", string orderBy="")
        {
            return this.Select(data, where, orderBy, 0, 0);
        }
        public List<T> SelectAll<T>(T data, string where = "", string orderBy = "")
        {
            return this.Select(data, where, orderBy, 0, 0);
        }
        public List<object> Select(object data, string where, string orderBy, int count, int start)
        {
            string sql = this.SqlBuilder.Select(data, where, orderBy, count, start);
            List<object> list = new List<object>();

            DataSet ds = DataDriver.ExecuteDataSet(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var o = (object)Activator.CreateInstance(data.GetType());
                foreach (var propertyInfo in o.GetType().GetProperties())
                {
                    propertyInfo.SetValue(o, row[propertyInfo.Name], null);
                }
                list.Add(o);
            }
            return list;
        }
        public List<T> Select<T>(T data,string where,string orderBy,int count,int start)
        {
            string sql = this.SqlBuilder.Select(data, where, orderBy, count, start);
            List<T> list = new List<T>();

            DataSet ds = DataDriver.ExecuteDataSet(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var o = (object)Activator.CreateInstance(data.GetType());
                foreach (var propertyInfo in o.GetType().GetProperties())
                {
                    propertyInfo.SetValue(o, row[propertyInfo.Name], null);
                }
                list.Add((T)o);
            }
            return list;
        }
        public List<T> Select<T>(string sql)
        {
            List<T> list = new List<T>();
            var ds = this.DataDriver.ExecuteDataSet(sql);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                var o = (T)Activator.CreateInstance<T>();
                foreach(var propertyInfo in o.GetType().GetProperties())
                {
                    propertyInfo.SetValue(o, row[propertyInfo.Name], null);
                }
                list.Add(o);
            }
            return list;
        }
        public List<T> Select<T>(int count)
        {
            return this.Select<T>((T)Activator.CreateInstance(typeof(T)), "", "", count, 0);
        }
        public void CreateTable<T>()
        {
            this.DataDriver.ExecuteNonQuery(this.SqlBuilder.CreateTable(typeof(T)));
        }
        
        public void CreateTable(Type type)
        {
            this.DataDriver.ExecuteNonQuery(this.SqlBuilder.CreateTable(type));
        }
        
        public int Count<T>()
        {
            string sql = this.SqlBuilder.Count(typeof(T));
            return int.Parse(this.DataDriver.ExecuteScalar(sql).ToString());
        }
        public int Count(Type type)
        {
            string sql = this.SqlBuilder.Count(type);
            return int.Parse(this.DataDriver.ExecuteScalar(sql).ToString());
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        ///   得到初始值
        /// </summary>
        /// <param name="TType"></param>
        /// <returns></returns>
        private object GetTypeValue(Type TType)
        {
            if (TType.FullName.Equals(TypeCode.DateTime.GetType()))
            {
                return DateTime.Now;
            }
            return null;
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
            if (o.GetType().FullName == typeof(string).FullName)
                return "'" + o + "'";
            else if (o.GetType().FullName == DateTime.Now.GetType().FullName)
                return "'" + o + "'";
            else
                return o.ToString();
        }
        #endregion
    }
}
