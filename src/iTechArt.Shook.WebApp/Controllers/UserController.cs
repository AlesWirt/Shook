using iTechArt.Common;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.DomainModel.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILog _logger;
        private readonly IUserService _service;


        public UserController(ILog logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            _logger.LogInformation($"Creating users page.");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name
                };
                await _service.CreateAsync(user);
                return RedirectToAction("DisplayUsers", "User");
            }
            return View(model);
        }

        public async Task<IActionResult> DisplayUsers()
        {
            _logger.LogInformation($"Displaying users method.");
            var collection = await _service.GetAllUsersAsync();
            return View(collection);
        }
    }
}
