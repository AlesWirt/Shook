using System.ComponentModel.DataAnnotations;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Wrong name.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wrong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}