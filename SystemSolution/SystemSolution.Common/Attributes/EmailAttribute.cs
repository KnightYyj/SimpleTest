using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemSolution.Common.Attributes
{
    public class EmailAttribute : AbstractValidateAttribute
    {
        //实现邮箱验证
        public override bool Validate(object oValue)
        {
            bool result = false;
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (r.IsMatch(oValue.ToString()))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
    public class DataValidate
    {
        public static bool Validate<T>(T t)
        {
            Type type = t.GetType();
            bool result = true;
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(EmailAttribute), true))
                {
                    object item = prop.GetCustomAttributes(typeof(EmailAttribute), true)[0];
                    EmailAttribute attribute = item as EmailAttribute;
                    if (!attribute.Validate(prop.GetValue(t)))  //判断需不需要严重邮箱
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;

        }
    }
}
