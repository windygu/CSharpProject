using System;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;

namespace Roo.Data
{
    public class SqliteDriver : IDataDriver
    {
        private SqlConfig SqlConfig;
        private ISqlBuilder SqlBuilder;

        public SqliteDriver(SqlConfig sqlConfig, ISqlBuilder sqlBuilder)
        {
            this.SqlConfig = sqlConfig;
            this.SqlBuilder = sqlBuilder;
        }

        #region Execute
        public bool ExcuteTransaction(string sql)
        {
            var cmds = sql.Split(';');
            using (SqliteConnection conn = new SqliteConnection(this.SqlConfig.ConnectionString))
            {
                conn.Open();
                SqliteCommand cmd = new SqliteCommand(conn);
                
                SqliteTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (var cmdSql in cmds)
                    {
                        cmd.CommandText = cmdSql;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    conn.Close();
                    throw new Exception(e.Message + "  sql:" + sql);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public int ExecuteNonQuery(string sql)
        {
            using (SqliteConnection conn = new SqliteConnection(this.SqlConfig.ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        int cout = -1;
                        cmd.CommandText = sql;
                        cout = cmd.ExecuteNonQuery();
                        return cout;
                    }
                    catch(Exception e)
                    {
                        conn.Close();
                        throw new Exception(e.Message + "\r\n" + e.StackTrace + "\r\n" + sql);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public DataSet ExecuteDataSet(string sql)
        {
            using (SqliteConnection conn = new SqliteConnection(this.SqlConfig.ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        SqliteDataAdapter adapter = new SqliteDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                    catch(Exception e)
                    {
                        conn.Close();
                        throw new Exception(e.Message + "<br>sql:" + sql + "<br>" + e.StackTrace.Replace("\n","<br>"));
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public IDataReader ExecuteDataReader(string sql)
        {
            using (SqliteConnection conn = new SqliteConnection(this.SqlConfig.ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        var reader = cmd.ExecuteReader();
                        return reader;
                    }
                    catch
                    {
                        conn.Close();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (SqliteConnection conn = new SqliteConnection(this.SqlConfig.ConnectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        object o = null;
                        cmd.CommandText = sql;
                        o = cmd.ExecuteScalar();
                        return o;
                    }
                    catch
                    {
                        conn.Close();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public bool ExistTable(string tableName)
        {
            string sql = "SELECT COUNT(*) FROM Sqlite_master WHERE type = 'table' AND name = '" + tableName + "'";
            if (int.Parse(this.ExecuteScalar(sql).ToString()) > 0)
                return true;
            else
                return false;
        }
        
        #endregion

        public void CreateDataBase(string dbPath, string pwd)
        {
            if (!File.Exists(dbPath))
            {
                SqliteConnection.CreateFile(dbPath);
                if (string.IsNullOrEmpty(pwd))
                {
                    using (SqliteConnection conn = new SqliteConnection("Data Source=" + dbPath))
                    {
                        try
                        {
                            conn.SetPassword(pwd);
                        }
                        catch
                        {
                            conn.Close();
                            throw;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
                throw new Exception("已经存在名叫：" + dbPath + "的数据库！");
        }

        public bool ExistDataBase(string dbPath)
        {
            return File.Exists(dbPath);
        }

        public void CreateDataBase(string dbPath)
        {
            if (!File.Exists(dbPath))
                SqliteConnection.CreateFile(dbPath);
            else
                throw new Exception("数据库：" + dbPath + "已经存在！");
        }
    }
}
