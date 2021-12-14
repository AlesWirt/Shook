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
        protected readonly DbContext _context;


        private ILog _logger;


        public Repository(DbContext context, ILog logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<TEntity> GetByIdAsync(params object[] id)
        {
            _logger.Log(LogLevel.Debug, "Getting Clicker object");
            return await _context.Set<TEntity>().FindAsync(id);
        }


        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }


        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            
            return await _context.Set<TEntity>().ToListAsync();
        }


        public void Update(TEntity entity)
        {
            try
            {
                _logger.Log(LogLevel.Info, "Update Clicker.");
                _context.Set<TEntity>().Update(entity);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong in Update method!", ex);
            }
        }


        public virtual void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
