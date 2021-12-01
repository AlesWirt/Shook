using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iTechArt.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Entities;
        protected readonly ClickerDbContext _context;

        public GenericRepository(ClickerDbContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public TEntity Read(int id)
        {
            return Entities.Find(id);
        }

        public IQueryable<TEntity> ReadAll()
        {
            return Entities;
        }

        public void Update(TEntity entity)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
