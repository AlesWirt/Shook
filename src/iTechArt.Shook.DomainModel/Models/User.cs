namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 16;
        public const int UserPasswordMaxLength = 45;
        public const int UserPasswordMinLength = 8;


        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}
