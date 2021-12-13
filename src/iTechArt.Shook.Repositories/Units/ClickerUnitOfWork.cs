using iTechArt.Repositories;
using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using System;

namespace iTechArt.Shook.Repositories.Units
{
    public class ClickerUnitOfWork : UnitOfWork<ClickerDbContext>, IClickerUnitOfWork
    {
        public IClickerRepository ClickerRepository { get; }


        public ClickerUnitOfWork(ClickerDbContext context, ILog logger)
            : base(logger)
        {
            _context = context;
            ClickerRepository = (IClickerRepository)GetRepository<Clicker>();
        }


        protected override Type RegisterRepository<TEntity>()
            where TEntity : class
        {
            _registeredRepo.Add(typeof(TEntity), typeof(ClickerRepository));

            return _registeredRepo[typeof(TEntity)];
        }
    }
}
