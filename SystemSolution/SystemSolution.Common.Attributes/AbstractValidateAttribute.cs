using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object oValue);
    }
}
