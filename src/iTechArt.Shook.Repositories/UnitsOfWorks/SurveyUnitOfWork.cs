using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.Repositories.Repositories;
using iTechArt.Shook.Repositories.DbContexts;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.Repositories.UnitsOfWorks
{
    public class SurveyUnitOfWork : UnitOfWork<SurveyApplicationDbContext>, ISurveyUnitOfWork
    {
        public IUserRepository UserRepository => (IUserRepository)GetRepository<User>();
        public IRoleRepository RoleRepository => (IRoleRepository) GetRepository<Role>();


        public SurveyUnitOfWork(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {
            RegisterRepository<User, UserRepository>();
            RegisterRepository<Role, RoleRepository>();
        }
    }
}
