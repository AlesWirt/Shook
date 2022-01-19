using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> SignUp(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            return result;
        }

        public async Task SignIn(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);

            return result;
        }

        public async Task LogOffAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
