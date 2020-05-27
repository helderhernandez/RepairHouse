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
    public class MarcaEquiposController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: MarcaEquipos
        public ActionResult Index()
        {
            return View(db.MarcaEquipo.ToList());
        }

        // GET: MarcaEquipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaEquipo marcaEquipo = db.MarcaEquipo.Find(id);
            if (marcaEquipo == null)
            {
                return HttpNotFound();
            }
            return View(marcaEquipo);
        }

        // GET: MarcaEquipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcaEquipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMarca,Marca")] MarcaEquipo marcaEquipo)
        {
            if (ModelState.IsValid)
            {
                db.MarcaEquipo.Add(marcaEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marcaEquipo);
        }

        // GET: MarcaEquipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaEquipo marcaEquipo = db.MarcaEquipo.Find(id);
            if (marcaEquipo == null)
            {
                return HttpNotFound();
            }
            return View(marcaEquipo);
        }

        // POST: MarcaEquipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMarca,Marca")] MarcaEquipo marcaEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcaEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcaEquipo);
        }

        // GET: MarcaEquipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaEquipo marcaEquipo = db.MarcaEquipo.Find(id);
            if (marcaEquipo == null)
            {
                return HttpNotFound();
            }
            return View(marcaEquipo);
        }

        // POST: MarcaEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcaEquipo marcaEquipo = db.MarcaEquipo.Find(id);
            db.MarcaEquipo.Remove(marcaEquipo);
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
