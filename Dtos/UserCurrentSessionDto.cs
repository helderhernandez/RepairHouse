using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Dtos
{
    public class UserCurrentSessionDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Cargo { get; set; }

        public string Sucursal { get; set; }

        public string Username { get; set; }

        public string Rol { get; set; }

        
    }
}