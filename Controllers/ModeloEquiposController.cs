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
    public class ModeloEquiposController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: ModeloEquipos
        public ActionResult Index()
        {
            var modeloEquipo = db.ModeloEquipo.Include(m => m.MarcaEquipo);
            return View(modeloEquipo.ToList());
        }

        // GET: ModeloEquipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloEquipo modeloEquipo = db.ModeloEquipo.Find(id);
            if (modeloEquipo == null)
            {
                return HttpNotFound();
            }
            return View(modeloEquipo);
        }

        // GET: ModeloEquipos/Create
        public ActionResult Create()
        {
            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca");
            return View();
        }

        // POST: ModeloEquipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdModelo,Modelo,IdMarca")] ModeloEquipo modeloEquipo)
        {
            if (ModelState.IsValid)
            {
                db.ModeloEquipo.Add(modeloEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", modeloEquipo.IdMarca);
            return View(modeloEquipo);
        }

        // GET: ModeloEquipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloEquipo modeloEquipo = db.ModeloEquipo.Find(id);
            if (modeloEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", modeloEquipo.IdMarca);
            return View(modeloEquipo);
        }

        // POST: ModeloEquipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdModelo,Modelo,IdMarca")] ModeloEquipo modeloEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", modeloEquipo.IdMarca);
            return View(modeloEquipo);
        }

        // GET: ModeloEquipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloEquipo modeloEquipo = db.ModeloEquipo.Find(id);
            if (modeloEquipo == null)
            {
                return HttpNotFound();
            }
            return View(modeloEquipo);
        }

        // POST: ModeloEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloEquipo modeloEquipo = db.ModeloEquipo.Find(id);
            db.ModeloEquipo.Remove(modeloEquipo);
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
