using iTechArt.Common;
using iTechArt.Shook.Repositories.Stores;
using iTechArt.Shook.Repositories.UnitsOfWorks;
using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly ILog _logger;
        private readonly ISurveyUnitOfWork _uow;
        private readonly UserStore _userStore;


        public UserManagementService(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task CreateAsync(User user)
        {
            await _userStore.CreateAsync(user);
            await _uow.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }
    }
}