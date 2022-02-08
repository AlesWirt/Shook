using Microsoft.AspNetCore.Mvc;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HttpStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
