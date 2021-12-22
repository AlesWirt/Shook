using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Repositories.Interfaces;

namespace iTechArt.Shook.Repositories.UnitsOfWorks
{
    public interface ISurveyUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}
