using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _1280.Service
{
    public class JsonHelper
    {
        /// <summary>
        /// JavaScriptSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson<T>(T obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }

        /// <summary>
        /// JavaScriptSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T StringToObject<T>(string content)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(content);
        }

        /// <summary>
        /// JsonConvert.SerializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// JsonConvert.DeserializeObject  JsonToObject序列化方法 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }


        public static List<T> JsonToList<T>(string content)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            return jss.Deserialize<List<T>>(content);
        }


        /// <summary>
		/// 读取Json文件内容
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static string ReadJson(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.Default);
            //最初的写法
            //File.ReadAllText(fileName);
            //防止中文乱码
        }
    }
}
