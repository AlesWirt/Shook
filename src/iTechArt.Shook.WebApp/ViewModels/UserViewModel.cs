using System.Collections.Generic;

namespace iTechArt.Shook.WebApp.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public IReadOnlyCollection<string> Roles { get; set; }
    }
}
