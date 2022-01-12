using System.ComponentModel.DataAnnotations;
using iTechArt.Shook.DomainModel.Models;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(maximumLength: User.UserNameMaxLength, 
            MinimumLength = User.UserNameMinLength, 
            ErrorMessage = "Not enough symbols in field")]
        [Display(Name = "User name")]
        public string Name { get; set; }
    }
}