using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service
{
    public class MyIO
    {
        public static string ReadFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string s = sr.ReadToEnd();
                return s;
            }

        }
        public static void WriteToFile(string content, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] byteArray = Encoding.Default.GetBytes(content);
                fs.Write(byteArray, 0, byteArray.Length);
                fs.Flush();
            }
        }

        public static void XmlToFile(string content, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(content);
                    sw.Flush();
                }
            }

        }
    }
}
