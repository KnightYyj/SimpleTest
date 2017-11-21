using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{
    /// <summary>
    /// 主键特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {

    }
}
