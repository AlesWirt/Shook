using iTechArt.Shook.DomainModel.Models;
using iTechArt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IReadOnlyCollection<string>> GetUserRolesAsync(int userId);

        public Task<IReadOnlyCollection<User>> GetAllUsersWithRolesAsync();

        public Task<User> FindByNameAsync(string userName);
    }
}