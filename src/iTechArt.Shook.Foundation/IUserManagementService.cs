﻿using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public interface IUserManagementService
    {
        public Task<IReadOnlyCollection<User>> GetAllUsersAsync();

        public Task<User> GetUserByUserNameAsync(string userName);

        public Task<User> GetUserByUserIdAsync(int? userId);

        public Task UpdateUserAsync(User user);

        public Task<IdentityResult> DeleteUserAsync(User user);
    }
}