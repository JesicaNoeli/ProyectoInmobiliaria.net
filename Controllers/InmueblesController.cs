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
        public ActionResult Details(int id)
        {
            return View();
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
                return RedirectToAction(nameof(Index));
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
    }
}