using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            base.OnModelCreating(builder);
            builder.Entity<User>(UserConfiguring);
        }


        private void UserConfiguring(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SurveyUsers").HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(14);
        }
    }
}
