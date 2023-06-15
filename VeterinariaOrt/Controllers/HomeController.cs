using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index2()
        {
            return RedirectToAction("Index","Clientes");
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Mascotas");
        }
    }
}
