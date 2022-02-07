using iTechArt.Shook.Foundation;
using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}