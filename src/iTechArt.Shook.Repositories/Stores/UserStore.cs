﻿using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System;
using System.Threading;
using System.Threading.Tasks;
using iTechArt.Common;
using Microsoft.AspNetCore.Identity;
using JetBrains.Annotations;

namespace iTechArt.Shook.Repositories.Stores
{
    [UsedImplicitly]
    public class SurveyUserStore : IUserStore<User>,
        IUserPasswordStore<User>
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

            user.NormalizedName = user.UserName.ToUpper();

            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

            if (passwordHash == null)
            {
                _logger.LogError($"Password does not exist");

                throw new ArgumentNullException($"Password does not exist");
            }

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        #endregion
    }
}