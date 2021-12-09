using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        void InsertAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
