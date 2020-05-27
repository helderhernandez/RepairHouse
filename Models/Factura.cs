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
    
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            this.FacturaDetalle = new HashSet<FacturaDetalle>();
        }
    
        public int IdFactura { get; set; }
        public int IdSucursal { get; set; }
        public int IdEmpelado { get; set; }
        public int IdCliente { get; set; }
        public Nullable<bool> Anulada { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<decimal> PrecioBruto { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> PrecioNeto { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; }
    }
}