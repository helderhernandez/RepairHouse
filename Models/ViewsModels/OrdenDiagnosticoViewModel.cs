using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairHouse.Models.ViewsModels
{
    public class OrdenDiagnosticoViewModel
    {
        public OrdenDiagnosticoViewModel()
        {
            Detalle = new List<OrdenDiagnosticoDetalle>();
        }

        public OrdenDiagnostico OrdenDiagnostico { get; set; }

        public List<OrdenDiagnosticoDetalle> Detalle { get; set; }
    }
}