using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Clientes");
        }
    }
}
