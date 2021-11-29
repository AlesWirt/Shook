using iTechArt.Repositories;
using iTechArt.Shook.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Clicker);
        }

        [HttpPost]
        public IActionResult IncreaseClicker()
        {
            Repository.IncreaseClicker();
            return View("Index", Repository.Clicker);
        }
    }
}
