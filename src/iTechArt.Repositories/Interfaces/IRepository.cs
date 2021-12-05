using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iTechArt.Repositories.Interfaces
{
    public interface IRepository<TEntity, TContext> 
        where TEntity : class
        where TContext : DbContext, new()
    {
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}
