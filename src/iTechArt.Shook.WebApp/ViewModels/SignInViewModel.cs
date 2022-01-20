using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Wrong name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wrong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
