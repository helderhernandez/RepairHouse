using RepairHouse.Daos;
using RepairHouse.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairHouse.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ClienteDao clienteDao = new ClienteDao();

        // GET: Empleado
        public ActionResult Listado()
        {
            Debug.WriteLine("Listado...");
            return View();
        }

        public JsonResult ListadoJson()
        {
            Debug.WriteLine("ListadoJson...");
            List<ClienteItemTablaDto> clientes = clienteDao.traerTodos();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}