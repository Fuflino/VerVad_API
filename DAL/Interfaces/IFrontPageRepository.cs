using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFrontPageRepository<T,K>
    {
        T Read(K id);
        T Update(T t);
    }
}
