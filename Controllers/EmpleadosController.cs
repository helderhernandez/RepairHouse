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
    public class EmpleadosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Cargo).Include(e => e.Diagnostico).Include(e => e.EstadoEmpleado).Include(e => e.Municipio).Include(e => e.Sexo).Include(e => e.Sucursal);
            return View(empleado.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descripcion");
            ViewBag.IdEmpleado = new SelectList(db.Diagnostico, "IdDiagnostico", "Diagnostico1");
            ViewBag.IdEstado = new SelectList(db.EstadoEmpleado, "IdEstado", "Estado");
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1");
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DeCasada,IdSexo,DUI,NIT,IdMunicipio,Domicilio,IdSucursal,IdCargo,IdEstado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descripcion", empleado.IdCargo);
            ViewBag.IdEmpleado = new SelectList(db.Diagnostico, "IdDiagnostico", "Diagnostico1", empleado.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoEmpleado, "IdEstado", "Estado", empleado.IdEstado);
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", empleado.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", empleado.IdSexo);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", empleado.IdSucursal);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descripcion", empleado.IdCargo);
            ViewBag.IdEmpleado = new SelectList(db.Diagnostico, "IdDiagnostico", "Diagnostico1", empleado.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoEmpleado, "IdEstado", "Estado", empleado.IdEstado);
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", empleado.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", empleado.IdSexo);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", empleado.IdSucursal);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DeCasada,IdSexo,DUI,NIT,IdMunicipio,Domicilio,IdSucursal,IdCargo,IdEstado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Descripcion", empleado.IdCargo);
            ViewBag.IdEmpleado = new SelectList(db.Diagnostico, "IdDiagnostico", "Diagnostico1", empleado.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoEmpleado, "IdEstado", "Estado", empleado.IdEstado);
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", empleado.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", empleado.IdSexo);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", empleado.IdSucursal);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
