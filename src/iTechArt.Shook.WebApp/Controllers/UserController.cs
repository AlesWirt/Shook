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
        private readonly IAccountService _accountService;


        public UserController(IUserManagementService userManagementService,
            IAccountService accountService)
        {
            _userManagementService = userManagementService;
            _accountService = accountService;
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
        public async Task<IActionResult> Update(int userId)
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
        public async Task<IActionResult> Update(UpdateUserViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            var newUser = new User
            {
                Id = userVM.Id,
                UserName = userVM.UserName,
                Email = userVM.Email
            };

            //var user = await _userManagementService.GetUserByIdAsync(userVM.Id);

            //await _userManagementService.UpdateUserAsync(user, newUser);

            var result = await _accountService.UpdateAsync(newUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(userVM);
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