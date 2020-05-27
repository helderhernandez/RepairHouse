using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RepairHouse.Models;
using RepairHouse.Models.ViewsModels;

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

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult CreateJsonGet()
        {
            var empleados = db.Empleado
                .Where(x => x.IdCargo == 1)
                .Select(x => new { x.IdEmpleado, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.Cargo.Descripcion });
            var sucursales = db.Sucursal.Select(x => new { x.IdSucursal, x.Nombre });
            var clientes = db.Cliente.Select(x => new { x.IdCliente, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.DUI });

            var orden = new OrdenDiagnostico
            {
                FechaEmision = DateTime.Today,
                CantidadEquipos = 0,
                PrecioBruto = (decimal)0.0,
                Descuento = (decimal)0.0,
                PrecioNeto = (decimal)0.0
            };

            var payload = new { empleados, sucursales, clientes, orden };
            return Json(payload, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEquiposByClienteJsonGet(int idCliente)
        {
            var equipos = db.Equipo.Where(x => x.IdCliente == idCliente)
                .Select(x => new
                {
                    x.IdEquipo,
                    x.MarcaEquipo.Marca,
                    x.ModeloEquipo.Modelo,
                    x.TipoEquipo.Inventario.TotalUnitario
                });

            return Json(equipos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(OrdenDiagnosticoViewModel viewModel)
        {
            Debug.WriteLine("Create....");
            Debug.WriteLine(viewModel);

            return Json("Create", JsonRequestBehavior.DenyGet);
        }

        // GET: OrdenDiagnosticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrdenDiagnosticoFormViewModel ordenViewModel = new OrdenDiagnosticoFormViewModel();

            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);

            ordenViewModel.OrdenDiagnostico = ordenDiagnostico;

            if (ordenDiagnostico == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenViewModel);
        }

        [HttpPost]
        public JsonResult GetDetalle(int idOrden)
        {
            Debug.WriteLine("hOLAAAAA");
            Debug.WriteLine(idOrden);
            var detalle = db.OrdenDiagnosticoDetalle
                .Include(x => x.Equipo)
                .Where(x => x.IdOrdenDiagnostico == idOrden)

                .Select(x => new
                {
                    Id = x.IdOrdenDiagnosticoDetalle,
                    IdEquipo = x.Equipo.IdEquipo,
                    Marca = x.Equipo.MarcaEquipo.Marca,
                    Modelo = x.Equipo.ModeloEquipo.Modelo,
                    PrecioDiagnostico = x.Equipo.TipoEquipo.Inventario.TotalUnitario,
                })
                .ToList();

            //foreach (var item in detalle)
            //{
            //    Debug.WriteLine(item.IdOrdenDiagnosticoDetalle);
            //    Debug.WriteLine(item.Equipo.Color);
            //    Debug.WriteLine(item.Equipo.MarcaEquipo.Marca);
            //    Debug.WriteLine(item.Equipo.TipoEquipo.Inventario.TotalUnitario);
            //}

            //.Select(x => new
            // {
            //     Id = x.IdOrdenDiagnosticoDetalle,
            //     IdEquipo = x.Equipo.IdEquipo,
            //     Marca = x.Equipo.MarcaEquipo,
            //     Modelo = x.Equipo.ModeloEquipo,
            //     PrecioDiagnostico = x.Equipo.TipoEquipo.Inventario.TotalUnitario
            // })

            return Json(detalle, JsonRequestBehavior.DenyGet);
        }

        // POST: OrdenDiagnosticoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdenDiagnosticoFormViewModel ordenViewModel)
        {
            OrdenDiagnostico ordenDiagnostico = ordenViewModel.OrdenDiagnostico;

            Debug.WriteLine("Create++++++++++++++++++++++++++++++++++");
            Debug.WriteLine(ordenDiagnostico.FechaEmision);
            Debug.WriteLine(ordenDiagnostico.FechaEmision);
            Debug.WriteLine(ordenViewModel.EquiposId.Count);

            //if (ModelState.IsValid)
            //{
            //    db.Entry(ordenDiagnostico).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenViewModel);
        }

        //// GET: OrdenDiagnosticoes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);
        //    if (ordenDiagnostico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
        //    ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
        //    ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
        //    ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
        //    return View(ordenDiagnostico);
        //}

        //// POST: OrdenDiagnosticoes/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdOrdenDiagnostico,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,Comentarios,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado")] OrdenDiagnostico ordenDiagnostico)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ordenDiagnostico).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
        //    ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
        //    ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
        //    ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
        //    return View(ordenDiagnostico);
        //}

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
