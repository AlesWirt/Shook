using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.DomainModel.Models
{
    public class Clicker
    {
        [Key]
        public int Id { get; set; }
        
        public int Counter { get; set; }
    }
}
