using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class ClickerRepository : Repository<Clicker>, IClickerRepository
    {
        public ClickerRepository(ClickerDbContext context, ILog logger)
            : base(context, logger)
        {

        }
    }
}
