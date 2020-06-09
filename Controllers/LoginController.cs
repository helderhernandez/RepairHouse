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
using RepairHouse.Dtos;

namespace RepairHouse.Controllers
{
    public class LoginController : Controller
    {
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
                .Include(x => x.Rol).Include(x => x.Empleado).FirstOrDefault();

            if(result != null)
            {
                UserCurrentSessionDto userCurrent = new UserCurrentSessionDto
                {
                    IdEmpleado = result.Empleado.IdEmpleado,
                    NombreEmpleado = result.Empleado.PrimerNombre + " " + result.Empleado.PrimerApellido,
                    CargoEmpleado = result.Empleado.Cargo.Descripcion,
                    SucursalEmpleado = result.Empleado.Sucursal.Nombre,
                    IdUsuario = result.IdUsuario,
                    NombreUsuario = result.Usuario1,
                    RolUsuario = result.Rol.Rol1
                };

                Session[Cons.USER_CURRENT_SESSION] = userCurrent;
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
    }
}