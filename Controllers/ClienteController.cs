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
            return View();
        }

        public JsonResult ListadoJson()
        {
            // List<ClienteItemTablaDto> clientes = clienteDao.traerTodos();

            var clientes = new[] {
                new { id = 11, nombreCompleto = "William Alexander Landaverde Hernandez", dui = "12345678-9", telefono = "2211-3344" },
                new { id = 22, nombreCompleto = "Kenya Beatriz Castellanos Gonzalez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 33, nombreCompleto = "Bill Alfonso Quezada Gates", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 44, nombreCompleto = "William William William William", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 55, nombreCompleto = "Alexander Alexander Alexander Alexander", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 66, nombreCompleto = "Landaverde Landaverde Landaverde Landaverde", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 77, nombreCompleto = "Hernandez Hernandez Hernandez Hernandez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 88, nombreCompleto = "Kenya Kenya Kenya Kenya", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 99, nombreCompleto = "Beatriz Beatriz Beatriz Beatriz", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 100, nombreCompleto = "Castellanos Castellanos Castellanos Castellanos", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 200, nombreCompleto = "Gonzalez Gonzalez Gonzalez Gonzalez", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 300, nombreCompleto = "Bill Bill Bill Bill", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 400, nombreCompleto = "Alfonso Alfonso Alfonso Alfonso", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 500, nombreCompleto = "Quezada Quezada Quezada Quezada", dui = "12345678-9", telefono = "2211-3344"},
                new { id = 600, nombreCompleto = "Gates Gates Gates Gates", dui = "12345678-9", telefono = "2211-3344"}
            };

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}