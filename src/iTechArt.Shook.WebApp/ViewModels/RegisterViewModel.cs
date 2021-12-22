using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please, enter your name")]
        [MinLength(2)]
        [MaxLength(12)]
        [Display(Name = "Login this")]
        public string Name { get; set; }
    }
}
