using iTechArt.Shook.DomainModel;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using iTechArt.Shook.WebApp.ViewModels;

namespace iTechArt.Shook.WebApp.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class UserController : Controller
    {
        private readonly IUserManagementService _userManagementService;


        public UserController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _userManagementService.GetAllUsersAsync();

            var userViewModel = result.Select(user =>
                new UserViewModel
                {
                    User = user,
                    Roles = user.UserRoles.Select(userRole => userRole.Role).ToList()
                }).ToList();

            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var user = await _userManagementService.GetUserByUserNameAsync(userName);

            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var user = await _userManagementService.GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManagementService.DeleteUserAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Delete failed");
            }

            return RedirectToAction("Index", "User");
        }
    }
}