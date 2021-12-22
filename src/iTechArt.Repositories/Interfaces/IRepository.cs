using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        public Task CreateAsync(TEntity entity);
        
        public void Update(TEntity entity);

        public Task<TEntity> GetByIdAsync(params object[] idValues);

        public Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        public void Delete(TEntity entity);
    }
}
