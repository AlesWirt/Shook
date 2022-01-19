using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public AccountController(IUserManagementService service)
        {
            _userManagementService = service;
        }

        public IActionResult Index()
        {
            return View();
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

            var result = await _userManagementService.RegisterAsync(user, model.Password);

            

            if (result.Succeeded)
            {
                return RedirectToAction("DisplayUsers", "Account");
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

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _userManagementService.LogOffAsync();
            
            return RedirectToAction("Register", "Account");
        }
    }
}
