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
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = user.UserRoles.Select(userRole => userRole.Role).ToList()
                }).ToList();

            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? userId)
        {
            if (userId == null || userId == 0)
            {
                return NotFound();
            }

            var user = await _userManagementService.GetUserByUserIdAsync(userId);

            var updateUserViewModel = new UpdateUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName
            };

            if (user == null)
            {
                return NotFound();
            }

            return View(updateUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateUserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var user = await _userManagementService.GetUserByUserIdAsync(userViewModel.Id);
            user.UserName = userViewModel.UserName;
            await _userManagementService.UpdateUserAsync(user);

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? userId)
        {
            if (userId == null || userId == 0)
            {
                return NotFound();
            }

            var user = await _userManagementService.GetUserByUserIdAsync(userId);

            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var user = await _userManagementService.GetUserByUserIdAsync(id);

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