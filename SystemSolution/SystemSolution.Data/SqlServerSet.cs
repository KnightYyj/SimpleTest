using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Common;
using SystemSolution.Common.Extend;
using SystemSolution.GenericCache;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    //Internal：访问仅限于当前程序集
    internal class SqlServerSet<T> : ISet<T>
         where T : BaseModel, new()
    {

        private readonly string _connectionString;
        private readonly SqlServerTableInfo<T> _table;

        public SqlServerSet(string connectionString)
        {
            this._connectionString = connectionString;
            if (GenericCache<SqlServerTableInfo<T>>.Instance == null)
            {
                var tbInfo = GenericCache<List<TableInfo>>.Instance.FirstOrDefault(o => o.ModelName == typeof(T).Name);
                if (tbInfo == null)
                    throw new Exception("没有找到相关table info");
                GenericCache<SqlServerTableInfo<T>>.Instance = new SqlServerTableInfo<T>(tbInfo.ModelName, tbInfo.PhysicalName, tbInfo.Identity, tbInfo.PrimaryKey, tbInfo.AllFields, tbInfo.FieldsWithNoIdentify);
            }
            _table = GenericCache<SqlServerTableInfo<T>>.Instance;
        }


        /// <summary>
        /// 按ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            var sql = _table.GenerateSelectByIdSql.FormatTo(id);
            return this.DbHelper(sql, cmd =>
            {
                var t = new T();
                var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    t = null;
                    return t;
                }
            foreach (var item in _table.Properties)
            {
                if (reader[item.Name] != DBNull.Value)
                    item.SetValue(t, reader[item.Name]);//.Name]
                }
                return t;
            });
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public List<T> GetList(Func<T, bool> func)
        {
            var sql = _table.GenerateSelectAllSql;
            var returnList = this.DbHelper(sql, cmd =>
            {
                var list = new List<T>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var t = new T();
                    foreach (var item in _table.Properties)
                    {
                        if (reader[item.Name] != DBNull.Value)
                            item.SetValue(t, reader[item.Name]);
                    }
                    list.Add(t);
                }
                return list;
            });
            return returnList.Where(func).ToList();
        }

        /// <summary>
        /// 插入,返回插入ID
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(T t)
        {
            var sql = _table.GenerateInsertSql;
            return this.DbHelper(sql, cmd =>
            {
                foreach (var item in _table.Properties)
                {
                    var value = item.GetValue(t);
                    SqlParameter param = new SqlParameter("@" + item.Name, value);
                    cmd.Parameters.Add(param);
                }
                var obj = cmd.ExecuteScalar();
                int.TryParse(obj.ToString(), out int id);
                return id;
            });
        }
        

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(T t)
        {
            var sql = _table.GenerateUpdateSql.FormatTo(t.Id);
            return this.DbHelper(sql, cmd =>
            {
                foreach (var item in _table.Properties)
                {
                    var value = item.GetValue(t);
                    var param = new SqlParameter("@" + item.Name, value);
                    cmd.Parameters.Add(param);
                }
                return cmd.ExecuteNonQuery();
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            var sql = _table.GenerateDeleteSql.FormatTo(id);
            return this.DbHelper(sql, (cmd) =>
            {
                return cmd.ExecuteNonQuery();
            });
        }

        /// <summary>
        /// 仅仅重用代码
        /// </summary>
        private M DbHelper<M>(string sql, Func<SqlCommand, M> func)
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
