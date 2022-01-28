using System;
using System.Threading.Tasks;

namespace iTechArt.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}