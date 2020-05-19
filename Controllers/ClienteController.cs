using RepairHouse.Daos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Listado
        public ActionResult Index()
        {
            return View();
        }

        // GET: List
        public JsonResult List()
        {
            // momentaneamente simularemos los datos de la db
            var clientes = new[] {
                new { id = 11, nombreCompleto = "William Alexander Landaverde Hernandez", dui = "12345678-9", telefono = "2211-3344" },
                new { id = 12, nombreCompleto = "Kenya Beatriz Castellanos Gonzalez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 13, nombreCompleto = "Bill Alfonso Quezada Gates", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 14, nombreCompleto = "William William William William", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 15, nombreCompleto = "Alexander Alexander Alexander Alexander", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 16, nombreCompleto = "Landaverde Landaverde Landaverde Landaverde", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 17, nombreCompleto = "Hernandez Hernandez Hernandez Hernandez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 18, nombreCompleto = "Kenya Kenya Kenya Kenya", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 19, nombreCompleto = "Beatriz Beatriz Beatriz Beatriz", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 21, nombreCompleto = "Castellanos Castellanos Castellanos Castellanos", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 22, nombreCompleto = "Gonzalez Gonzalez Gonzalez Gonzalez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 23, nombreCompleto = "Bill Bill Bill Bill", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 24, nombreCompleto = "Alfonso Alfonso Alfonso Alfonso", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 25, nombreCompleto = "Quezada Quezada Quezada Quezada", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 26, nombreCompleto = "Gates Gates Gates Gates", dui = "12345678-9", telefono = "2211-3344"}
            };

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Object modelCliente)
        {
            // aca iria la logica para guardar con los models en la db
            return View();
        }

        // GET: Edit/ID
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            // aca iria la logica para editar con los models en la db
            return View();
        }

        // POST: Delete/ID
        [HttpPost]
        public JsonResult Delete(int id)
        {
            // aca irir la logica para eliminar con los models en la db
            return Json(true, JsonRequestBehavior.DenyGet);
        }
    }
}