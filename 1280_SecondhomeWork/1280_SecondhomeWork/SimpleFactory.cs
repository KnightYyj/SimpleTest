using _1280.InterFace;
using _1280.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ventriloquism;

namespace _1280_SecondhomeWork
{
    public class SimpleFactory
    {
        /// <summary>
        /// 简单工厂，用来创建不同门派的口技表演者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : BaseModel, ICharge
        {
            var config = JsonHelper.JsonToObject<ConfigModel>(ReadConfigFile($"{typeof(T).Name}.json"));
            object objType = Assembly.Load(config.DllName).CreateInstance($"{config.DllName}.{config.ClassName}", true, BindingFlags.Default, null, null, null, null);
            T model = (T)objType;
            foreach (PropertyInfo info in config.GetType().GetProperties())
            {
                var prop = typeof(T).GetProperty(info.Name,
                    BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                if (null != prop) prop.SetValue(model, info.GetValue(config));
                var field = typeof(T).GetField(info.Name,
                    BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic);
                if (null != field) field.SetValue(model, info.GetValue(config));
            }


            //config.EventList.CheckNull().ToList().ForEach(r => model.FireEvent += () => model.OutLog(r));
            return model;
        }



        public static string GetAppSet(string key)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"未读取到配置项{key}，请在配置文件中进行配置");
            }
            return value;
        }


        public static string ReadConfigFile(string fileName)
        {
            var configPath = GetAppSet("ConfigPath");
            fileName = $"{configPath}\\{fileName}";
            //最初的写法
            //File.ReadAllText(fileName);
            //防止中文乱码
            string a = File.ReadAllText(fileName, Encoding.Default);
            return a;
        }
    }
}
