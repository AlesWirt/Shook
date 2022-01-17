using iTechArt.Shook.Foundation;
using iTechArt.Shook.DomainModel.Models;
using iTechArt.Shook.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iTechArt.Shook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}