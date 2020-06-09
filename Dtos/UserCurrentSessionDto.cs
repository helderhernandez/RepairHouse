using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Dtos
{
    public class UserCurrentSessionDto
    {
        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public string CargoEmpleado { get; set; }

        public string SucursalEmpleado { get; set; }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public string RolUsuario { get; set; }        
    }
}