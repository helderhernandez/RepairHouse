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
    
    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            this.Diagnostico = new HashSet<Diagnostico>();
            this.FacturaDetalle = new HashSet<FacturaDetalle>();
            this.OrdenDiagnosticoDetalle = new HashSet<OrdenDiagnosticoDetalle>();
            this.OrdenReparacionDetalle = new HashSet<OrdenReparacionDetalle>();
        }
    
        public int IdEquipo { get; set; }
        public int IdCliente { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public string NumeroSerie { get; set; }
        public string Color { get; set; }
        public int IdTipoEquipo { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnostico> Diagnostico { get; set; }
        public virtual MarcaEquipo MarcaEquipo { get; set; }
        public virtual ModeloEquipo ModeloEquipo { get; set; }
        public virtual TipoEquipo TipoEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDiagnosticoDetalle> OrdenDiagnosticoDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenReparacionDetalle> OrdenReparacionDetalle { get; set; }
    }
}
