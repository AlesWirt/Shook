using Microsoft.AspNetCore.Identity;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
