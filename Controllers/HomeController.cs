using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoInmobiliaria.Models;

namespace ProyectoInmobiliaria.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string saludo = User.Identity.IsAuthenticated ?
                $"Hola {User.Identity.Name}": "Bienvenido";
            ViewBag.Saludo = saludo;
           
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Galeria()
        {
            return View();
        }


        [Authorize(Policy = "Administrador")]
        public IActionResult SuperRestringido()
        {
            return View();
        }

        [Authorize(Policy ="Propietario")]
        public IActionResult Privado()
        {
            return View();
        }
        [Authorize(Policy = "Empleado")]
        public IActionResult AlgoRestringido()
        {
            return View();
        }
        public IActionResult Restringido()
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
