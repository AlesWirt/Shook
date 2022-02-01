using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using iTechArt.Common;
using Microsoft.AspNetCore.Identity;
using JetBrains.Annotations;

namespace iTechArt.Shook.Repositories.Stores
{
    [UsedImplicitly]
    public class SurveyUserStore : IUserStore<User>,
        IUserPasswordStore<User>,
        IUserRoleStore<User>
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;


        public SurveyUserStore(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        #region IUserStore

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IdentityResult> CreateAsync(User user,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User cannot be null");

                throw new ArgumentNullException($"User cannot be null"); ;
            }

            await _uow.UserRepository.CreateAsync(user);
            await _uow.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            _uow.UserRepository.Delete(user);
            await _uow.SaveChangesAsync();

            return IdentityResult.Success;
        }


        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!int.TryParse(userId, out var id))
            {
                _logger.LogError("Invalid identificator value");

                throw new ArgumentNullException("Invalid identificator value");
            }

            var user = await _uow.UserRepository.GetByIdAsync(id);

            return user;
        }

        public async Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            return await _uow.UserRepository.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            return Task.FromResult(user.NormalizedName);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            return Task.FromResult(user.UserName);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist"); ;
            }

            _uow.UserRepository.Update(user);
            await _uow.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist"); ;
            }

            user.NormalizedName = normalizedName;

            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            if (string.IsNullOrEmpty(userName))
            {
                _logger.LogError($"Password does not exist");

                throw new ArgumentNullException($"Password does not exist");
            }

            user.UserName = userName;
            return Task.CompletedTask;
        }

        #endregion

        #region IUserPasswordStore

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                _logger.LogError($"Password does not exist");

                throw new ArgumentNullException($"Password does not exist");
            }

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        #endregion

        #region IUserRoleStore

        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                _logger.LogError($"Role name does not exist");

                throw new ArgumentNullException($"Role name does not exist");
            }

            var role = await _uow.RoleRepository.FirstOrDefaultAsync(r => r.Name == roleName);

            var userRole = new UserRole()
            {
                RoleId = role.Id,
                UserId = user.Id
            };

            await _uow.GetRepository<UserRole>().CreateAsync(userRole);
            await _uow.SaveChangesAsync();
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            var roleNames = new List<string>();

            foreach (var userRole in user.UserRoles)
            {
                var roleName = userRole.Role.Name;

                roleNames.Add(roleName);
            }

            return await Task.FromResult(roleNames);
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(roleName))
            {
                _logger.LogError($"Role name does not exist");

                throw new ArgumentNullException($"Role name does not exist");
            }

            var role = await _uow.RoleRepository.FirstOrDefaultAsync(r => r.Name == roleName);

            var users = new List<User>();

            foreach (var userRole in role.UserRoles)
            {
                users.Add(userRole.User);
            }

            return await Task.FromResult(users);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                _logger.LogError($"Role name does not exist");

                throw new ArgumentNullException($"Role name does not exist");
            }

            var isInRole = false;

            foreach (var userRole in user.UserRoles)
            {
                isInRole = userRole.Role.Name == roleName;
            }

            return Task.FromResult(isInRole);
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                _logger.LogError($"User does not exist");

                throw new ArgumentNullException($"User does not exist");
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                _logger.LogError($"Role name does not exist");

                throw new ArgumentNullException($"Role name does not exist");
            }

            foreach (var userRole in user.UserRoles)
            {
                if (userRole.Role.Name == roleName)
                {
                    user.UserRoles.Remove(userRole);
                }
            }

            return Task.CompletedTask;
        }

        #endregion
    }
}