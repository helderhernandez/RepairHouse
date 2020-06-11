using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairHouse.Dtos;
using RepairHouse.Models;

namespace RepairHouse.Controllers
{
    public class EquiposClienteController : Controller
    {
        private casa_reparadoraEntities db = new casa_reparadoraEntities();

        // GET: EquiposCliente/Create
        public ActionResult Create()
        {
            ClienteCurrentSessionDto USER_CURRENT = (ClienteCurrentSessionDto)Session[Cons.USER_CURRENT_SESSION];

            Equipo equipo = new Equipo()
            {
                IdCliente = USER_CURRENT.IdCliente,
                Cliente = new Cliente()
                {
                    PrimerNombre = USER_CURRENT.NombreCliente
                }
            };

            List<MarcaEquipo> marcas = db.MarcaEquipo.ToList();
            ViewBag.IdMarca = new SelectList(marcas, "IdMarca", "Marca");

            var IdMarca = marcas.First().IdMarca;
            List<ModeloEquipo> modelos = db.ModeloEquipo.Where(x => x.IdMarca == IdMarca).ToList();
            ViewBag.IdModelo = new SelectList(modelos, "IdModelo", "Modelo");

            ViewBag.IdTipoEquipo = new SelectList(db.TipoEquipo, "IdTipo", "Tipo");
            return View(equipo);
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipo equipo)
        {
            equipo.Cliente = null; // para que no intente persistir el cliente

            Debug.WriteLine(equipo.IdEquipo);
            Debug.WriteLine(equipo.IdMarca);
            Debug.WriteLine(equipo.IdModelo);
            Debug.WriteLine(equipo.IdCliente);
            Debug.WriteLine(equipo.IdTipoEquipo);

            equipo.Cliente = null;
            db.Equipo.Add(equipo);
            Debug.WriteLine("Antes de guardar");
            db.SaveChanges();
            return RedirectToAction("Index", "CitasCliente");
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
