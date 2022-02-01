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

            return result;
        }

        public async Task<SignInResult> SignInAsync(User user, string password)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            if (string.IsNullOrEmpty(password))
            {
                _logger.LogError($"User password cannot be null");

                throw new ArgumentNullException($"User password cannot be null");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            if (string.IsNullOrEmpty(role))
            {
                _logger.LogError($"User role cannot be null");

                throw new ArgumentNullException($"User role cannot be null");
            }

            var result = await _userManager.AddToRoleAsync(user, role);

            return result;
        }
    }
}