using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Data;
using SystemSolution.GenericCache;

namespace SystemSolution.SimpleFactory
{
    public static class DbContextFactory
    {
        private static string dbConnectionString = ConfigurationManager.AppSettings["dbConnectionString"];
        private static string dbContextConfig = ConfigurationManager.AppSettings["dbContext"];
        private static string DllName = dbContextConfig.Split(',')[1];
        private static string TypeName = dbContextConfig.Split(',')[0];

        public static IDbContext Create()
        {
            if (GenericCache<IDbContext>.Instance == null)
            {
                Assembly assembly = Assembly.Load(DllName);
                Type dbContextType = assembly.GetType(TypeName);
                object oDBContext = Activator.CreateInstance(dbContextType, dbConnectionString);
                var dbContext = oDBContext as IDbContext;
                GenericCache<IDbContext>.Instance = dbContext;
            }
            return GenericCache<IDbContext>.Instance;
        }
    }
}
