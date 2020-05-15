using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoInmobiliaria.Models;

namespace ProyectoInmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioPropietario repositorioPropietario;
        public PropietariosController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioPropietario = new RepositorioPropietario(configuration);
        }
        // GET: Propietarios
        [Authorize(Policy = "Permitidos")]
        public ActionResult Index()
        {
            var lista = repositorioPropietario.ObtenerTodos();
            return View(lista);
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Propietarios/Create
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Create(Propietario p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = repositorioPropietario.Alta(p);
                    TempData["Mensaje"] = "Propietario Registrado";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Mensaje"] = "Error de registro Verifique los datos";
                    return View();
                }
               
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Propietarios/Edit/
        [Authorize(Policy = "Permitidos")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            
            var p = repositorioPropietario.ObtenerPorId(id);
            return View(p);
        }

        // POST: Propietarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Permitidos")]
        public ActionResult Edit(int id, Propietario p)
        {
            try
            {
                int res = repositorioPropietario.Modificacion(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Policy = "Propietario")]
        public ActionResult EditarPerfil(string email)
        {
           var prop = repositorioPropietario.ObtenerPorEmail(email);
            //repositorioPropietario.Modificacion(prop);
            return View(prop);
        }

       /* [ValidateAntiForgeryToken]
        [Authorize(Policy = "Propietario")]
        public ActionResult EditarPerfil(int id, Propietario p)
        {
            try
            {
                int res = repositorioPropietario.Modificacion(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Propietarios/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repositorioPropietario.ObtenerPorId(id);
            return View(i);
        }

        // POST: Propietarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Propietario p)
        {
            try
            {
                int res = repositorioPropietario.Baja(id);
                TempData["Mensaje"] = "Propietario Eliminado";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}