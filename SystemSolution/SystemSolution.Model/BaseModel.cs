using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemSolution.Common.Attributes;

namespace SystemSolution.Model
{
    public class BaseModel
    {
        [Identity]
        [PrimaryKey]
        public int Id { get; set; }
    }
}
