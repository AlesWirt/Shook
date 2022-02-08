using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    [UsedImplicitly]
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }


        public async Task<IReadOnlyCollection<string>> GetUserRolesAsync(int userId)
        {
            var roleNameCollection = await DbContext.Set<UserRole>()
                .Where(userRole => userRole.UserId == userId)
                .Select(userRole => userRole.Role.Name)
                .ToListAsync();

            return roleNameCollection;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersWithRolesAsync()
        {
            var users = await DbContext.Set<User>()
                .Include(user => user.UserRoles)
                .ThenInclude(userRole => userRole.Role)
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = await DbContext.Set<User>().SingleOrDefaultAsync(user => user.UserName == userName);

            return user;
        }
    }
}