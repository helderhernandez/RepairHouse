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
    public class CategoriaInventariosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: CategoriaInventarios
        public ActionResult Index()
        {
            return View(db.CategoriaInventario.ToList());
        }

        // GET: CategoriaInventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaInventario categoriaInventario = db.CategoriaInventario.Find(id);
            if (categoriaInventario == null)
            {
                return HttpNotFound();
            }
            return View(categoriaInventario);
        }

        // GET: CategoriaInventarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaInventarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoriaInventario,Categoria")] CategoriaInventario categoriaInventario)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaInventario.Add(categoriaInventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaInventario);
        }

        // GET: CategoriaInventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaInventario categoriaInventario = db.CategoriaInventario.Find(id);
            if (categoriaInventario == null)
            {
                return HttpNotFound();
            }
            return View(categoriaInventario);
        }

        // POST: CategoriaInventarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoriaInventario,Categoria")] CategoriaInventario categoriaInventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaInventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaInventario);
        }

        // GET: CategoriaInventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaInventario categoriaInventario = db.CategoriaInventario.Find(id);
            if (categoriaInventario == null)
            {
                return HttpNotFound();
            }
            return View(categoriaInventario);
        }

        // POST: CategoriaInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaInventario categoriaInventario = db.CategoriaInventario.Find(id);
            db.CategoriaInventario.Remove(categoriaInventario);
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
