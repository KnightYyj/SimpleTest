using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Common.Attributes;

namespace SystemSolution.Common
{
    public static class AttributeManager
    {
        /// <summary>
        /// 获取映射表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTableName(this Type type)
        {
            string tableName = string.Empty;
            object[] attrs = type.GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                if (attr is TableAttribute)
                {
                    TableAttribute tableAttribute = attr as TableAttribute;
                    tableName = tableAttribute.Name;
                }
            }
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = type.Name;
            }
            return tableName;
        }

        /// <summary>
        /// 获取映射列名
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetColumnName(this PropertyInfo property)
        {
            string columnName = string.Empty;
            object[] attrs = property.GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                if (attr is ColumnAttribute)
                {
                    ColumnAttribute colAttr = attr as ColumnAttribute;
                    columnName = colAttr.ColName;
                }
            }
            if (string.IsNullOrEmpty(columnName))
            {
                columnName = property.Name;
            }
            return columnName;
        }

        /// <summary>
        /// 获取映射列名
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetbackColumnName(this PropertyInfo property)
        {
            string columnName = string.Empty;
            object[] attrs = property.GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                if (attr is ColumnAttribute)
                {
                    ColumnAttribute colAttr = attr as ColumnAttribute;
                    columnName = colAttr.ColName;
                }
            }
            if (string.IsNullOrEmpty(columnName))
            {
                columnName = property.Name;
            }
            return columnName;
        }


        /// <summary>
        /// 封装成一个泛型的数据校验方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool Validate<T>(Func<bool> func)
        {

            bool result = func.Invoke();


            return result;

        }
        private static bool Validate<T>(T t, Func<T, bool> func)
        {
            Type type = typeof(T);
            bool Result = true;
            if (!func.Invoke(t))
            {
                Result = false;
            }
            return Result;
        }

    }
}
