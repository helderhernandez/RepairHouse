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
    public class ClientesController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Municipio).Include(c => c.Sexo).Include(c => c.Factura);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Registrarse
        public ActionResult Registrarse()
        {
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1");
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1");
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrarse([Bind(Include = "IdCliente,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DeCasada,IdSexo,Email,DUI,NIT,Telefono,IdMunicipio,Domicilio,Usuario,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Cliente", "Login");
            }

            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", cliente.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", cliente.IdSexo);
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura", cliente.IdCliente);
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1");
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1");
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DeCasada,IdSexo,Email,DUI,NIT,Telefono,IdMunicipio,Domicilio,Usuario,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", cliente.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", cliente.IdSexo);
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura", cliente.IdCliente);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", cliente.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", cliente.IdSexo);
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura", cliente.IdCliente);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,DeCasada,IdSexo,Email,DUI,NIT,Telefono,IdMunicipio,Domicilio,Usuario,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.Municipio, "IdMunicipio", "Municipio1", cliente.IdMunicipio);
            ViewBag.IdSexo = new SelectList(db.Sexo, "IdSexo", "Sexo1", cliente.IdSexo);
            ViewBag.IdCliente = new SelectList(db.Factura, "IdFactura", "IdFactura", cliente.IdCliente);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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

        // GET: Clientes/Search
        public ActionResult Search(string nombreCliente)
        {
            Debug.WriteLine(nombreCliente);

            var clientes = db.Cliente
                .Where(x =>
                    x.PrimerNombre.Contains(nombreCliente) ||
                    x.SegundoNombre.Contains(nombreCliente) ||
                    x.PrimerApellido.Contains(nombreCliente) ||
                    x.SegundoApellido.Contains(nombreCliente) ||
                    nombreCliente.Contains(x.PrimerNombre) ||
                    nombreCliente.Contains(x.SegundoNombre) ||
                    nombreCliente.Contains(x.PrimerApellido) ||
                    nombreCliente.Contains(x.SegundoApellido)
                )
                .Select(x => new
                {
                    x.IdCliente,
                    NombreCliente = (x.PrimerNombre + " " + x.SegundoNombre + " " + x.PrimerApellido + " " + x.SegundoApellido).Trim(),
                    x.DUI,
                    x.NIT,
                    x.Email,
                    x.Domicilio,
                    Sexo = new { x.Sexo.IdSexo, Sexo = x.Sexo.Sexo1 },
                    Municipio = new { x.Municipio.IdMunicipio, Municipio = x.Municipio.Municipio1 },
                });

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}
