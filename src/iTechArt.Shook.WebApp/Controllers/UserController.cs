using iTechArt.Shook.DomainModel;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using iTechArt.Shook.WebApp.ViewModels;
using iTechArt.Shook.DomainModel.Models;

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
                    Email = user.Email,
                    Roles = user.UserRoles.Select(userRole => userRole.Role).ToList()
                }).ToList();

            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int userId)
        {
            var user = await _userManagementService.GetUserByIdAsync(userId);

            var userVM = new UpdateUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var userEdit = new User
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email
            };

            var user = await _userManagementService.GetUserByIdAsync(userEdit.Id);

            var result = await _userManagementService.UpdateUserAsync(user, userEdit);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userModel);
        }

        [HttpGet]
        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _userManagementService.GetUserByIdAsync(userId);

            var result = await _userManagementService.DeleteUserAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Delete failed");
            }

            return RedirectToAction("Index", "User");
        }
    }
}