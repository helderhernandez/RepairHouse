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
    public class OrdenDiagnosticosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: OrdenDiagnosticoes
        public ActionResult Index()
        {
            var ordenDiagnostico = db.OrdenDiagnostico.Include(o => o.Cliente).Include(o => o.Empleado).Include(o => o.EstadoOrdenDiagnostico).Include(o => o.Sucursal);
            return View(ordenDiagnostico.ToList());
        }

        // GET: OrdenDiagnosticoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);
            if (ordenDiagnostico == null)
            {
                return HttpNotFound();
            }
            return View(ordenDiagnostico);
        }

        // GET: OrdenDiagnosticoes/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // POST: OrdenDiagnosticoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdenDiagnostico,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,Comentarios,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado")] OrdenDiagnostico ordenDiagnostico)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDiagnostico.Add(ordenDiagnostico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenDiagnostico);
        }

        // GET: OrdenDiagnosticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);
            if (ordenDiagnostico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenDiagnostico);
        }

        // POST: OrdenDiagnosticoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdenDiagnostico,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,Comentarios,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado")] OrdenDiagnostico ordenDiagnostico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDiagnostico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenDiagnostico);
        }

        // GET: OrdenDiagnosticoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);
            if (ordenDiagnostico == null)
            {
                return HttpNotFound();
            }
            return View(ordenDiagnostico);
        }

        // POST: OrdenDiagnosticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);
            db.OrdenDiagnostico.Remove(ordenDiagnostico);
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
