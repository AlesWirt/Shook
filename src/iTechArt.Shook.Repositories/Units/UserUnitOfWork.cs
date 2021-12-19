using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories.Units
{
    public class UserUnitOfWork : UnitOfWork<UserDbContext>, IUserUnitOfWork
    {
        public IUserRepository UserRepository => (IUserRepository)GetRepository<User>();


        public UserUnitOfWork(UserDbContext context, ILog logger)
            : base(context, logger)
        {
            RegisterRepository<User, UserRepository>();
        }
    }
}
