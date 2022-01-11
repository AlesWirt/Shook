using iTechArt.Shook.DomainModel.Models;
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
    public class SurveyUserStore : IUserStore<User>
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;


        public SurveyUserStore(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

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
                var argumentNullException = new ArgumentNullException($"In the method CreateAsync of UserStore class, {typeof(User)} is null");
                _logger.LogError("Log error from UserStore.CreateAsync", argumentNullException);

                throw argumentNullException;
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
                var argumentNullException = new ArgumentNullException($"In the method DeleteAsync of UserStore class, {typeof(User)} is null");
                _logger.LogError("Log error from UserStore.DeleteAsync", argumentNullException);

                throw argumentNullException;
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
                var invalidCastException = new InvalidCastException("Invalid identificator value.");
                _logger.LogError("Log error from UserStore.FindByIdAsync", invalidCastException);

                throw invalidCastException;
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
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                var argumentNullException = new ArgumentNullException($"In the method GetUserIdAsync of UserStore class, {typeof(User)} is null");
                _logger.LogError("Log error from UserStore.GetUserIdAsync", argumentNullException);

                throw argumentNullException;
            }

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            if (user == null)
            {
                var argumentNullException = new ArgumentNullException($"In the method GetUserNameAsync of UserStore class, {typeof(User)} is null");
                _logger.LogError("Log error from UserStore.GetUserNameAsync", argumentNullException);

                throw argumentNullException;
            }

            return Task.FromResult(user.UserName);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                var argumentNullException = new ArgumentNullException($"In the method UpdateAsync of UserStore class, {typeof(User)} is null");
                _logger.LogError("Log error from UserStore.UpdateAsync", argumentNullException);

                throw argumentNullException;
            }

            _uow.UserRepository.Update(user);
            await _uow.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}