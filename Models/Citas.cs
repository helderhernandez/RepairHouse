//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepairHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Citas
    {
        [Display(Name = "Codigo")]
        public int Id_Citas { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> IdCliente { get; set; }
        [Display(Name = "Equipo")]
        public Nullable<int> IdEquipo { get; set; }
        [Display(Name = "Estado")]
        public Nullable<int> IdEstado { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Fecha de Cita")]
        public Nullable<System.DateTime> FechaCita { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual EstadoOrdenDiagnostico EstadoOrdenDiagnostico { get; set; }
        public virtual EstadoOrdenReparacion EstadoOrdenReparacion { get; set; }
    }
}
