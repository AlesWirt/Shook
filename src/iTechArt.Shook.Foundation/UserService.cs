using iTechArt.Common;
using iTechArt.Shook.Repositories.Units;
using iTechArt.Shook.DomainModel.Models;
using System.Threading.Tasks;

namespace iTechArt.Shook.Foundation
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _uow;
        private readonly ILog _logger;


        public UserService(IUserUnitOfWork uow, ILog logger)
        {
            uow = uow;
            _logger = logger;
        }


        public async Task CreateAsync(User userEntity)
        {
            _logger.LogInformation($"Creating user entity method. " +
                $"Class-creator: {typeof(UserService).Name}. " +
                $"Method-creator: {typeof(UserService).GetMethod("CreateAsync").Name}.");
            await _uow.UserRepository.CreateAsync(userEntity);
        }
    }
}
