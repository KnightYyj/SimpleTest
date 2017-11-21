using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSolution.GenericCache
{
    public class GenericCache<T>// : GenericCache
    {
        static T instance;

        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                //AllGenericCaches[typeof(T)] = value;
            }
        }
    }
}
