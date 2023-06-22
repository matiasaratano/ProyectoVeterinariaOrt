using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class TurnosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
