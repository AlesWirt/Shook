using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string userName)
            : this()
        {
            UserName = UserName;
        }
    }
}
