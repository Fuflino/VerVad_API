using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T, I, L>
    {
        T Create(T t, L lang);
        T Read(I id, L language);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(I id);
    }
}
