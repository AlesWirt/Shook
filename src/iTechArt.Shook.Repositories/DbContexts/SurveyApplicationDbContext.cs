using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.DomainModel.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class SurveyApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
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
                options.Property(p => p.NormalizedName)
                    .IsRequired();
                options.Property(p => p.PasswordHash)
                    .IsRequired();
            });

            builder.Entity<Role>(options =>
            {
                options.Property(p => p.Name)
                    .IsRequired();
                options.Property(p => p.NormalizedName)
                    .IsRequired();

                options.HasData(
                    new Role
                    {
                        Id = 1,
                        Name = Helper.Admin,
                        NormalizedName = Helper.Admin.ToUpper()
                    });

                options.HasData(
                    new Role
                    {
                        Id = 2,
                        Name = Helper.User,
                        NormalizedName = Helper.User.ToUpper()
                    });
            });

            builder.Entity<UserRole>(options =>
            {
                options.HasKey(ck => new { ck.UserId, ck.RoleId });

                options.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

                options.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);
            });
        }
    }
}