using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult ListaInventario()
        {
            return View();
        }
    }
}