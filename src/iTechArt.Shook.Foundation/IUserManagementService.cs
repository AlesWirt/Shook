﻿using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Foundation
{
    public interface IUserManagementService
    {
        public Task<IReadOnlyCollection<User>> DisplayAllUsersAsync();
    }
}