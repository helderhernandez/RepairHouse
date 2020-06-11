using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Dtos
{
    public class ClienteCurrentSessionDto
    {
        public int IdCliente { get; set; }

        public string NombreCliente { get; set; }

        public string NombreUsuario { get; set; }
        public bool MostrarBienvenida { get; set; }
    }
}