//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoApi_KN.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            this.ERRORES = new HashSet<ERRORES>();
        }
    
        public long ConsecutivoUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public Nullable<byte> CodProvincia { get; set; }
        public string Rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ERRORES> ERRORES { get; set; }
        public virtual PROVINCIAS PROVINCIAS { get; set; }
    }
}