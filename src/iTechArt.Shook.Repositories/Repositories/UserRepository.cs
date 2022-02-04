﻿using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    [UsedImplicitly]
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }

        public async Task<IReadOnlyCollection<string>> GetUserRolesAsync(User user)
        {
            var roleNameCollection = await DbContext.Set<UserRole>()
                .Where(userRole => userRole.UserId == user.Id)
                .Select(userRole => userRole.Role)
                .Select(role => role.Name)
                .ToListAsync();

            return roleNameCollection.AsReadOnly();
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int userId, int roleId)
        {
            var userRole = await DbContext.Set<UserRole>().SingleOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            return userRole;
        }
    }
}