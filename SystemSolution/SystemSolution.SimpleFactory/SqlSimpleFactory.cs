using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SystemSolution.SimpleFactory
{
    public static class SqlSimpleFactory
    {
        //private static string dbConnectionString = ConfigurationManager.AppSettings["dbConnectionString"];
        private static string IRaceTypeConfigReflection = ConfigurationManager.AppSettings["serviceAssembly"];  //TypeDll
        private static string DllName = IRaceTypeConfigReflection.Split(',')[0];//DLL的名称，类库的名称
        private static string ClassName = IRaceTypeConfigReflection.Split(',')[1];//TypeName 类型（类）的名称

        /// <summary>
        /// CreateHelper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstanceObject<T>()
        {
            Assembly assembly = Assembly.Load(DllName);//dll的名字
            Type sType = assembly.GetType(ClassName);
            object oObject = Activator.CreateInstance(sType);
            //T iObject = (T)oObject;
            return (T)oObject;
        }
    }
}
