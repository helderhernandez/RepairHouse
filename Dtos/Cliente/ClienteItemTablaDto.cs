using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Dtos.Cliente
{
    public class ClienteItemTablaDto
    {
        public ClienteItemTablaDto(int id, string nombreCompleto, string dui, string telefono)
        {
            this.id = id;
            this.nombreCompleto = nombreCompleto;
            this.dui = dui;
            this.telefono = telefono;
        }

        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public string dui { get; set; }
        public string telefono { get; set; }
    }
}