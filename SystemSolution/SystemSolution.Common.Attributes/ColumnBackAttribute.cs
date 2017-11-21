using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBackAttribute : Attribute
    {
        public string ColName { get; protected set; }
        public ColumnBackAttribute(string colName)
        {
            this.ColName = colName;
        }
    }
}
