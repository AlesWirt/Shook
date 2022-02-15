using iTechArt.Shook.DomainModel.Models;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field required users name.")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: User.UserNameMaxLength,
            MinimumLength = User.UserNameMinLength,
            ErrorMessage = "Not enough symbols in field")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Wrong email.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(User.UserEmailMaxLength,
            MinimumLength = User.UserEmailMinLength,
            ErrorMessage = "Note enough symbols in your email")]
        [RegularExpression(@"(\w{2,8}\d{0,4})@([a-z]{2,8}).(\w{2,4})",
            ErrorMessage = "Wrong email pattern")]
        public string Email { get; set; }
    }
}
