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
    public class AdminController : Controller
    {
        private readonly IUserManagementService _userManagementService;


        public AdminController(IUserManagementService userManagementService)
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
                    UserName = user.UserName,
                    Roles = user.UserRoles.Select(userRole => userRole.Role.Name).ToList()
                }).ToList();

            return View(userViewModel);
        }
    }
}