using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }

        public IList<string> Roles { get; set; }
    }
}
