using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T, K>
    {
        T Create(T t);
        T Read(K id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(K id);
    }
}
