using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                UserName = model.Name,
                Email = model.Email
            };

            var result = await _accountService.RegisterAsync(user, model.Password);

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
        

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
    }
}