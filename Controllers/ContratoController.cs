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
    [Authorize]
    public class ContratoController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioInmueble repositorioInmueble;
        private readonly RepositorioInquilino repositorioInquilino;
        private readonly RepositorioContrato repositorioContrato;

        public ContratoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioInmueble = new RepositorioInmueble(configuration);
            repositorioInquilino = new RepositorioInquilino(configuration);
            repositorioContrato = new RepositorioContrato(configuration);
        }
        // GET: Contrato
        [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioContrato.ObtenerTodos();
            return View(lista);
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contrato/Create
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(int id)
        {
            ViewBag.Inmueble = repositorioInmueble.ObtenerPorId(id);
            ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
            return View();
        }

        // POST: Contrato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Contrato c)
        {
            try
            {
                // TODO: Add insert logic here
                int res = repositorioContrato.Alta(c);
                Inmueble inm = repositorioInmueble.ObtenerPorId(c.IdInm);
                repositorioContrato.Vigente(c);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
               
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
      
        public ActionResult Ver(int id)
        {
            try
            {
                ViewBag.Id = id;
                var lista = repositorioContrato.ObtenerTodosPorInm(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

            }
        }
        // GET: Contrato/Edit/5
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
            var i = repositorioContrato.ObtenerPorId(id);
            return View(i);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Contrato c)
        {
            try
            {
                int res = repositorioContrato.Modificacion(c);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Contrato/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            try
            {
                var c = repositorioContrato.ObtenerPorId(id);
                return View(c);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: Contrato/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Contrato c)
        {
            try
            {
                // TODO: Add delete logic here
                int res = repositorioContrato.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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
        public async Task<IActionResult> Busqueda(PorFechaView busqueda)
        {
            try
            {
                
                    ViewBag.Filtrados = repositorioContrato.VigentesPorFecha(busqueda.FechaBusqueda);
                    if (ViewBag.Filtrados.Count == 0)
                    {
                        ModelState.AddModelError("", "No se encontraron resultados");
                        return View();
                    }
                    return View("Filtrados");
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}