using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] idValues);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        void Update(TEntity entity);

        Task CreateAsync(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}