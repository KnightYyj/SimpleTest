using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service
{
    public static class DisplayNameExtend
    {
        /// <summary>
        /// 取属性字段的说明
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string DisplayFor<TModel>(this TModel t, string propertyName) where TModel : class
        {
            Type type = typeof(TModel);//获取类型
            var propertyInfo = type.GetProperty(propertyName);//获取指定属性
            var fieldInfo = type.GetField(propertyName);
            var displayValue = "";
            if (propertyInfo != null)
            {
                displayValue = propertyInfo.Name;
                if (propertyInfo.IsDefined(typeof(DisplayNameAttribute), true))
                {
                    displayValue = (propertyInfo.GetCustomAttribute(typeof(DisplayNameAttribute),true) as DisplayNameAttribute)?.DispalyNameValue; //非空就执行DispalyNameValue
                }
            }
            if (fieldInfo != null)
            {
                displayValue = fieldInfo.Name;
                if (fieldInfo.IsDefined(typeof(DisplayNameAttribute), true))
                {
                    displayValue = (fieldInfo.GetCustomAttribute(typeof(DisplayNameAttribute), true) as DisplayNameAttribute)?.DispalyNameValue;
                }
            }
            return displayValue;

        }
    }
}
