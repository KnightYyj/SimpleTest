using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSolution.Common.Attributes
{
    /// <summary>
    /// 自增特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentityAttribute : Attribute
    {

    }
}
