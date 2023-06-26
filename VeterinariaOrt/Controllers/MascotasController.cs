using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class MascotasController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
