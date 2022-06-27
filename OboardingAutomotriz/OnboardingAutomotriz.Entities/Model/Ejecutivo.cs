using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class Ejecutivo
    {
        public Ejecutivo()
        {
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int EjId { get; set; }
        public int EjIdPatio { get; set; }
        public string EjIdentificacion { get; set; }
        public string EjNombre { get; set; }
        public string EjApellido { get; set; }
        public string EjDireccion { get; set; }
        public string EjTelefono { get; set; }
        public string EjCelular { get; set; }
        public string EjEdad { get; set; }

        public virtual Patio EjIdPatioNavigation { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
