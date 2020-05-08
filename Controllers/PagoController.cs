﻿using System;
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

        public PagoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioContrato = new RepositorioContrato(configuration);
            repositorioPago = new RepositorioPago(configuration);
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
        public ActionResult Create()
        {
            ViewBag.Contrato = repositorioContrato.ObtenerTodos();
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
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
                repositorioPago.Modificacion(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pago/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var p = repositorioPago.ObtenerPorId(id);
            return View();
        }

        // POST: Pago/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pago p)
        {
            try
            {
              
                repositorioPago.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}