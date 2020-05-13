using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using ProyectoInmobiliaria.Models;

namespace ProyectoInmobiliaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioInmueble repositorioInmueble;
        private readonly RepositorioPropietario repositorioPropietario;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioInmueble = new RepositorioInmueble(configuration);
            repositorioPropietario = new RepositorioPropietario(configuration);
        }
        public IActionResult Index()
        {
            string saludo = User.Identity.IsAuthenticated ?
                $"Bienvenido {User.Identity.Name}": "Bienvenido  Visitante";
            ViewBag.Saludo = saludo;

            if (User.IsInRole("Administrador"))
            {
                return RedirectToAction(nameof(SuperRestringido));
            }
            else if (User.IsInRole("Empleado"))
                {
                return RedirectToAction(nameof(AlgoRestringido));
            }
            else if (User.IsInRole("Propietario"))
            {
                return RedirectToAction(nameof(Privado));
            }
            else
            {
                return View();
            }


        }

       

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

       
        public IActionResult Galeria()
        {
            var lista = repositorioInmueble.ObtenerTodos();
            return View(lista);
        }


        [Authorize(Policy = "Administrador")]
        public IActionResult SuperRestringido()
        {
            return View();
        }

        [Authorize(Policy = "Propietario")]
        public IActionResult Privado()
        {
                Propietario p = repositorioPropietario.ObtenerPorEmail(User.Identity.Name);
                var lista = repositorioInmueble.BuscarPorPropietario(p.IdProp);
                return View(lista);
            
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
