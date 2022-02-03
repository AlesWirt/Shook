using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<Role> GetRoleByNameAsync(string roleName);

        public Task<IList<User>> GetUsersInRoleAsync(string roleName);
    }
}