using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using JetBrains.Annotations;

namespace iTechArt.Shook.Repositories.Repositories
{
    [UsedImplicitly]
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }
        
    }
}