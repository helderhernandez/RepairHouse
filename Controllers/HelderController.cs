using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class HelderController : Controller
    {
        // GET: Helder
        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormularioBasico(string email, int edad)
        {
            Debug.WriteLine(email + " - " + edad);
            return Content("todo salio bien :D");
        }
    }
}