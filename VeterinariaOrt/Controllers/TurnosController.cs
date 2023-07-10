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

        [HttpPost]
        [Authorize]
        public ActionResult ReservarTurno(int turnoId)
        {
            string Sdni = HttpContext.Session.GetString("SDNI");

            DAO_turnos.confirmarTurno(turnoId,Sdni);
            return RedirectToAction("Index"); 
            
        }

        [HttpGet]
        [Authorize]
        
        public IActionResult MisTurnos()
        {
            string Sdni = HttpContext.Session.GetString("SDNI");

            List<Turnos> turnos = DAO_turnos.MisTurnos(Sdni);
            return View(turnos);
        }



    }
}
