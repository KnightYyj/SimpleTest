using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSolution.Model;

namespace SystemSolution.Data
{
    /// <summary>
    /// 模仿EF的模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISet<T>
        where T : BaseModel
    {
        int Insert(T t);

        int Update(T t);

        int Delete(int id);

        T GetById(int id);

        List<T> GetList(Func<T, bool> func);
    }
}
