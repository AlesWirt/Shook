using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            var result = await DbContext.Set<Role>().SingleOrDefaultAsync(r => r.NormalizedName == roleName);

            return result;
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            var role = DbContext.Set<Role>().SingleOrDefaultAsync(r => r.NormalizedName == roleName);

            if (role == null)
            {
                throw new ArgumentNullException($"Role does not exist");
            }

            var userIdCollection = DbContext.Set<UserRole>()
                .Where(userRole => userRole.UserId == role.Id)
                .Select(userRole => userRole.UserId);

            var users =  await userIdCollection
                .SelectMany(id => DbContext.Set<User>()
                .Where(user => user.Id == id)).ToListAsync();

            if(users == null)
            {
                throw new ArgumentNullException("There is no users with such role");
            }

            return users;
        }
    }
}