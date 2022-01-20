using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            var collection = await _userManagementService.DisplayAllUsersAsync();
            return View(collection);
        }
    }
}