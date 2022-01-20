using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 16;
        public const int UserPasswordMaxLength = 20;
        public const int UserPasswordMinLength = 8;
        public const int UserEmailMaxLength = 25;
        public const int UserEmailMinLength = 12;


        public int Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedName { get; set; }

        public string PasswordHash { get; set; }

        [RegularExpression(@"(\w{2,8}\d{0,4})@([a-z]{2,8}).(\w{2,4})")]
        public string Email { get; set; }
    }
}