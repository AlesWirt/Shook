using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class ClickerRepository : Repository<Clicker>
    {
        public ClickerRepository(ClickerDbContext context)
            : base(context)
        {

        }
    }
}
