using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Name { get; protected set; }
        public TableAttribute(string tableName)
        {
            this.Name = tableName;
        }

    }
}
