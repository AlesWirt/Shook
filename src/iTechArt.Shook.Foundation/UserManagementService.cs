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


        public UserManagementService(ILog logger, ISurveyUnitOfWork uow,
            UserManager<User> userManager)
        {
            _logger = logger;
            _uow = uow;
            _userManager = userManager;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                _logger.LogError($"User name cannot be null");

                throw new ArgumentNullException($"User name cannot be null");
            }

            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            if(user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if(roles == null)
            {
                _logger.LogError($"User does not contain roles");

                throw new ArgumentNullException($"User does not contain roles");
            }

            return roles;
        }
    }
}