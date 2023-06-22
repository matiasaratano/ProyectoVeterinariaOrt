using VeterinariaOrt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace VeterinariaOrt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ESTA PARTE ES LA QUE ME FALTO, ES PARA USAR LA SESSION

            //ClaimsPrincipal claimsuser = HttpContext.User;
            //string nombreUsuario = "";

            //if (claimsuser.Identity.IsAuthenticated) {

            //    nombreUsuario = claimsuser.Claims.Where(c => c.Type == ClaimTypes.Name);

            //        Select(c => c.Value).SingleOrDefault();
            //}


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}