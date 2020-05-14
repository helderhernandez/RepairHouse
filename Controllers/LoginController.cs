using RepairHouse.Daos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class LoginController : Controller
    {
        UsuarioDao usuarioDao = new UsuarioDao();

        // GET: /login
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Login/Entrar
        [HttpPost]
        public ActionResult Entrar(string usuario, string contrasena)
        {
            bool resultVal = usuario == null || contrasena == null || usuario.Trim() == "" || contrasena.Trim() == "";
            if (resultVal)
            {
                // lanzamos error si las validaciones no se cumplen
                throw new HttpException((int)HttpStatusCode.BadRequest, "Usuario y Constraseña requeridos");
            }

            // si no continuamos el flujo
            if (usuarioDao.buscarPorCredenciales(usuario, contrasena))
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