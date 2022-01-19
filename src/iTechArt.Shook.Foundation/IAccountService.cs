using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUp(User user, string password);
        public Task SignIn(User user);
        public Task<IdentityResult> AddToRoleAsync(User user, string role);
        public Task LogOffAsync();
    }
}
