using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    public interface IDbContext
    {
        ISet<T> Set<T>() where T : BaseModel, new();
    }
}
