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
using RepairHouse.Dtos;
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
            UserCurrentSessionDto USER_CURRENT = (UserCurrentSessionDto) Session[Cons.USER_CURRENT_SESSION];

            var empleados = db.Empleado
                .Select(x => new { x.IdEmpleado, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.Cargo.Descripcion });
            var sucursales = db.Sucursal
                .Where(x => x.Nombre == USER_CURRENT.Sucursal)
                .Select(x => new { x.IdSucursal, x.Nombre });
            var clientes = db.Cliente.Select(x => new { x.IdCliente, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.DUI });

            const int ID_ESTADO_COMPLETADO = 5;
            const bool FACTURADO_FALSO = false;
            var orden = new OrdenDiagnostico
            {
                FechaEmision = DateTime.Today,
                CantidadEquipos = 0,
                PrecioBruto = (decimal)0.0,
                Descuento = (decimal)0.0,
                PrecioNeto = (decimal)0.0,
                IdEstado = ID_ESTADO_COMPLETADO,
                Facturado = FACTURADO_FALSO
            };

            var payload = new { empleados, sucursales, clientes, orden };
            return Json(payload, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEquiposByClienteJsonGet(int idCliente)
        {
            const int CANTIDAD_DEFAULT = 1;
            var equipos = db.Equipo.Where(x => x.IdCliente == idCliente)
                .Select(x => new
                {
                    x.IdEquipo,
                    x.TipoEquipo.Inventario.IdInventario,
                    Costo = x.TipoEquipo.Inventario.TotalUnitario,
                    x.MarcaEquipo.Marca,
                    x.ModeloEquipo.Modelo
                });

            return Json(equipos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(OrdenDiagnosticoViewModel viewModel)
        {
            Debug.WriteLine("Create....");

            OrdenDiagnostico orden = viewModel.OrdenDiagnostico;

            List<OrdenDiagnosticoDetalle> detalles = viewModel.Detalle;
            foreach (var item in detalles)
            {
                item.OrdenDiagnostico = orden;
                orden.OrdenDiagnosticoDetalle.Add(item);

                Debug.WriteLine(item.IdEquipo);
                Debug.WriteLine(item.IdInventario);
            }

            Debug.WriteLine(orden.PrecioNeto);
            Debug.WriteLine(orden.FechaEmision);

            db.OrdenDiagnostico.Add(orden);
            db.SaveChanges();

            return Json("Create OK", JsonRequestBehavior.DenyGet);
        }

        // GET: OrdenDiagnosticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrdenDiagnosticoViewModel ordenViewModel = new OrdenDiagnosticoViewModel();

            ordenViewModel.OrdenDiagnostico = db.OrdenDiagnostico.Find(id);

            if (ordenViewModel.OrdenDiagnostico == null)
            {
                return HttpNotFound();
            }

            //ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            //ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            //ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            //ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(ordenViewModel);
        }

        public JsonResult EditJsonGet(int id)
        {
            Debug.WriteLine("EditJsonGet");
            Debug.WriteLine(id);

            var empleados = db.Empleado
                //.Where(x => x.IdCargo == 4)
                .Select(x => new { x.IdEmpleado, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.Cargo.Descripcion });
            var sucursales = db.Sucursal.Select(x => new { x.IdSucursal, x.Nombre });
            var clientes = db.Cliente.Select(x => new { x.IdCliente, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.DUI });
            var estados = db.EstadoOrdenDiagnostico.Select(x => new { x.IdEstado, x.Estado});

            var orden = db.OrdenDiagnostico
                .Select(x => new
                {
                    x.IdOrdenDiagnostico,
                    x.IdSucursal,
                    x.IdEmpleado,
                    x.IdCliente,
                    x.FechaEmision,
                    x.FechaResolucion,
                    x.IdEstado,
                    x.Facturado,
                    x.Comentarios,
                    x.CantidadEquipos,
                    x.PrecioNeto,
                    x.Descuento,
                    x.PrecioBruto
                }).FirstOrDefault(x => x.IdOrdenDiagnostico == id);

            var detalles = db.OrdenDiagnosticoDetalle.Where(x => x.IdOrdenDiagnostico == id)
                .Select(x => new
                {
                    x.IdEquipo,
                    x.IdInventario,
                    x.Costo,
                    x.Equipo.MarcaEquipo.Marca,
                    x.Equipo.ModeloEquipo.Modelo
                });

            var payload = new { empleados, sucursales, clientes, estados, orden, detalles };
            return Json(payload, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(OrdenDiagnosticoViewModel viewModel)
        {
            Debug.WriteLine("Edit....");

            OrdenDiagnostico orden = viewModel.OrdenDiagnostico;

            List<OrdenDiagnosticoDetalle> detalles = viewModel.Detalle;
            foreach (var item in detalles)
            {
                item.OrdenDiagnostico = orden;
                orden.OrdenDiagnosticoDetalle.Add(item);

                Debug.WriteLine(item.IdEquipo);
                Debug.WriteLine(item.IdInventario);
            }

            Debug.WriteLine(orden.PrecioNeto);
            Debug.WriteLine(orden.FechaEmision);

            db.OrdenDiagnostico.Add(orden);
            db.SaveChanges();

            return Json("Edit OK", JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult RemoveEquipoEnDetalle(int idOrdenDiagnostico, int idEquipo)
        {
            Debug.WriteLine("RemoveEquipoEnDetalle....");

            OrdenDiagnosticoDetalle item = db.OrdenDiagnosticoDetalle
                .Where(x => x.IdOrdenDiagnostico == idOrdenDiagnostico && x.IdEquipo == idEquipo)
                .FirstOrDefault() ;

            db.OrdenDiagnosticoDetalle.Remove(item);
            db.SaveChanges();

            return Json("Remove OK", JsonRequestBehavior.DenyGet);
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
            List<OrdenDiagnosticoDetalle> detalles = db.OrdenDiagnosticoDetalle.Where(x => x.IdOrdenDiagnostico == id).ToList();

            db.OrdenDiagnosticoDetalle.RemoveRange(detalles);
            db.OrdenDiagnostico.Remove(ordenDiagnostico);
            
            db.SaveChanges(); //hola

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
