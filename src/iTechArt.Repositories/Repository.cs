using iTechArt.Common;
using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ILog _logger;

        protected DbContext DbContext { get; }


        public Repository(ILog logger, DbContext context)
        {
            _logger = logger;
            DbContext = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            _logger.LogInformation($"Creating entity {typeof(TEntity).Name}.");
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _logger.LogInformation($"Updating entity {typeof(TEntity).Name}.");
            DbContext.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity> GetByIdAsync(params object[] idValues)
        {
            _logger.LogInformation($"Getting entity {typeof(TEntity).Name}.");
            return await DbContext.Set<TEntity>().FindAsync(idValues);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogInformation($"Getting all entities {typeof(TEntity).Name}.");
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public void Delete(TEntity entity)
        {
            _logger.LogInformation($"Deliting entity {typeof(TEntity).Name}.");
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}
