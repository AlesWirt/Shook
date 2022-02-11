﻿using System;
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
            var collection = await _uow.UserRepository.GetAllUsersAsync();

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

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            if(user == null)
            {
                _logger.LogError($"Invalid user");

                throw new ArgumentNullException($"Invalid user");
            }

            var result = await _userManager.DeleteAsync(user);

            return result;
        }
    }
}