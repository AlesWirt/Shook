using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class SignInController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserManagementService _userManagementService;


        public SignInController(IAccountService accountService,
            IUserManagementService userManagementService)
        {
            _accountService = accountService;
            _userManagementService = userManagementService;
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LogInViewModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManagementService.GetUserByUserNameAsync(logInModel.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt");

                return View(logInModel);
            }

            var result = await _accountService.SignInAsync(user, logInModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("DisplayUsers", "Home");
            }

            ModelState.AddModelError("", "Invalid password");

            return View(logInModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("SignIn", "SignIn");
        }
    }
}