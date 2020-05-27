using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairHouse.Models;

namespace RepairHouse.Controllers
{
    public class TipoEquiposController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: TipoEquipoes
        public ActionResult Index()
        {
            var tipoEquipo = db.TipoEquipo.Include(t => t.Inventario);
            return View(tipoEquipo.ToList());
        }

        // GET: TipoEquipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Create
        public ActionResult Create()
        {
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "Descripcion");
            return View();
        }

        // POST: TipoEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipo,Tipo,IdInventario")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "Descripcion", tipoEquipo.IdInventario);
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "Descripcion", tipoEquipo.IdInventario);
            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipo,Tipo,IdInventario")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdInventario = new SelectList(db.Inventario, "IdInventario", "Descripcion", tipoEquipo.IdInventario);
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            db.TipoEquipo.Remove(tipoEquipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
