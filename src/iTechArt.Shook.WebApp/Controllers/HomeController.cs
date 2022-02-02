using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManagementService _userManagementService;


        public HomeController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayUsers()
        {
            var userCollection = await _userManagementService.GetAllUsersAsync();
            var displayUsers = new DisplayUsersViewModel();
            
            foreach(var user in userCollection)
            {
                if(displayUsers.UserViewModel == null)
                {
                    displayUsers.UserViewModel = new List<UserViewModel>();
                }

                displayUsers.UserViewModel.Add(new UserViewModel
                {
                    User = user,
                    Roles = await _userManagementService.GetRolesAsync(user)
                });
            }
            
            return View(displayUsers);
        }
    }
}