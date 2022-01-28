using iTechArt.Shook.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class SurveyApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
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
                options.Property(p => p.NormalizedName)
                    .IsRequired();
                options.Property(p => p.PasswordHash)
                    .IsRequired();
                options.Property(p => p.Email)
                    .HasMaxLength(User.UserEmailMaxLength)
                    .IsRequired();
            });
        }
    }
}