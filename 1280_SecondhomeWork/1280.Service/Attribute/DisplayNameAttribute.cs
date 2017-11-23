using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service 
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisplayNameAttribute : Attribute
    {
        public string DispalyNameValue { get; }

        public DisplayNameAttribute(string displayName)
        {
            this.DispalyNameValue = displayName;
        }
    }
}
