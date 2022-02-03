using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.DomainModel;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.Repositories.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider provider, string userPassword)
        {
            var adminId = await EnsureUser(provider, "123456", "Steve", "wirt94@mail.ru");
            var result = await EnsureRole(provider, adminId, RoleNames.Admin);
            
            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong, after add role attempt.");
            }

            result = await EnsureRole(provider, adminId, RoleNames.User);

            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong, after add role attempt.");
            }
        }


        private static async Task<string> EnsureUser(IServiceProvider provider,
            string userPassword, string userName, string email)
        {

            var userManager = provider.GetService<UserManager<User>>();

            var user = await userManager.FindByNameAsync(userName);
            if(user == null)
            {
                var passwordHasher = new PasswordHasher<User>();

                var passwordHash = passwordHasher.HashPassword(user, userPassword);

                user = new User()
                {
                    UserName = userName,
                    NormalizedName = userName.ToUpper(),
                    Email = email,
                    PasswordHash = passwordHash
                };

                var identityResult = await userManager.CreateAsync(user);

                if (!identityResult.Succeeded)
                {
                    throw new Exception("Invalid creating attempt.");
                }
            }

            return await  Task.FromResult(user.Id.ToString());
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider provider,
            string userId, string roleName)
        {
            IdentityResult identityResult = null;

            var roleManager = provider.GetService<RoleManager<Role>>();

            if(roleManager == null)
            {
                throw new ArgumentNullException("RoleManager does not exist");
            }

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                identityResult = await roleManager.CreateAsync(new Role
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
            }

            var userManager = provider.GetService<UserManager<User>>();

            var user = await userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new ArgumentNullException("User does not exist");
            }

            identityResult = await userManager.AddToRoleAsync(user, roleName);

            return identityResult;
        }
    }
}
