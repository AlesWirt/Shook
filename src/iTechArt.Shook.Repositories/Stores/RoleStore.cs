using System.Threading;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Repositories.Stores
{
    [UsedImplicitly]
    public class RoleStore : IUserStore<UserRole>
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRole> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRole> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserIdAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserNameAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(UserRole user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetUserNameAsync(UserRole user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserRole user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
