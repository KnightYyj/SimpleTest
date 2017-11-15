using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service
{
    public static class LogHelper
    {
        /// <summary>
        /// 配置绝对路径
        /// </summary>
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        private static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        public static void WriteLog(string msg)
        {
            StreamWriter sw = null;
            try
            {
                string fileName = "log.txt";
                string totalPath = Path.Combine(LogPath, fileName);
                //不存在就创建文件夹
                if (!Directory.Exists(LogPath))
                {
                    Directory.CreateDirectory(LogPath);
                }
                sw = File.AppendText(totalPath);
                sw.WriteLine(string.Format("{0}:{1}", DateTime.Now, msg));
                sw.WriteLine("***************************************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//log
                //throw ex;
                //throw new exception("这里异常");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
