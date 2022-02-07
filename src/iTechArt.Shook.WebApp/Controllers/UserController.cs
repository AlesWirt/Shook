using iTechArt.Shook.DomainModel;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserManagementService _userManagementService;
        private readonly SignInManager<User> _signInManager;


        public UserController(IAccountService accountService,
            IUserManagementService userManagementService,
            SignInManager<User> signInManager)
        {
            _accountService = accountService;
            _userManagementService = userManagementService;
            _signInManager = signInManager;
        }

        public async  Task<IActionResult> CheckUserRoles()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);

            if(await _accountService.IsInRoleAsync(user, RoleNames.Admin))
            {
                return RedirectToAction("DisplayAdminStartPage");
            }

            return RedirectToAction("DisplayUserStartPage");
        }
        
        public IActionResult DisplayUserStartPage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAdminStartPage()
        {
            var result = await _userManagementService.GetAllUsersAsync();

            return View(result);
        }
    }
}
