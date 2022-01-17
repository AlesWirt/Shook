using System;
using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserManagementService(ILog logger,
            ISurveyUnitOfWork uow,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            _uow = uow;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(User user)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            var result =  await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<IReadOnlyCollection<User>> DisplayAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }

        public async Task SignOutAsync()
        {
            _signInManager.SignOutAsync();
        }
    }
}