using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DbSqlHelper.Service
{
    public class SqlServerConnString
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static readonly string ConnString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
    }
}
