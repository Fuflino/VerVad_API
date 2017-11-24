﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFrontPageRepository<T,K,F>
    {
        T Create(T t);
        T Read(K id, F language);
        T Update(T t);
        bool Delete(K id);
    }
}