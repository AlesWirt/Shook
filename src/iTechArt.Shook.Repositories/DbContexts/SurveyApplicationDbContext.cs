using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class SurveyApplicationDbContext : IdentityDbContext
    {
        public SurveyApplicationDbContext(DbContextOptions<SurveyApplicationDbContext> context)
            : base(context)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
