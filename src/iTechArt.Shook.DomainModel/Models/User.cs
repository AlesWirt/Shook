namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public const int UserNameMinLength = 2;
        public const int UserNameMaxLength = 16;


        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
