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

        public HomeController(IUserManagementService service)
        {
            _userManagementService = service;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.Name,
            };

            var result = await _userManagementService.RegisterAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("DisplayUsers", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> DisplayUsers()
        {
            var collection = await _userManagementService.DisplayAllUsersAsync();
            return View(collection);
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
    }
}