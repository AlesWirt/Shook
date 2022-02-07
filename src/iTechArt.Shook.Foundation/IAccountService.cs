using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterAsync(User user, string password);

        public Task<SignInResult> SignInAsync(User user, string password);

        public Task SignOutAsync();

        public Task<bool> IsInRoleAsync(User user, string roleName);
    }
}