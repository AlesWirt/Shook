﻿using iTechArt.Common;
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
        private ILog _logger;

        
        protected TContext _context;


        private bool _disposed;


        protected Dictionary<Type, object> _repositories;


        protected Dictionary<Type, Type> _registeredRepo;


        public UnitOfWork(ILog logger)
        {
            _logger = logger;
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
            
            if (_repositories.TryGetValue(entityType, out var repositoryObject))
            {
                return (IRepository<TEntity>)repositoryObject;
            }
            else
            {
                CreateRepository<TEntity>();
            }
            

            return (IRepository<TEntity>)_repositories[entityType];
        }

        protected virtual IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);
            if (!_registeredRepo.TryGetValue(entityType, out var repositoryType))
            {
                repositoryType = RegisterRepository<TEntity>();
            }

            var customRepository = Activator.CreateInstance(
            repositoryType, _context, _logger );

            _repositories.Add(entityType, customRepository);

            return (Repository<TEntity>)_repositories[entityType];
        }

        protected virtual Type RegisterRepository<TEntity>()
            where TEntity : class
        {
            _registeredRepo.Add(typeof(TEntity), typeof(IRepository<>));

            return _registeredRepo[typeof(TEntity)];
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
