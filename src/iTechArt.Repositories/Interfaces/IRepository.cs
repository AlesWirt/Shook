using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        void CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
