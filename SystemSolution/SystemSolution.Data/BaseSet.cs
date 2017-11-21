using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    public class BaseSet<T>
        where T : BaseModel, new()
    {


        public BaseSet()
        {

        }
    }
}
