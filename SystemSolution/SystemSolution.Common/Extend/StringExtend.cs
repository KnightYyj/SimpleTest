using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSolution.Common.Extend
{
    public static class StringExtend
    {
        public static string JoinString(this string[] ary, string separator)
        {
            return string.Join(separator, ary);
        }

        public static string FormatTo(this string str, params object[] values)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return string.Format(str, values);
        }
    }
}
