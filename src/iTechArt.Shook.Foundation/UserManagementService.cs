using System;
using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArt.Shook.Repositories.UnitsOfWorks;

namespace iTechArt.Shook.Foundation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;


        public UserManagementService(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }

        public async Task<User> GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                _logger.LogError($"User name cannot be null");

                throw new ArgumentNullException($"User name cannot be null");
            }

            var user = await _uow.UserRepository.FirstOrDefaultAsync(u => u.UserName == userName);

            return user;
        }
    }
}