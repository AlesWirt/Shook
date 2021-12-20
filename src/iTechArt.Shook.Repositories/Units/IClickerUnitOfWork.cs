using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories.Repositories;

namespace iTechArt.Shook.Repositories.Units
{
    public interface IClickerUnitOfWork : IUnitOfWork
    {
        public IClickerRepository ClickerRepository { get; }
    }
}
