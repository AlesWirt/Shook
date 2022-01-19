using System.Collections.Generic;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 16;
        public const int UserPasswordMaxLength = 20;
        public const int UserPasswordMinLength = 8;


        public int Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedName { get; set; }

        public string PasswordHash { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}