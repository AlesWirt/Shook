using iTechArt.Common;
using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Repositories.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace iTechArt.Shook.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly SignInManager<User> _signInManager;


        public UserRepository(ILog logger, SurveyApplicationDbContext context)
            : base(logger, context)
        {

        }

        public async Task CreateAsync(User user)
        {

        }

        public async Task SignInUserAsync(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }
    }
}
