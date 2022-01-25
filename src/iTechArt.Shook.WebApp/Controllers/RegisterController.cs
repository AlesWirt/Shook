using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountService _accountService;

        public RegisterController(IAccountService accountService)
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
                var signInResult = await _accountService.SignInAsync(user, model.Password);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("DisplayUsers", "Home");
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}