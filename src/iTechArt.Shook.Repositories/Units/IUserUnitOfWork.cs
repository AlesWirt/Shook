using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories.Repositories;

namespace iTechArt.Shook.Repositories.Units
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}
