using iTechArt.Common;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iTechArt.Shook.Foundation
{
    public class UserService : IUserService
    {
        private readonly ILog _logger;
        private readonly IUserUnitOfWork _uow;


        public UserService(ILog logger, IUserUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task CreateAsync(User userEntity)
        {
            _logger.LogInformation($"Creating user entity method. " +
                $"Class-creator: {typeof(UserService).Name}. " +
                $"Method-creator: {typeof(UserService).GetMethod("CreateAsync").Name}.");
            await _uow.UserRepository.CreateAsync(userEntity);
            await _uow.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            _logger.LogInformation($"Creating user entity method. " +
                $"Class: {typeof(UserService).Name}. " +
                $"Method: {typeof(UserService).GetMethod("GetAllUsersAsync").Name}.");

            var collection = await _uow.UserRepository.GetAllAsync();
            
            return collection;
        }
    }
}
