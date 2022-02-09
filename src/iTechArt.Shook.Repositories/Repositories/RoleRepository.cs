using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ILog _logger, SurveyApplicationDbContext _context)
            : base(_logger, _context)
        {

        }

        public async Task<Role> GetRoleByNameAsync(string normalizedRoleName)
        {
            var result = await DbContext.Set<Role>().SingleOrDefaultAsync(r => r.NormalizedName == normalizedRoleName);

            return result;
        }

        public async Task<IReadOnlyCollection<User>> GetUsersInRoleAsync(int roleId)
        {
            var users = await DbContext.Set<UserRole>()
                .Where(userRole => userRole.RoleId == roleId)
                .Select(userRole => userRole.User)
                .ToListAsync();

            return users;
        }
    }
}