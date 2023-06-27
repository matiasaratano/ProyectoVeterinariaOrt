using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeterinariaOrt.Models;

namespace VeterinariaOrt.Controllers
{
    public class MascotasController : Controller
    {
        DAO_Mascota DAO = new DAO_Mascota();
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CrearMascotas(Mascotas mascota)
        {
            DAO.CrearMascota(mascota);
            return RedirectToAction(nameof(Index));
        }
    }
}
