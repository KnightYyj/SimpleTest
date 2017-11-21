using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemSolution.Common.Attributes
{
    public class MobilephoneAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object oValue)
        {
            bool result = false;
            Regex rx = new Regex(@"^0{0,1}(13[4-9]|15[7-9]|15[0-2]|18[7-8])[0-9]{8}$");
            if (rx.IsMatch(oValue.ToString()))
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
}
