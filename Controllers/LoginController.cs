using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class LoginController : Controller
    {
        // GET: /login
        public ActionResult Index()
        {
            return View();
        }

        // GET: /login
        [HttpPost]
        public ActionResult Entrar(string usuario, string contrasena)
        {
            if (usuario == "admin" && contrasena == "1234")
            {
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
    }
}