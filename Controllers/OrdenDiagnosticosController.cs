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

namespace RepairHouse.Controllers
{
    public class OrdenDiagnosticosController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: OrdenDiagnosticoes
        public ActionResult Index()
        {
            var ordenDiagnostico = db.OrdenDiagnostico.Include(o => o.Cliente).Include(o => o.Empleado).Include(o => o.EstadoOrdenDiagnostico).Include(o => o.Sucursal);
            return View(ordenDiagnostico.OrderByDescending(x => x.FechaEmision).ToList());
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
            UserCurrentSessionDto USER_CURRENT = (UserCurrentSessionDto)Session[Cons.USER_CURRENT_SESSION];

            const int ID_ESTADO_CREADO = 5;
            const bool FACTURADO_FALSO = false;

            Sucursal sucursal = db.Sucursal.FirstOrDefault(x => x.Nombre == USER_CURRENT.SucursalEmpleado);
            Empleado empleado = db.Empleado.FirstOrDefault(x => x.IdEmpleado == USER_CURRENT.IdEmpleado);

            OrdenDiagnostico ordenDiagnostico = new OrdenDiagnostico()
            {
                FechaEmision = DateTime.Today,
                Sucursal = sucursal,
                Empleado = empleado,
                Cliente = new Cliente(),
                PrecioBruto = (decimal)0.0,
                Descuento = (decimal)0.0,
                PrecioNeto = (decimal)0.0,
                IdEstado = ID_ESTADO_CREADO,
                Facturado = FACTURADO_FALSO
            };

            return View(ordenDiagnostico);
        }

        [HttpPost]
        public JsonResult Create(OrdenDiagnostico orden)
        {
            orden.OrdenDiagnosticoDetalle.ToList().ForEach(x => x.OrdenDiagnostico = orden);

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

            //OrdenDiagnosticoViewModel0 ordenViewModel = new OrdenDiagnosticoViewModel0();

            OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);

            if (ordenDiagnostico == null)
            {
                return HttpNotFound();
            }

            return View(ordenDiagnostico);
        }

        [HttpPost]
        public JsonResult Edit(OrdenDiagnostico orden)
        {
            orden.OrdenDiagnosticoDetalle.ToList().ForEach(x => x.OrdenDiagnostico = orden);
            foreach (OrdenDiagnosticoDetalle item in orden.OrdenDiagnosticoDetalle)
            {
                item.OrdenDiagnostico = orden;
                if (item.IdOrdenDiagnosticoDetalle > 0)
                {
                    db.Entry(item).State = EntityState.Modified; //para no duplicar
                }
            }

            db.OrdenDiagnostico.Add(orden);
            db.Entry(orden).State = EntityState.Modified; //para no duplicar
            db.SaveChanges();

            return Json("Edit OK", JsonRequestBehavior.DenyGet);
        }

        //[HttpPost]
        //public JsonResult RemoveEquipoEnDetalle(int idOrdenDiagnostico, int idEquipo)
        //{
        //    Debug.WriteLine("RemoveEquipoEnDetalle....");

        //    OrdenDiagnosticoDetalle item = db.OrdenDiagnosticoDetalle
        //        .Where(x => x.IdOrdenDiagnostico == idOrdenDiagnostico && x.IdEquipo == idEquipo)
        //        .FirstOrDefault() ;

        //    db.OrdenDiagnosticoDetalle.Remove(item);
        //    db.SaveChanges();

        //    return Json("Remove OK", JsonRequestBehavior.DenyGet);
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
            List<OrdenDiagnosticoDetalle> detalles = db.OrdenDiagnosticoDetalle.Where(x => x.IdOrdenDiagnostico == id).ToList();

            db.OrdenDiagnosticoDetalle.RemoveRange(detalles);
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
