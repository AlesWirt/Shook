using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

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

        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
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
