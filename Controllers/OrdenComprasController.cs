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
    public class OrdenComprasController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: OrdenCompras
        public ActionResult Index()
        {
            var ordenCompra = db.OrdenCompra.Include(o => o.Proveedor);
            return View(ordenCompra.ToList());
        }

        // GET: OrdenCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre");
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdenCompra,Codigo,Descripcion,Cantidad,IdProveedor,FechaIngreso,PrecioBruto,SubTotal,Iva,Total,FacturaProveedor")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenCompra.Add(ordenCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenCompra.IdProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenCompra.IdProveedor);
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdenCompra,Codigo,Descripcion,Cantidad,IdProveedor,FechaIngreso,PrecioBruto,SubTotal,Iva,Total,FacturaProveedor")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenCompra.IdProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            if (ordenCompra == null)
            {
                return HttpNotFound();
            }
            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            db.OrdenCompra.Remove(ordenCompra);
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
