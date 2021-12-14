using iTechArt.Common;
using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace iTechArt.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly ILog _logger;


        protected DbContext Context { get; }


        public Repository(DbContext context, ILog logger)
        {
            Context = context;
            _logger = logger;
        }


        public async Task<TEntity> GetByIdAsync(params object[] values)
        {
            _logger.LogDebug($"Getting entity. {typeof(TEntity).Name}.");
            return await Context.Set<TEntity>().FindAsync(values);
        }


        public async Task CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }


        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            _logger.LogInformation($"Get all entities of the type {typeof(TEntity).Name}.");
            return await Context.Set<TEntity>().ToListAsync();
        }


        public void Update(TEntity entity)
        {
            _logger.LogInformation($"Update entity. The enityt name: {typeof(TEntity).Name}.");
            Context.Set<TEntity>().Update(entity);
        }


        public void Delete(TEntity entity)
        {
            _logger.LogInformation($"Delete entity. The enityt name: {typeof(TEntity).Name}.");
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
