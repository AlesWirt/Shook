using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.DomainModel.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
