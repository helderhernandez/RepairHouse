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

        //// GET: OrdenDiagnosticoes/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre");
        //    ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre");
        //    ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado");
        //    ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
        //    OrdenDiagnostico orden = new OrdenDiagnostico();
        //    orden.FechaEmision = new DateTime();
        //    orden.PrecioBruto = (decimal)5.0;
        //    orden.PrecioNeto = (decimal)5.0;
        //    orden.Facturado = true;


        //    orden.Comentarios = "HOLA";
        //    OrdenDiagnosticoDetalle tt = new OrdenDiagnosticoDetalle();
        //    tt.IdEquipo = 99;

        //    OrdenDiagnosticoDetalle tt2 = new OrdenDiagnosticoDetalle();
        //    tt2.IdEquipo = 77;
        //    orden.OrdenDiagnosticoDetalle.Add(tt);
        //    orden.OrdenDiagnosticoDetalle.Add(tt2);

        //    return View(orden);
        //}

        //// POST: OrdenDiagnosticoes/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdOrdenDiagnostico,FechaEmision,FechaResolucion,IdSucursal,IdEmpleado,IdCliente,Comentarios,CantidadEquipos,PrecioBruto,Descuento,PrecioNeto,IdEstado,Facturado,OrdenDiagnosticoDetalle")] OrdenDiagnostico ordenDiagnostico)
        //{
        //    Debug.WriteLine("Create");
        //    Debug.WriteLine(ordenDiagnostico.FechaEmision);
        //    Debug.WriteLine(ordenDiagnostico.FechaEmision);
        //    Debug.WriteLine(ordenDiagnostico.OrdenDiagnosticoDetalle.Count);

        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.OrdenDiagnostico.Add(ordenDiagnostico);
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Index");
        //    //}

        //    //Type objType = ordenDiagnostico.GetType();
        //    //PropertyInfo[] propertyInfoList = objType.GetProperties();
        //    //StringBuilder result = new StringBuilder();
        //    //foreach (PropertyInfo propertyInfo in propertyInfoList)
        //    //    result.AppendFormat("{0}={1} ", propertyInfo.Name, propertyInfo.GetValue(ordenDiagnostico));

        //    //Debug.WriteLine(result.ToString());

        //    //OrdenDiagnosticoDetalle detalle1 = new OrdenDiagnosticoDetalle();
        //    //detalle1.IdEquipo = 1;
        //    //detalle1.OrdenDiagnostico = ordenDiagnostico;
        //    //detalle1.IdInventario = 5;
        //    //detalle1.Cantidad = 1;
        //    //detalle1.Precio = (decimal) 2.0;
        //    //detalle1.SubTotal = (decimal) 2.0;

        //    //OrdenDiagnosticoDetalle detalle2 = new OrdenDiagnosticoDetalle();
        //    //detalle2.IdEquipo = 2;
        //    //detalle2.OrdenDiagnostico = ordenDiagnostico;
        //    //detalle2.IdInventario = 5;
        //    //detalle2.Cantidad = 1;
        //    //detalle2.Precio = (decimal)2.0;
        //    //detalle2.SubTotal = (decimal)2.0;

        //    //ordenDiagnostico.OrdenDiagnosticoDetalle.Add(detalle1);
        //    //ordenDiagnostico.OrdenDiagnosticoDetalle.Add(detalle2);


        //    //db.OrdenDiagnostico.Add(ordenDiagnostico);
        //    //db.SaveChanges();


            

        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
        //    ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
        //    ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
        //    ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
        //    return View(ordenDiagnostico);
        //}

        public ActionResult Create2()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre");
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre");
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");

            OrdenDiagnosticoViewModel o = new OrdenDiagnosticoViewModel();
            OrdenDiagnostico orden = new OrdenDiagnostico();
            orden.FechaEmision = new DateTime();
            orden.PrecioBruto = (decimal)5.0;
            orden.PrecioNeto = (decimal)5.0;
            orden.Facturado = true;


            orden.Comentarios = "HOLA";
            OrdenDiagnosticoDetalle tt = new OrdenDiagnosticoDetalle();
            tt.IdEquipo = 99;

            OrdenDiagnosticoDetalle tt2 = new OrdenDiagnosticoDetalle();
            tt2.IdEquipo = 77;


            o.OrdenDiagnostico = orden;

            o.Detalle = new List<OrdenDiagnosticoDetalle>();
            o.Detalle.Add(tt);
            o.Detalle.Add(tt2);


            return View(o);
        }

        // POST: OrdenDiagnosticoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(OrdenDiagnosticoViewModel orden)
        {
            OrdenDiagnostico ordenDiagnostico = orden.OrdenDiagnostico;

            Debug.WriteLine("Create++++++++++++++++++++++++++++++++++");
            Debug.WriteLine(ordenDiagnostico.FechaEmision);
            Debug.WriteLine(ordenDiagnostico.FechaEmision);
            Debug.WriteLine(orden.Detalle.Count);
            ordenDiagnostico.CantidadEquipos = ordenDiagnostico.CantidadEquipos +1;

            //if (ModelState.IsValid)
            //{
            //    db.OrdenDiagnostico.Add(ordenDiagnostico);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //Type objType = ordenDiagnostico.GetType();
            //PropertyInfo[] propertyInfoList = objType.GetProperties();
            //StringBuilder result = new StringBuilder();
            //foreach (PropertyInfo propertyInfo in propertyInfoList)
            //    result.AppendFormat("{0}={1} ", propertyInfo.Name, propertyInfo.GetValue(ordenDiagnostico));

            //Debug.WriteLine(result.ToString());

            //OrdenDiagnosticoDetalle detalle1 = new OrdenDiagnosticoDetalle();
            //detalle1.IdEquipo = 1;
            //detalle1.OrdenDiagnostico = ordenDiagnostico;
            //detalle1.IdInventario = 5;
            //detalle1.Cantidad = 1;
            //detalle1.Precio = (decimal) 2.0;
            //detalle1.SubTotal = (decimal) 2.0;

            //OrdenDiagnosticoDetalle detalle2 = new OrdenDiagnosticoDetalle();
            //detalle2.IdEquipo = 2;
            //detalle2.OrdenDiagnostico = ordenDiagnostico;
            //detalle2.IdInventario = 5;
            //detalle2.Cantidad = 1;
            //detalle2.Precio = (decimal)2.0;
            //detalle2.SubTotal = (decimal)2.0;

            //ordenDiagnostico.OrdenDiagnosticoDetalle.Add(detalle1);
            //ordenDiagnostico.OrdenDiagnosticoDetalle.Add(detalle2);


            //db.OrdenDiagnostico.Add(ordenDiagnostico);
            //db.SaveChanges();




            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "PrimerNombre", ordenDiagnostico.IdCliente);
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "PrimerNombre", ordenDiagnostico.IdEmpleado);
            ViewBag.IdEstado = new SelectList(db.EstadoOrdenDiagnostico, "IdEstado", "Estado", ordenDiagnostico.IdEstado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", ordenDiagnostico.IdSucursal);
            return View(orden);
        }

        [HttpPost]
        public JsonResult AgregarEquipo(Equipo equipo)
        {
            Debug.WriteLine("AgregarEquipo");
            Debug.WriteLine(equipo);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

            public JsonResult Editar(int id)
        {
            Debug.WriteLine("Hola");
            Debug.WriteLine(id);
            return Json("hola", JsonRequestBehavior.AllowGet);
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
