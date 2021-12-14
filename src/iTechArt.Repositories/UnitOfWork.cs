using iTechArt.Common;
using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly ILog _logger;

        
        protected TContext Context { get; }


        private bool _disposed;


        protected Dictionary<Type, object> _repositories;
        protected Dictionary<Type, Type> _registeredRepo;


        public UnitOfWork(TContext context, ILog logger)
        {
            Context = context;
            _logger = logger;
            _repositories = new Dictionary<Type, object>();
            _registeredRepo = new Dictionary<Type, Type>();
        }
        

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }


        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class
        {
            var entityType = typeof(TEntity);
            
            if (_repositories.TryGetValue(entityType, out var repositoryObject))
            {
                return (IRepository<TEntity>)repositoryObject;
            }
            
            var createdRepository = CreateRepository<TEntity>();
            _repositories.Add(entityType, createdRepository);

            return createdRepository;
        }

        private IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (!_registeredRepo.TryGetValue(entityType, out var repositoryType))
            {
                return new Repository<TEntity>(Context, _logger);
            }

            var customRepository = Activator.CreateInstance(
                repositoryType, Context, _logger);

            return (IRepository<TEntity>)customRepository;
        }

        protected void RegisterRepository<TEntity, TRepository>()
            where TEntity : class
            where TRepository : IRepository<TEntity>
        {
            _registeredRepo.Add(typeof(TEntity), typeof(TRepository));
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
