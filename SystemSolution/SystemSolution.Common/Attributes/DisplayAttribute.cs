using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSolution.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | (AttributeTargets.Class))]
    public class DisplayAttribute : Attribute
    {
        public string Remark { get; private set; }


        public DisplayAttribute(string Name)
        {
            this.Remark = Name;
        }
    }
}
