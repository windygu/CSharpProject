using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roo.Data
{
    public interface ISqlBuilder
    {
        string ConnectionString();

        string Select(object data,string where, string orderBy, int count, int start);
        string InsertInto(object data);
        string Update(object data);
        string Delete(object data);
        string CreateTable(Type type);
        string Count(Type type);

        string Insert<T>(T data);
        string Delete<T>(T data);
        string CreateTable<T>();
        string Count<T>();
        string Select<T>();
        string Select<T>(int count);
        string Select<T>(int count, int start);
        string Select<T>(string where);
        string Select<T>(string where, int count);
        string Select<T>(string where, int count, int start);
        string Select<T>(string where, string orderby, int count);
        string Select<T>(string where, string orderby, int count, int start);

    }
}
