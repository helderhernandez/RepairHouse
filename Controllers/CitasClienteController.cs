using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairHouse.Dtos;
using RepairHouse.Models;

namespace RepairHouse.Controllers
{
    public class CitasClienteController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: CitasCliente
        public ActionResult Index()
        {
            ClienteCurrentSessionDto USER_CURRENT = (ClienteCurrentSessionDto)Session[Cons.USER_CURRENT_SESSION];
            var citas = db.Citas.Where(x => x.IdCliente == USER_CURRENT.IdCliente).Include(c => c.Cliente).Include(c => c.Equipo).Include(c => c.EstadoOrdenDiagnostico).Include(c => c.EstadoOrdenReparacion);
            return View(citas.ToList());
        }

        // GET: CitasCliente/Details/5
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

        // GET: CitasCliente/Create
        public ActionResult Create()
        {
            ClienteCurrentSessionDto USER_CURRENT = (ClienteCurrentSessionDto)Session[Cons.USER_CURRENT_SESSION];

            ViewBag.IdCliente = new SelectList(db.Cliente.Where(x => x.IdCliente == USER_CURRENT.IdCliente), "IdCliente", "PrimerNombre");
            ViewBag.IdEquipo = new SelectList(db.Equipo.Where(x => x.IdCliente == USER_CURRENT.IdCliente).Select(x => new { x.IdEquipo, Descripcion = x.MarcaEquipo.Marca + " " + x.ModeloEquipo.Modelo }), "IdEquipo", "Descripcion");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico.Where(x => x.IdEstado == 5), "IdEstado", "Estado");
            return View();
        }

        // POST: CitasCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

            ViewBag.IdCliente = new SelectList(db.Cliente.Where(x => x.IdCliente == citas.IdCliente), "IdCliente", "PrimerNombre");
            ViewBag.IdEquipo = new SelectList(db.Equipo.Where(x => x.IdCliente == citas.IdCliente).Select(x => new { x.IdEquipo, Descripcion = x.MarcaEquipo.Marca + " " + x.ModeloEquipo.Modelo }), "IdEquipo", "Descripcion");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico.Where(x => x.IdEstado == 5), "IdEstado", "Estado");
            return View(citas);
        }

        // GET: CitasCliente/Edit/5
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
            ViewBag.IdCliente = new SelectList(db.Cliente.Where(x => x.IdCliente == citas.IdCliente), "IdCliente", "PrimerNombre");
            ViewBag.IdEquipo = new SelectList(db.Equipo.Where(x => x.IdCliente == citas.IdCliente).Select(x => new { x.IdEquipo, Descripcion = x.MarcaEquipo.Marca + " " + x.ModeloEquipo.Modelo }), "IdEquipo", "Descripcion");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico.Where(x => x.IdEstado == citas.IdEstado), "IdEstado", "Estado");
            return View(citas);
        }

        // POST: CitasCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.IdCliente = new SelectList(db.Cliente.Where(x => x.IdCliente == citas.IdCliente), "IdCliente", "PrimerNombre");
            ViewBag.IdEquipo = new SelectList(db.Equipo.Where(x => x.IdCliente == citas.IdCliente).Select(x => new { x.IdEquipo, Descripcion = x.MarcaEquipo.Marca + " " + x.ModeloEquipo.Modelo }), "IdEquipo", "Descripcion");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico.Where(x => x.IdEstado == citas.IdEstado), "IdEstado", "Estado");
            return View(citas);
        }

        // GET: CitasCliente/Delete/5
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

        // POST: CitasCliente/Delete/5
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
