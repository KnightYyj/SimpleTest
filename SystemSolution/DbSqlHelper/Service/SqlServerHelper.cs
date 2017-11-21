using DbSqlHelper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DbSqlHelper.Service
{
    public class SqlServerHelper : ISqlHelper 
    {
        private readonly string _connectionString;//属于运行时变量.可以在类constructor(构造)里改变它的值

        /// <summary>
        /// 执行SQL语句或存储过程（把具体执行封装到委托里）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="isProc"></param>
        /// <param name="paras"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public T ExecuteSql<T>(string sql, bool isProc, SqlParameter[] paras, Func<IDbCommand, T> action)
        {
            throw new NotImplementedException();
        }

       

       



        /// <summary>
        /// 仅仅重用代码
        /// </summary>
        private T DbHelper<T>(string sql, Func<SqlCommand, T> func)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, conn);
                conn.Open();
                return func(command);
            }
        }
    }
}
