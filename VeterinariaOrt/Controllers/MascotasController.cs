﻿using Microsoft.AspNetCore.Mvc;

namespace VeterinariaOrt.Controllers
{
    public class MascotasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
