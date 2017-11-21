using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SystemSolution.Data
{
    public class TableInfo
    {
        private readonly string _primaryKey;

        /// <summary>
        /// 主要封装一些表信息。
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="physicalName"></param>
        /// <param name="identify"></param>
        /// <param name="primaryKey"></param>
        /// <param name="allFields"></param>
        /// <param name="fieldsWithNoIdentify"></param>
        public TableInfo(string modelName, string physicalName, string identify, string primaryKey, List<string> allFields, List<string> fieldsWithNoIdentify)
        {
            this.ModelName = modelName;
            this.PhysicalName = physicalName;
            this.Identity = identify;

            this._primaryKey = primaryKey;

            this.AllFields = allFields;
            this.FieldsWithNoIdentify = fieldsWithNoIdentify;
        }

        /// <summary>
        /// 物理表名
        /// </summary>
        public string PhysicalName { get; private set; }


        /// <summary>
        /// 对应Model
        /// </summary>
        public string ModelName { get; private set; }


        /// <summary>
        /// 自增字段
        /// </summary>
        public string Identity { get; private set; }



        /// <summary>
        /// 自增字段
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                if (string.IsNullOrEmpty(_primaryKey)) return "Id";
                return _primaryKey;
            }
        }

        /// <summary>
        /// 所有字段
        /// </summary>
        public List<string> AllFields { get; private set; }

        /// <summary>
        /// 除开自增字段的所有字段
        /// </summary>
        public List<string> FieldsWithNoIdentify { get; private set; }

        /// <summary>
        /// 所有属性
        /// </summary>
        public PropertyInfo[] Properties { get; protected set; }
    }
}
