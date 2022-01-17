using iTechArt.Shook.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class SurveyApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public SurveyApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(options =>
            {
                options.Property(p => p.UserName)
                    .HasMaxLength(User.UserNameMaxLength)
                    .IsRequired();
            });

            builder.Entity<UserRole>(options =>
            {
                options.Property(p => p.Name)
                    .IsRequired();
            });
        }
    }
}
