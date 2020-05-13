using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Usuario()
        {
            return View();
        }
        public ActionResult Empleado()
        {
            return View();
        }
        public ActionResult Departamentos()
        {
            return View();
        }
        public ActionResult Municipios()
        {
            return View();
        }
        public ActionResult Cargos()
        {
            return View();
        }
    }
}