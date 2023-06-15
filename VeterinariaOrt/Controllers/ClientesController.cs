using Microsoft.AspNetCore.Mvc;
using VeterinariaOrt.Models;

namespace VeterinariaOrt.Controllers
{
    public class ClientesController : Controller
    {
        DAO_Clientes DAO = new DAO_Clientes();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        

        
        [HttpPost]
        public IActionResult CrearClientes(Clientes clientes)
        {
            DAO.CrearClientes(clientes);
            return RedirectToAction(nameof(Index));
        }
        }

}
