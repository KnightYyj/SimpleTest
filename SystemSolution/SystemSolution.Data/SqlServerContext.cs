using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    public class SqlServerContext : IDbContext
    {
        private readonly string _connectionString;

        public SqlServerContext(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public ISet<T> Set<T>() where T : BaseModel, new()
        {
            return new SqlServerSet<T>(_connectionString);
        }
    }
}
