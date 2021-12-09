using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
