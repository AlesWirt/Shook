using iTechArt.Common;
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


        public UserManagementService(ILog logger, ISurveyUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task CreateAsync(User user)
        {
            await _uow.UserRepository.CreateAsync(user);
            await _uow.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            var collection = await _uow.UserRepository.GetAllAsync();

            return collection;
        }
    }
}