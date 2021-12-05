using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace iTechArt.Repositories
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity, TContext> 
        where TEntity : class
        where TContext : DbContext, new()
    {
        private DbSet<TEntity> _entities;
        private string _errorMessage = string.Empty;
        private bool _disposed;
        

        protected virtual DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = Context.Set<TEntity>()); }
        }

        public TContext Context { get; set; }

        public GenericRepository()
        {
            _disposed = false;
            Context = new TContext();
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
            try
            {
                if(entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Add(entity);
                if(Context == null || _disposed)
                {
                    Context = new TContext();
                }
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format(
                            "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage)
                            + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                if (Context == null || _disposed)
                {
                    Context = new TContext();
                }
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format(
                            "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                if (Context == null || _disposed)
                {
                    Context = new TContext();
                }
                Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += Environment.NewLine + string.Format(
                            "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }
    }
}
