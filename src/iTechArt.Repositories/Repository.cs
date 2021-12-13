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
        protected readonly DbContext _context;


        private ILog _logger;


        public Repository(DbContext context, ILog logger)
        {
            _context = context;
            _logger = logger;
        }


        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        public virtual async void CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _context.Set<TEntity>();
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity).Entity;
        }


        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
