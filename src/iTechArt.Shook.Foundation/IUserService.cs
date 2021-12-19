using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Foundation
{
    public interface IUserService
    {
        public Task CreateAsync(User userEntity);

        public Task<IReadOnlyCollection<User>> GetAllUsersAsync();
    }
}
