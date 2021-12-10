using iTechArt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext, new()
    {
        private readonly TContext _context;


        private bool _disposed;


        protected Dictionary<Type, object> _repositories;


        protected Dictionary<Type, Type> _registeredRepo;


        public TContext Context { get; }


        public UnitOfWork()
        {
            _context = new TContext();
            _repositories = new Dictionary<Type, object>();
            _registeredRepo = new Dictionary<Type, Type>();
        }
        

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class
        {
            var entityType = typeof(TEntity);
            
            if (!_repositories.TryGetValue(entityType, out var repositoryObject))
            {
                RegisterRespotiry<TEntity>(entityType);
                return CreateRepository<TEntity>(entityType);
            }
            if (!_registeredRepo.TryGetValue(entityType, out var repositoryType))
            {
                RegisterRespotiry<TEntity>(entityType);
            }

            return (IRepository<TEntity>)_repositories[entityType];
        }

        private IRepository<TEntity> CreateRepository<TEntity>(Type entityType)
            where TEntity : class
        {
            var repositoryType = typeof(IRepository<>);
            var constructed = repositoryType.MakeGenericType(entityType);

            var customRepository = Activator.CreateInstance(
            constructed, _context);

            _repositories.Add(entityType, customRepository);
            

            return (Repository<TEntity>)_repositories[entityType];
        }

        private void RegisterRespotiry<TEntity>(Type entityType)
            where TEntity : class
        {
            var repositoryType = typeof(IRepository<TEntity>);
            _registeredRepo.Add(entityType, repositoryType);
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
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
