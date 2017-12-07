using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ILanguageRepository<T, TK>
    {
        T Read(TK id);
        List<T> ReadAll();
    }
}