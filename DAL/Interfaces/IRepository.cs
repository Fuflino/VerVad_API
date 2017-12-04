using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T, I>
    {
        T Create(T t);
        T Read(I id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(I id);
    }
}
