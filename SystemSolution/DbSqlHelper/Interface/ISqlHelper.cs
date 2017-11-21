using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbSqlHelper.Interface
{
    public interface ISqlHelper
    {
        //T GetEntity<T>(int id) where T : BaseModel;
        //IEnumerable<T> GetEntityList<T>() where T : BaseModel;
        //bool InsertEntity<T>(T model) where T : BaseModel;
        //bool DeleteEntity<T>(int id) where T : BaseModel;

        /// <summary>
        /// 执行SQL语句或存储过程（把具体执行封装到委托里）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="isProc"></param>
        /// <param name="paras"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        T ExecuteSql<T>(string sql, bool isProc, SqlParameter[] paras, Func<IDbCommand, T> action);




    }
    
}
