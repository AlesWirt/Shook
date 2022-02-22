using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Shook.Repositories.DbContexts
{
    public class SurveyApplicationDbContext : DbContext
    {
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

            builder.Entity<Survey>(options =>
            {
                options.HasOne(s => s.Owner)
                .WithMany(o => o.Surveys)
                .HasForeignKey(s => s.OwnerId);

                options.Property(p => p.Title)
                .HasMaxLength(Survey.SurveyMaxLength)
                .IsRequired();
            });

            builder.Entity<Question>(options =>
            {
                options.HasOne(q => q.Survey)
                .WithMany(s => s.Questions);

                options.Property(p => p.Title)
                .HasMaxLength(Question.QuestionMaxLength)
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
                        Name = RoleNames.Admin,
                        NormalizedName = RoleNames.Admin.ToUpper()
                    });

                options.HasData(
                    new Role
                    {
                        Id = 2,
                        Name = RoleNames.User,
                        NormalizedName = RoleNames.User.ToUpper()
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