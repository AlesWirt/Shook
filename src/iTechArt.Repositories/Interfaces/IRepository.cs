using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
    }
}
