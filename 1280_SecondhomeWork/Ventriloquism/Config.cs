using _1280.Service;
using _1280.Service.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ventriloquism
{
    public class Config 
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <returns></returns>
        public static TOut getConfig<TIn,TOut>() where TOut : new()
        {
            var type = typeof(TIn);//获取类型
            var fileName = type.Name;
            ConfigTypeEnum fileType = ConfigTypeEnum.Json;
            if (type.IsDefined(typeof(ConfigAttribute), true))//IsDefined判断类中有没有一个或多个特性
            {
                var attribute = type.GetCustomAttribute(typeof(ConfigAttribute), true) as ConfigAttribute;//找出特性的属性(GetCustomAttribute是框架的扩展方法 )
                fileName = attribute.FileName;//获取特性的内容
                fileType = attribute.ConfigType;
            }

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Concentrate.ConfigPath, fileName);  //合成一个路径
            var filePath = $"{path}.{fileType}";

            switch (fileType)
            {
                case ConfigTypeEnum.Json:
                    var jsonString = JsonHelper.ReadJson(filePath);  //读json
                    var jsonValue = JsonHelper.JsonToObject<TOut>(jsonString); //反序列化
                    return jsonValue;
               
                default:
                    throw new ArgumentOutOfRangeException("未找到配置文件类型");
            }


        }


      
    }
}
