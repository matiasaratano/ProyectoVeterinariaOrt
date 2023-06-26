using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class Reservas_TurnosController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
