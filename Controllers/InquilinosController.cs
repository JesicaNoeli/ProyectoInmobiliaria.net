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
    public class InquilinosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioInquilino repositorioInquilino;
        public InquilinosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioInquilino = new RepositorioInquilino(configuration);
        }
        // GET: Inquilinos
        [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioInquilino.ObtenerTodos();
            return View(lista);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inquilinos/Create
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Inquilino i)
        {
            try
            {
                int res = repositorioInquilino.Alta(i);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Inquilinos/Edit/
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            var i = repositorioInquilino.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Inquilino i)
        {
            try
            {
                int res = repositorioInquilino.Modificacion(i);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioInquilino.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Inquilino i)
        {
            try
            {
                 
                int res = repositorioInquilino.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}