using System;
using iTechArt.Common;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public class AccountService : IAccountService
    {
        private readonly ILog _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountService(ILog logger, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await SignInAsync(user);
            }

            return result;
        }

        public async Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe = false)
        {
            if (userName == null)
            {
                _logger.LogError($"User name cannot be null");

                throw new ArgumentNullException($"User name cannot be null");
            }

            if (password == null)
            {
                _logger.LogError($"User password cannot be null");

                throw new ArgumentNullException($"User password cannot be null");
            }

            var result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, false);

            return result;
        }

        public async Task SignInAsync(User user)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task LogOffAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            if (userName == null)
            {
                _logger.LogError($"User name cannot be null");

                throw new ArgumentNullException($"User name cannot be null");
            }

            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }
    }
}