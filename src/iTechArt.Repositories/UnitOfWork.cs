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
        private readonly TContext _context;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;
        private Dictionary<Type, Type> _registeredRepo;


        public TContext Context { get; }


        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _repositories = new Dictionary<Type, object>();
            _registeredRepo = new Dictionary<Type, Type>();
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class
        {
            var type = typeof(TEntity);
            var repository = new Repository<TEntity>(_context);

            if (!_registeredRepo.TryGetValue(type, out var repositoryType))
            {
                return new Repository<TEntity>(_context);
            }

            if (!_repositories.ContainsKey(type))
            {
                var customRepository = Activator.CreateInstance(type, _context);
                _repositories.Add(type, customRepository);
            }

            return (Repository<TEntity>)_repositories[type];
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
