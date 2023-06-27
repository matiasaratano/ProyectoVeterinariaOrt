using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaOrt.Models;

namespace VeterinariaOrt.Controllers
{
    public class TurnosController : Controller
    {
       DAO_Turnos DAO_turnos = new DAO_Turnos();
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            List<Turnos> turnos = DAO_turnos.ListarTurnos();
            return View(turnos);
        }
    }
}
