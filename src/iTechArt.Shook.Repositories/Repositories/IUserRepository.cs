using iTechArt.Shook.DomainModel.Models;
using iTechArt.Repositories.Interfaces;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task CreateAsync(User user);


        public Task SignInUserAsync(User user, bool isPersistent);
    }
}
