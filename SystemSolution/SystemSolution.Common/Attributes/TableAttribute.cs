using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class |(AttributeTargets.Property))]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 对应数据库实际的表名
        /// </summary>
        public string Remark { get; private set; }

        public TableAttribute(string name)
        {
            this.Remark = name;
        }
    }
}
