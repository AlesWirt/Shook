using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Foundation
{
    public interface IUserManagementService
    {
        public Task<IReadOnlyCollection<User>> GetAllUsersAsync();

        public Task<User> GetUserByUserNameAsync(string userName);

        public Task<IList<string>> GetRolesAsync(User user);
    }
}