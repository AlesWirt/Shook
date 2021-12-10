using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepository<TEntity> CreateRepository<TEntity>(Type entityType) where TEntity : class;
        IRepository<TEntity> RegisterRepository<TEntity>(Type entityType) where TEntity : class;
    }
}
