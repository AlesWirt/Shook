using System.Collections;
using System.Threading.Tasks;
using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }
    }
}
