//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepairHouse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Factura = new HashSet<Factura>();
            this.OrdenDiagnostico = new HashSet<OrdenDiagnostico>();
            this.OrdenReparacion = new HashSet<OrdenReparacion>();
            this.OrdenReparacionDetalle = new HashSet<OrdenReparacionDetalle>();
            this.Usuario = new HashSet<Usuario>();
        }
    
        public int IdEmpleado { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string DeCasada { get; set; }
        public int IdSexo { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public int IdMunicipio { get; set; }
        public string Domicilio { get; set; }
        public int IdSucursal { get; set; }
        public int IdCargo { get; set; }
        public int IdEstado { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual Diagnostico Diagnostico { get; set; }
        public virtual EstadoEmpleado EstadoEmpleado { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenDiagnostico> OrdenDiagnostico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenReparacion> OrdenReparacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenReparacionDetalle> OrdenReparacionDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
