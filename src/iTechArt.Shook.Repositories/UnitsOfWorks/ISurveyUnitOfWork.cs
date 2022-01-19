using iTechArt.Repositories.Interfaces;
using iTechArt.Shook.Repositories.Repositories;

namespace iTechArt.Shook.Repositories.UnitsOfWorks
{
    public interface ISurveyUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}
