using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IAccountService _accountService;


        public SignInController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _accountService.SignInAsync(model.Name, model.Password);

            if (result.Succeeded)
            {
                var user = _accountService.FindByNameAsync(model.Name);

                return RedirectToAction("DisplayUsers", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _accountService.LogOffAsync();
            return RedirectToAction("Register", "Account");
        }
    }
}
