using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] values);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        void Update(TEntity entity);

        Task CreateAsync(TEntity entity);

        void Delete(TEntity entity);
    }
}
