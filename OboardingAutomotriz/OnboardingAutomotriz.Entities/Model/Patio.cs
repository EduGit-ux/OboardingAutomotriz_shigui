using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class Patio
    {
        public Patio()
        {
            AsignacionClientes = new HashSet<AsignacionCliente>();
            Ejecutivos = new HashSet<Ejecutivo>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int PaId { get; set; }
        public string PaNombre { get; set; }
        public string PaDireccion { get; set; }
        public string PaTelefono { get; set; }

        public virtual ICollection<AsignacionCliente> AsignacionClientes { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
