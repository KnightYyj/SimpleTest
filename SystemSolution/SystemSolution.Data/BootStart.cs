using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Common;
using SystemSolution.Common.Attributes;
using SystemSolution.GenericCache;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    public static class BootStart
    {
        /// <summary>
        /// 首次运行加载所有继承了BaseModel的类型, 并反射出表名，自增字段，所有字段
        /// 并存入泛型缓存，以供程序后期使用，将程序运行过程中的反射损耗降为最低。
        /// AllFields   FieldsWithNoIdentify  第一次就要反射特性
        /// </summary>
        public static void Start()
        {
            //获取所有Model
            var typesModel = Assembly.Load("SystemSolution.Model").GetTypes().Where(type => type.BaseType == typeof(BaseModel));

            //反射表名、字段等
            var tableInfos = new List<TableInfo>();
            foreach (var type in typesModel)
            {
                //获取Model Name
                var modelName = type.Name;

                //获取物理表名
                var physicalName = type.Name; //type.GetTableName();//可以用扩展方法找出实际的表名
                var attribute = type.GetCustomAttributes().FirstOrDefault(o => o.GetType() == typeof(TableAttribute));
                var tableAttribute = attribute as TableAttribute;
                if (tableAttribute != null) physicalName = tableAttribute.Name;

                //获取自增字段
                var identify = "";

                //获取主键字段
                var primaryKey = "";

                //获取所有字段
                var allFields = new List<string>();

                //获取除自增字段的所有字段
                var fieldsWithNoIdentify = new List<string>();

                foreach (var property in type.GetProperties())
                {
                    allFields.Add(property.GetColumnName());   //type.GetColumnName();//可以用扩展方法找出实际的字段  

                    if (property.GetCustomAttributes().Any(o => o.GetType() == typeof(PrimaryKeyAttribute)))
                    {
                        primaryKey = property.Name;
                    }

                    if (property.GetCustomAttributes().Any(o => o.GetType() == typeof(IdentityAttribute)))
                    {
                        identify = property.Name;
                    }
                    else
                    {
                        fieldsWithNoIdentify.Add(property.GetColumnName());  //type.GetColumnName();//可以用扩展方法找出实际的字段 
                    }
                }
                tableInfos.Add(new TableInfo(modelName, physicalName, identify, primaryKey, allFields,
                    fieldsWithNoIdentify));
            }

            //加入泛型缓存
            GenericCache<List<TableInfo>>.Instance = tableInfos;
        }
    }
}
