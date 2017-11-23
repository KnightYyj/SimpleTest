using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service
{
    public static class Concentrate
    {
        private static string _root = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 取日志配置路径
        /// </summary>
        public static readonly string LogPath = Path.Combine(_root, ConfigurationManager.AppSettings["LogPath"]);

        /// <summary>
        /// 取配置数据路径
        /// </summary>
        public static readonly string ConfigPath = Path.Combine(_root, ConfigurationManager.AppSettings["ConfigDataPath"]);

        /// <summary>
        /// 取音效路径
        /// </summary>
        public static readonly string SoundPath = Path.Combine(_root, ConfigurationManager.AppSettings["SoundPath"]);
    }
}
