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
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var user = new User
            {
                UserName = registerModel.Login,
                Email = registerModel.Email
            };

            var result = await _accountService.RegisterAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                var signInResult = await _accountService.SignInAsync(user, registerModel.Password);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("DisplayUsers", "Home");
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerModel);
        }
    }
}