using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairHouse.Models;

namespace RepairHouse.Controllers
{
    public class InventariosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Inventarios
        public ActionResult Index()
        {
            var inventario = db.Inventario.Include(i => i.CategoriaInventario).Include(i => i.Proveedor);
            return View(inventario.ToList());
        }

        // GET: Inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CategoriaInventario, "IdCategoriaInventario", "Categoria");
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre");
            return View();
        }

        // POST: Inventarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInventario,Descripcion,Cantidad,PrecioNeto,Iva,TotalUnitario,Fecha,IdProveedor,IdCategoria")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Inventario.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CategoriaInventario, "IdCategoriaInventario", "Categoria", inventario.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", inventario.IdProveedor);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaInventario, "IdCategoriaInventario", "Categoria", inventario.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", inventario.IdProveedor);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInventario,Descripcion,Cantidad,PrecioNeto,Iva,TotalUnitario,Fecha,IdProveedor,IdCategoria")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CategoriaInventario, "IdCategoriaInventario", "Categoria", inventario.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", inventario.IdProveedor);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventario.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventario inventario = db.Inventario.Find(id);
            db.Inventario.Remove(inventario);
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
