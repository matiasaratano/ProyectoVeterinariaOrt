using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
