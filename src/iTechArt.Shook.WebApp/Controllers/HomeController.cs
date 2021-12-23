using iTechArt.Common;
using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IUserManagementService _service;


        public HomeController(ILog logger, IUserManagementService service)
        {
            _logger = logger;
            _service = service;
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
            await _service.CreateAsync(user);
            return RedirectToAction("DisplayUsers", "Home");
        }

        public async Task<IActionResult> DisplayUsers()
        {
            _logger.LogInformation($"Displaying users method.");
            var collection = await _service.GetAllUsersAsync();
            return View(collection);
        }
    }
}