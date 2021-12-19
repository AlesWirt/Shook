using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }
    }
}
