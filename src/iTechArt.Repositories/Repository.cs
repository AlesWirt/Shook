using iTechArt.Common;
using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly ILog _logger;

        protected DbContext DbContext { get; }


        public Repository(DbContext context, ILog logger)
        {
            DbContext = context;
            _logger = logger;
        }


        public async Task<TEntity> GetByIdAsync(params object[] values)
        {
            _logger.LogDebug($"Getting entity {typeof(TEntity).Name}.");
            return await DbContext.Set<TEntity>().FindAsync(values);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogInformation($"Get all entities of the type {typeof(TEntity).Name}.");
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _logger.LogInformation($"Update entity. The enityt name: {typeof(TEntity).Name}.");
            DbContext.Set<TEntity>().Update(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _logger.LogInformation($"Delete entity. The enityt name: {typeof(TEntity).Name}.");
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}
