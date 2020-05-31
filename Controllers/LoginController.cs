using RepairHouse.Daos;
using RepairHouse.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class LoginController : Controller
    {
        UsuarioDao usuarioDao = new UsuarioDao();

        private casa_reparadoraEntities db = new casa_reparadoraEntities();

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

            Usuario result = db.Usuario
                .Where(x => x.Usuario1 == usuario && x.Contrasena == contrasena && x.Habilitado == true)
                .Include(x => x.Rol).FirstOrDefault();

            if(result != null)
            {
                Debug.WriteLine(result.Rol.Rol1);
            }
            else
            {
                return Content("false");
            }

            // si no continuamos el flujo
            if (usuarioDao.buscarPorCredenciales(usuario, contrasena))
            {
                Session[Cons.USER_CURRENT_SESSION] = usuario;
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
    }
}