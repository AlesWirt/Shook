using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IReadOnlyCollection<string> Roles { get; set; }
    }
}
