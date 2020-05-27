using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Models.ViewsModels
{
    public class OrdenDiagnosticoFormViewModel
    {
        public OrdenDiagnosticoFormViewModel()
        {
            EquiposId = new List<int>();
        }

        public OrdenDiagnostico OrdenDiagnostico { get; set; }

        public List<int> EquiposId { get; set; }
    }
}