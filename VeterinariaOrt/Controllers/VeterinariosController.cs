using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class VeterinariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
