using RepairHouse.Models;
using RepairHouse.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class OrdenesDiagnosticoController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: OrdenesDiagnostico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult CreateJsonGet()
        {
            var empleados = db.Empleado
                .Where(x => x.IdCargo == 1)
                .Select(x => new { x.IdEmpleado, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.Cargo.Descripcion});
            var sucursales = db.Sucursal.Select(x => new { x.IdSucursal, x.Nombre });
            var clientes = db.Cliente.Select(x => new { x.IdCliente, Nombre = x.PrimerNombre + " " + x.PrimerApellido, x.DUI });

            var orden = new OrdenDiagnostico
            {
                FechaEmision = DateTime.Today,
                CantidadEquipos = 0,
                PrecioBruto = (decimal) 0.0,
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        public JsonResult EditJson(int id)
        {
            //OrdenDiagnosticoFormViewModel ordenViewModel = new OrdenDiagnosticoFormViewModel();

            //var clientes = db.OrdenDiagnostico.Include(x => x.Cliente)

            //OrdenDiagnostico ordenDiagnostico = db.OrdenDiagnostico.Find(id);

            //ordenViewModel.OrdenDiagnostico = ordenDiagnostico;


            //ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            //ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            //ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            //ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return Json("hola", JsonRequestBehavior.AllowGet);
        }
    }
}