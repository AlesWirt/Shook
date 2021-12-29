using iTechArt.Common;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Repositories.Stores
{
    public class UserStore : IUserStore<User>
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;


        public UserStore(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task<IdentityResult> CreateAsync(User user,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            if(user == null)
            {
                throw new ArgumentNullException();
            }
            
            var count = await _uow.UserRepository.GetEntityQuantity();

            await _uow.UserRepository.CreateAsync(user);
            
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
