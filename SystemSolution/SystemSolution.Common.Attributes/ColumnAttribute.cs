
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SystemSolution.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string ColName { get; protected set; }
        public ColumnAttribute(string colName)
        {
            this.ColName = colName;
        }
    }
}