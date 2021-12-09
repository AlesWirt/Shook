using System;
using System.Collections.Generic;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}
