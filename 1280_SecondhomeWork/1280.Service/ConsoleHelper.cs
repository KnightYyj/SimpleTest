using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1280.Service
{
    public class ConsoleHelper
    {
        /// <summary>
		/// 逐渐输出文字，并指定颜色，默认白色
		/// </summary>
		/// <param name="content"></param>
		/// <param name="fontColor"></param>
		/// <param name="millisecond"></param>
		public static void WriteLine(string content, ConsoleColor fontColor = ConsoleColor.White, int millisecond = 60)
        {
            Console.ForegroundColor = fontColor;
            foreach (var word in content)
            {
                Console.Write(word);
                Thread.Sleep(millisecond);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLine(string content, int millisecond)
        {
            WriteLine(content, ConsoleColor.White, millisecond);
        }


        public static string ReadLine()
        {
            var result = Console.ReadLine();
            Console.WriteLine();
            return result;
        }
    }
}
