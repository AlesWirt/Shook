namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        public const int userNameMaxLength = 16;
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
