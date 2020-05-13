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
    public class PagoController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioContrato repositorioContrato;
        private readonly RepositorioPago repositorioPago;
        private readonly RepositorioInmueble repositorioInmueble;

        public PagoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioContrato = new RepositorioContrato(configuration);
            repositorioPago = new RepositorioPago(configuration);
            repositorioInmueble = new RepositorioInmueble(configuration);
        }
        // GET: Pago
        [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioPago.ObtenerTodos();
            return View(lista);
        }

        // GET: Pago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pago/Create
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(int id)
        {
            ViewBag.Contrato = repositorioContrato.ObtenerPorInm(id);
            Contrato c = repositorioContrato.ObtenerPorInm(id);
            IList<Pago> pagos = repositorioPago.ObtenerPorContr(c.IdContr);
            if(pagos.Count == 0)
            {
                ViewBag.NumPago = 1;
            }
            else
            {
                int np = pagos.Count;
                ViewBag.NumPago = np + 1;
            }

            return View();
        }

        // POST: Pago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Pago p)
        {
            try
            {
                // TODO: Add insert logic here
                int res = repositorioPago.Alta(p);
                return RedirectToAction(nameof(Ver));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                
                return View();
            }
        }
        [Authorize(Policy = "Permitidos")]
        public ActionResult Ver(int id)
        {
            ViewBag.Contrato = repositorioContrato.ObtenerPorInm(id);
            Contrato c = repositorioContrato.ObtenerPorInm(id);
            IList<Pago> pagos = repositorioPago.ObtenerPorContr(c.IdContr);
            return View(pagos);
        }

     
        // GET: Pago/Edit/5
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id)
        {
            var p = repositorioPago.ObtenerPorId(id);
            return View(p);
        }

        // POST: Pago/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Pago p)
        {
            try
            {
                // TODO: Add update logic here
               int res = repositorioPago.Modificacion(p);
                return View();
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));

            }
        }

        // GET: Pago/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var p = repositorioPago.ObtenerPorId(id);
            return View(p);
        }

        // POST: Pago/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pago p)
        {
            try
            {

                int res = repositorioPago.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}