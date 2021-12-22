using iTechArt.Common;
using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly ILog _logger;
        private readonly TContext _dbContext;
        private bool _disposed;


        private readonly Dictionary<Type, object> _repositories;
        private readonly Dictionary<Type, Type> _registeredRepositories;
        
        
        public UnitOfWork(ILog logger, TContext context)
        {
            _logger = logger;
            _dbContext = context;
            _repositories = new Dictionary<Type, object>();
            _registeredRepositories = new Dictionary<Type, Type>();
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);

            if(_repositories.TryGetValue(entityType, out var repositoryObject))
            {
                return (IRepository<TEntity>)repositoryObject;
            }

            var createdRepository = CreateRepository<TEntity>();
            _repositories.Add(entityType, createdRepository);

            return createdRepository;
        }

        protected void RegisterRepository<TEntity, TRepository>()
            where TEntity : class
            where TRepository : IRepository<TEntity>
        {
            _registeredRepositories.Add(typeof(TEntity), typeof(TRepository));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        
        private IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);

            if(!_registeredRepositories.TryGetValue(entityType, out var repositoryType))
            {
                return new Repository<TEntity>(_logger, _dbContext);
            }

            var customRepository = Activator.CreateInstance(
                repositoryType, _logger, _dbContext);

            return (IRepository<TEntity>)customRepository;
        }
    }
}
