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
    public class DiagnosticosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Diagnosticoes
        public ActionResult Index()
        {
            var diagnostico = db.Diagnostico.Include(d => d.Equipo).Include(d => d.OrdenDiagnostico).Include(d => d.Empleado);
            return View(diagnostico.ToList());
        }

        // GET: Diagnosticoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie");
            ViewBag.IdOrdenDiagnostico = new SelectList(db.OrdenDiagnostico, "IdOrdenDiagnostico", "Comentarios");
            ViewBag.IdDiagnostico = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre");
            return View();
        }

        // POST: Diagnosticoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDiagnostico,FechaRegistro,IdEquipo,IdTecnico,IdOrdenDiagnostico,Diagnostico1,ComentariosCotizacion,TotalCotizacion")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Diagnostico.Add(diagnostico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", diagnostico.IdEquipo);
            ViewBag.IdOrdenDiagnostico = new SelectList(db.OrdenDiagnostico, "IdOrdenDiagnostico", "Comentarios", diagnostico.IdOrdenDiagnostico);
            ViewBag.IdDiagnostico = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", diagnostico.IdDiagnostico);
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", diagnostico.IdEquipo);
            ViewBag.IdOrdenDiagnostico = new SelectList(db.OrdenDiagnostico, "IdOrdenDiagnostico", "Comentarios", diagnostico.IdOrdenDiagnostico);
            ViewBag.IdDiagnostico = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", diagnostico.IdDiagnostico);
            return View(diagnostico);
        }

        // POST: Diagnosticoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDiagnostico,FechaRegistro,IdEquipo,IdTecnico,IdOrdenDiagnostico,Diagnostico1,ComentariosCotizacion,TotalCotizacion")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnostico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEquipo = new SelectList(db.Equipo, "IdEquipo", "NumeroSerie", diagnostico.IdEquipo);
            ViewBag.IdOrdenDiagnostico = new SelectList(db.OrdenDiagnostico, "IdOrdenDiagnostico", "Comentarios", diagnostico.IdOrdenDiagnostico);
            ViewBag.IdDiagnostico = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", diagnostico.IdDiagnostico);
            return View(diagnostico);
        }

        // GET: Diagnosticoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // POST: Diagnosticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnostico diagnostico = db.Diagnostico.Find(id);
            db.Diagnostico.Remove(diagnostico);
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
