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
                options.ToTable("AspNetUsers");
                options.HasKey(p => p.Id);
                options.Property(p => p.UserName).IsRequired().HasMaxLength(16);
            });
        }
    }
}
