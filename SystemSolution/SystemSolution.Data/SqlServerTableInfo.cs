using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Common.Extend;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    public class SqlServerTableInfo<T> : TableInfo where T : BaseModel, new()
    {
        private string _selectByIdSql;
        private string _selectAllSql;
        private string _insertSql;
        private string _updateSql;
        private string _deleteSql;
        public SqlServerTableInfo(string modelName, string physicalName, string identify, string primaryKey, List<string> allFields, List<string> fieldsWithNoIdentify)
            : base(modelName, physicalName, identify, primaryKey, allFields, fieldsWithNoIdentify)
        {
            this.Properties = typeof(T).GetProperties();
        }

        /// <summary>
        /// 创建SQL语句：查询单个
        /// </summary>
        public string GenerateSelectByIdSql
        {
            get
            {
                if (!string.IsNullOrEmpty(_selectByIdSql))
                    return _selectByIdSql;
                var sql = new StringBuilder();
                sql.Append("SELECT ");
                sql.Append(AllFields.Select(o => $"[{o}]").ToArray().JoinString(","));
                sql.AppendFormat(" FROM [{0}] ", PhysicalName);
                sql.AppendFormat(" WHERE [{0}] = {{0}} ", PrimaryKey);
                _selectByIdSql = sql.ToString();
                return _selectByIdSql;
            }
        }

        /// <summary>
        /// 创建SQL语句：查询所有
        /// </summary>
        /// <returns></returns>
        public string GenerateSelectAllSql
        {
            get
            {
                if (!string.IsNullOrEmpty(_selectAllSql))
                    return _selectAllSql;
                var sql = new StringBuilder();
                sql.Append("SELECT ");
                sql.Append(AllFields.Select(o => $"[{o}]").ToArray().JoinString(","));
                sql.AppendFormat(" FROM [{0}] ", PhysicalName);
                _selectAllSql = sql.ToString();
                return _selectAllSql;
            }
        }

        /// <summary>
        /// 创建SQL语句：插入
        /// </summary>
        /// <returns></returns>
        public string GenerateInsertSql
        {
            get
            {
                if (!string.IsNullOrEmpty(_insertSql))
                    return _insertSql;

                var fields = FieldsWithNoIdentify.Select(o => $"[{o}]").ToArray().JoinString(",");
                var values = FieldsWithNoIdentify.Select(o => $"@{o}").ToArray().JoinString(",");

                var sql = new StringBuilder();
                sql.Append("INSERT INTO [");
                sql.Append(PhysicalName);
                sql.AppendFormat("]({0}) VALUES({1});", fields, values);
                sql.Append("select @@IDENTITY;");
                _insertSql = sql.ToString();
                return _insertSql;
            }
        }

        /// <summary>
        /// 创建SQL语句：更新
        /// </summary>
        /// <returns></returns>
        public string GenerateUpdateSql
        {
            get
            {
                if (!string.IsNullOrEmpty(_updateSql))
                    return _updateSql;

                var values = FieldsWithNoIdentify.Select(o => $"[{o}]=@{o}").ToArray().JoinString(",");
                var sql = new StringBuilder();
                sql.Append("UPDATE [");
                sql.Append(PhysicalName);
                sql.AppendFormat("] SET {0} WHERE [{1}]={{0}}", values, PrimaryKey);
                sql.Append("select @@IDENTITY;");
                _updateSql = sql.ToString();
                return _updateSql;
            }
        }

        /// <summary>
        /// 创建SQL语句：删除
        /// </summary>
        /// <returns></returns>
        public string GenerateDeleteSql
        {
            get
            {
                if (!string.IsNullOrEmpty(_deleteSql))
                    return _deleteSql;
                var sql = new StringBuilder();
                sql.Append("DELETE FROM [");
                sql.Append(PhysicalName);
                sql.AppendFormat("] WHERE [{0}]={{0}}", PrimaryKey);
                _deleteSql = sql.ToString();
                return _deleteSql;
            }
        }
    }
}
