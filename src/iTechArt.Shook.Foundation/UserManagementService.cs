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
        private readonly IAccountService _accountService;


        public UserManagementService(ILog logger,
            ISurveyUnitOfWork uow,
            IAccountService accountService)
        {
            _logger = logger;
            _uow = uow;
            _accountService = accountService;
        }

        public async Task<IReadOnlyCollection<User>> DisplayAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }
    }
}