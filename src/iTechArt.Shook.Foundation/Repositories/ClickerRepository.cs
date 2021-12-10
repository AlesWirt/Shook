using iTechArt.Repositories;
using iTechArt.Shook.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Foundation.Repositories
{
    public class ClickerRepository : Repository<Clicker>
    {
        public ClickerRepository(ClickerDbContext context)
            :base(context)
        {

        }
    }
}
