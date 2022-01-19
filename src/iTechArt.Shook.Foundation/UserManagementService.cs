using System;
using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.DomainModel.Utility;
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
        private readonly IAccountService _accountService;


        public UserManagementService(ILog logger,
            ISurveyUnitOfWork uow,
            IAccountService accountService)
        {
            _logger = logger;
            _uow = uow;
            _accountService = accountService;
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            var result =  await _accountService.SignUp(user, password);

            if (result.Succeeded)
            {
                var addToRoleResult = await _accountService.AddToRoleAsync(user, Helper.User);

                if (addToRoleResult.Succeeded)
                {
                    await _accountService.SignIn(user);
                }
            }

            return result;
        }

        public async Task<IReadOnlyCollection<User>> DisplayAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }

        public async Task LogOffAsync()
        {
            await _accountService.LogOffAsync();
        }
    }
}