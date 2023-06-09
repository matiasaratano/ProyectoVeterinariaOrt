﻿using VeterinariaOrt.Models;
using VeterinariaOrt.Recursos;
using VeterinariaOrt.Servicios.Contrato;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;


namespace VeterinariaOrt.Controllers
{
    public class InicioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService) {

            _usuarioService = usuarioService;

        }

        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Clave = Utils.EncriptarClave(modelo.Clave);
            Usuario usuario_creado = await _usuarioService.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
            public async Task<IActionResult> IniciarSesion(string mail, string clave)
            {

                Usuario usuario_encontrado = await _usuarioService.GetUsuario(mail, Utils.EncriptarClave(clave));
               
            if (usuario_encontrado == null)
                {
                    ViewData["Mensaje"] = "No se encontraron coincidencias";
                    return View();
            }
            else {
                string dniUsuario = usuario_encontrado.DNI.ToString();

                HttpContext.Session.SetString("SDNI", dniUsuario);
                HttpContext.Session.GetString("SDNI");
            }
            List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,usuario_encontrado.Nombre)
                
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties
                        );

                return RedirectToAction("Index", "Home");
            }
        
     }

 }
    