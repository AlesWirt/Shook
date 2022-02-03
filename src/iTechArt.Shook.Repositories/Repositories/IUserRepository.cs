using iTechArt.Shook.DomainModel.Models;
using iTechArt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IList<string>> GetUserRolesAsync(User user);

        public Task<UserRole> GetUserRoleByIdAsync(int userId, int roleId);
    }
}