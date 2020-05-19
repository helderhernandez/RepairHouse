using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class ProveedorController : Controller
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
            var proveedores = new[] {
                new { id = 11, nombre = "Respuestos Amilcar", estado = "ACTIVO" },
                new { id = 12, nombre = "Mundo PC", estado = "ACTIVO" },
                new { id = 13, nombre = "Insumos informaticos", estado = "ACTIVO" },
                new { id = 14, nombre = "Repuestos ESA", estado = "ACTIVO" },
                new { id = 15, nombre = "Dell ESA", estado = "ACTIVO" },
                new { id = 16, nombre = "Casa Rivas", estado = "ACTIVO" },
                new { id = 17, nombre = "HP Company", estado = "ACTIVO" },
                new { id = 18, nombre = "Repuestos Valdes", estado = "ACTIVO" },
                new { id = 19, nombre = "Doctor PC", estado = "ACTIVO" },
                new { id = 20, nombre = "Microsoft Distribuidor", estado = "ACTIVO" },
                new { id = 21, nombre = "Distribuidora Informatica", estado = "ACTIVO" },
                new { id = 22, nombre = "PC World", estado = "ACTIVO" }
            };

            return Json(proveedores, JsonRequestBehavior.AllowGet);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Object modelProveedor)
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