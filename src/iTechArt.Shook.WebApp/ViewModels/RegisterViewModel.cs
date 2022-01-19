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

        [Required(ErrorMessage = "Wrong email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field required password.")]
        [DataType(DataType.Password)]
        [StringLength(User.UserPasswordMaxLength,
            MinimumLength = User.UserPasswordMinLength,
            ErrorMessage = "Note enough symbols in your password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and the confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}