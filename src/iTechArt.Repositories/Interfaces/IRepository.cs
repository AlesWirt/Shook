using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] id);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        void Update(TEntity entity);

        Task CreateAsync(TEntity entity);

        void DeleteAsync(TEntity entity);
    }
}
