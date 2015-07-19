using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Roo.Data
{
    public class DataOperatorEntity
    {
        string _table = "";
        string[] _field;
        Dictionary<string, object> _whereDic = new Dictionary<string, object>();
        Dictionary<string, object> _orderByDic = new Dictionary<string, object>();
        string current = "";
        Type _Type;
        public DataOperatorEntity Create<T>()
        {
            this._Type = typeof(T);
            return this;
        }
        public DataOperatorEntity Select<T>(params string[] fields)
        {
            _table = typeof(T).Name;
            _field = fields;
            return this;
        }
        public DataOperatorEntity Insert<T>(T data)
        {
            return this;
        }
        public DataOperatorEntity Where(string field)
        {
            _whereDic[field] = "";
            current = field;
            return this;
        }
        public DataOperatorEntity Equal(string condition)
        {
            _whereDic[current] = condition;
            return this;
        }
        public DataOperatorEntity And(string field)
        {
            _whereDic[field] = field;
            current = field;
            return this;
        }
        public DataOperatorEntity NotEqual(string condition)
        {
            _whereDic[current] = condition;
            return this;
        }
        public DataOperatorEntity OrderBy(string orderBy)
        {
            _orderByDic[orderBy] = "";
            current = orderBy;
            return this;
        }
        public DataOperatorEntity DESC()
        {
            _orderByDic[current] = "DESC";
            return this;
        }
        public DataOperatorEntity ASC()
        {
            _orderByDic[current] = "ASC";
            return this;
        }
        public override string ToString()
        {
            return "";
        }
    }
}
