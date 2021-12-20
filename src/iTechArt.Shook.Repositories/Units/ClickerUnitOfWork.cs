using iTechArt.Repositories;
using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories.Units
{
    public class ClickerUnitOfWork : UnitOfWork<ClickerDbContext>, IClickerUnitOfWork
    {
        public IClickerRepository ClickerRepository => (IClickerRepository)GetRepository<Clicker>();


        public ClickerUnitOfWork(ClickerDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepository<Clicker, ClickerRepository>();
        }
    }
}
