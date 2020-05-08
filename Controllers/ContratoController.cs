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
        public ActionResult Create()
        {
            ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Inmuebles = repositorioInmueble.ObtenerTodos();
                ViewBag.Inquilinos = repositorioInquilino.ObtenerTodos();
                ViewBag.Error = ex.Message;
                return View(c);
            }
        }

        // GET: Contrato/Edit/5
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
             var i = repositorioContrato.ObtenerPorId(id);
            return View(i);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
    }
}