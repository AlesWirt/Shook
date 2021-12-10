using iTechArt.Repositories;
using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using System;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation.Units
{
    public class ClickerUnitOfWork : IClickerUnitOfWork
    {
        public IRepository<TEntity> CreateRepository<TEntity>(Type entityType)
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> RegisterRepository<TEntity>(Type entityType) 
            where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
