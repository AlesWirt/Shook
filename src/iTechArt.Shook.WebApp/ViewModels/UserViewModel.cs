using iTechArt.Shook.DomainModel.Models;
using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public IList<string> Roles { get; set; }
    }
}
