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
    public class CitasController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Cliente).Include(c => c.Equipo).Include(c => c.EstadoOrdenDiagnostico).Include(c => c.EstadoOrdenReparacion);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre");
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenReparacion, "IdEstado", "Estado");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Citas,IdCliente,IdEquipo,IdEstado,Observaciones,FechaCita")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", citas.IdCliente);
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", citas.IdEquipo);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", citas.IdEstado);
            return View(citas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", citas.IdCliente);
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", citas.IdEquipo);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", citas.IdEstado);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Citas,IdCliente,IdEquipo,IdEstado,Observaciones,FechaCita")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", citas.IdCliente);
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", citas.IdEquipo);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", citas.IdEstado);
            return View(citas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
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
