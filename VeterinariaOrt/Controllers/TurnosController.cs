using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            DAO_turnos.confirmarTurno(turnoId);
            return RedirectToAction("Index"); 
            
        }

        [HttpGet]
        [Authorize]
        
        public IActionResult MisTurnos(int dni)
        {
            List<Turnos> turnos = DAO_turnos.MisTurnos(dni);
            return View(turnos);
        }



    }
}
