using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoInmobiliaria.Models;

namespace ProyectoInmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioPropietario repositorioPropietario;
        private readonly RepositorioInmueble repositorioInmueble;

        public InmueblesController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioPropietario = new RepositorioPropietario(configuration);
            repositorioInmueble = new RepositorioInmueble(configuration);
        }
        // GET: Inmuebles
        public ActionResult Index()
        {
            var lista = repositorioInmueble.ObtenerTodos();
            return View(lista);
        }

        // GET: Inmuebles/Details/5
        public ActionResult Disponibles(int id)
        {
            var lista = repositorioInmueble.ObtenerSiDisponible();
            return View(lista);
        }

        // GET: Inmuebles/Create
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create()
        {
            ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Inmueble i)
        {
            try
            {
                int res = repositorioInmueble.Alta(i);
                repositorioInmueble.Disponible(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult InmPorProp(int id)
        {
            var i = repositorioInmueble.BuscarPorPropietario(id);
            return View(i);

        }
        public ActionResult EditDeUs(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            return View(i);
        }
        // GET: Inmuebles/Edit/5
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
            var i = repositorioInmueble.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Inmueble i)
        {
            try
            {
               
                int res = repositorioInmueble.Modificacion(i);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Propietarios = repositorioPropietario.ObtenerTodos();
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Inmuebles/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioInmueble.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inmueble i)
        {
            try
            {
                int res = repositorioInmueble.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Filtrados()
        {
            return View();
        }
        public ActionResult Busqueda()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Busqueda(BusquedaView busqueda)
        {
            try { 
            if (busqueda.FechaInicio > busqueda.FechaCierre)
            {
                ModelState.AddModelError("", "La Fecha de Inicio debe ser anterior a la de cierre");
                return View();
            }
            else
            {
                ViewBag.Filtrados = repositorioInmueble.BuscarDesocupados(busqueda.FechaInicio, busqueda.FechaCierre);
                if (ViewBag.Filtrados.Count == 0)
                {
                    ModelState.AddModelError("", "No se encontraron resultados");
                    return View();
                }
                return View("Filtrados");
            }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        }
}