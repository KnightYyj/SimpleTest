using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Common.Attributes;

namespace SystemSolution.Common.Extend
{
    public static class RemarkExtend
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo field = type.GetField(enumValue.ToString());
            if (field.IsDefined(typeof(ColumnAttribute), true))
            {
                ColumnAttribute displayNameAttribute = (ColumnAttribute)field.GetCustomAttribute(typeof(ColumnAttribute));
                return displayNameAttribute.ColName;
            }
            else
            {
                return enumValue.ToString();
            }
        }
    }
}
