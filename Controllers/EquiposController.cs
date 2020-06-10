using System;
using System.Diagnostics;
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
    public class EquiposController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Equipoes
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Cliente).Include(e => e.MarcaEquipo).Include(e => e.ModeloEquipo).Include(e => e.TipoEquipo);
            return View(equipo.ToList());
        }

        // GET: Equipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipoes/Create
        public ActionResult Create()
        {
            List<MarcaEquipo> marcas = db.MarcaEquipo.ToList();
            ViewBag.IdMarca = new SelectList(marcas, "IdMarca", "Marca");

            var IdMarca = marcas.First().IdMarca;
            List<ModeloEquipo> modelos = db.ModeloEquipo.Where(x => x.IdMarca == IdMarca).ToList();
            ViewBag.IdModelo = new SelectList(modelos, "IdModelo", "Modelo");

            ViewBag.IdTipoEquipo = new SelectList(db.TipoEquipo, "IdTipo", "Tipo");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.Cliente = null; // para que no intente persistir el cliente
                db.Equipo.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", equipo.IdMarca);

            List<ModeloEquipo> modelos = db.ModeloEquipo.Where(x => x.IdMarca == equipo.IdMarca).ToList();
            ViewBag.IdModelo = new SelectList(modelos, "IdModelo", "Modelo", equipo.IdModelo);

            ViewBag.IdTipoEquipo = new SelectList(db.TipoEquipo, "IdTipo", "Tipo", equipo.IdTipoEquipo);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", equipo.IdMarca);

            List<ModeloEquipo> modelos = db.ModeloEquipo.Where(x => x.IdMarca == equipo.IdMarca).ToList();
            ViewBag.IdModelo = new SelectList(modelos, "IdModelo", "Modelo", equipo.IdModelo);

            ViewBag.IdTipoEquipo = new SelectList(db.TipoEquipo, "IdTipo", "Tipo", equipo.IdTipoEquipo);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.Cliente = null; // para que no intente persistir el cliente
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.MarcaEquipo, "IdMarca", "Marca", equipo.IdMarca);

            List<ModeloEquipo> modelos = db.ModeloEquipo.Where(x => x.IdMarca == equipo.IdMarca).ToList();
            ViewBag.IdModelo = new SelectList(modelos, "IdModelo", "Modelo", equipo.IdModelo);

            ViewBag.IdTipoEquipo = new SelectList(db.TipoEquipo, "IdTipo", "Tipo", equipo.IdTipoEquipo);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
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

        // GET: Equipos/Search
        public ActionResult Search(int idCliente)
        {
            Debug.WriteLine(idCliente);

            var equipos = db.Equipo
                .Where(x => x.IdCliente == idCliente)
                .Select(x => new
                {
                    x.IdEquipo,
                    Marca = new { x.MarcaEquipo.Marca },
                    Modelo = new { x.ModeloEquipo.Modelo },
                    Tipo = new
                    {
                        Inventario = new { x.TipoEquipo.Inventario.IdInventario, x.TipoEquipo.Inventario.TotalUnitario }
                    }
                }).ToList();

            return Json(equipos, JsonRequestBehavior.AllowGet);
        }
    }
}
