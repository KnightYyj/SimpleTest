using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSolution.Common.Attributes
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
