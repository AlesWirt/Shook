using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context, ILog logger)
            : base (context, logger)
        {

        }
    }
}
