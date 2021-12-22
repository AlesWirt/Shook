using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Foundation
{
    public interface IUserManagementService
    {
        public Task CreateAsync(User user);

        public Task<IReadOnlyCollection<User>> GetAllUsersAsync();
    }
}
