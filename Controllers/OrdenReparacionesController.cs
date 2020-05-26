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
    public class OrdenReparacionesController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: OrdenReparacions
        public ActionResult Index()
        {
            var ordenReparacion = db.OrdenReparacion.Include(o => o.Cliente).Include(o => o.Empleado).Include(o => o.EstadoOrdenReparacion).Include(o => o.Sucursal);
            return View(ordenReparacion.ToList());
        }

        // GET: OrdenReparacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenReparacion ordenReparacion = db.OrdenReparacion.Find(id);
            if (ordenReparacion == null)
            {
                return HttpNotFound();
            }
            return View(ordenReparacion);
        }

        // GET: OrdenReparacions/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenReparacion, "IdEstado", "Estado");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // POST: OrdenReparacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdenReparacion,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado")] OrdenReparacion ordenReparacion)
        {
            if (ModelState.IsValid)
            {
                db.OrdenReparacion.Add(ordenReparacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenReparacion.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenReparacion.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenReparacion, "IdEstado", "Estado", ordenReparacion.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenReparacion.IdSucursal);
            return View(ordenReparacion);
        }

        // GET: OrdenReparacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenReparacion ordenReparacion = db.OrdenReparacion.Find(id);
            if (ordenReparacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenReparacion.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenReparacion.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenReparacion, "IdEstado", "Estado", ordenReparacion.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenReparacion.IdSucursal);
            return View(ordenReparacion);
        }

        // POST: OrdenReparacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdenReparacion,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado")] OrdenReparacion ordenReparacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenReparacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenReparacion.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenReparacion.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenReparacion, "IdEstado", "Estado", ordenReparacion.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenReparacion.IdSucursal);
            return View(ordenReparacion);
        }

        // GET: OrdenReparacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenReparacion ordenReparacion = db.OrdenReparacion.Find(id);
            if (ordenReparacion == null)
            {
                return HttpNotFound();
            }
            return View(ordenReparacion);
        }

        // POST: OrdenReparacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenReparacion ordenReparacion = db.OrdenReparacion.Find(id);
            db.OrdenReparacion.Remove(ordenReparacion);
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
