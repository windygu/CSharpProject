using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Roo.Data
{
    public interface IDataDriver
    {
        int ExecuteNonQuery(string sql);
        bool ExcuteTransaction(string sql);
        DataSet ExecuteDataSet(string sql);
        IDataReader ExecuteDataReader(string sql);
        object ExecuteScalar(string sql);
        bool ExistDataBase(string dbPath);
        bool ExistTable(string tableName);
        void CreateDataBase(string dbPath);
        void CreateDataBase(string dbPath,string pwd);
    }
}
