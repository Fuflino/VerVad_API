using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGGAndAVRepository<T, I>
    {
        T Create(T t);
        T Read(I id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(I id);
    }
}