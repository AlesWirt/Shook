using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private DbSet<TEntity> _entities;
        private bool _disposed;
        

        protected virtual DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = Context.Set<TEntity>()); }
        }

        public DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            _disposed = false;
            Context = context;
        }

        public virtual IQueryable<TEntity> Table
        {
            get { return Entities; }
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public virtual async void InsertAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Entities.Update(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
