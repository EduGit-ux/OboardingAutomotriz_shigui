using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            AsignacionClientes = new HashSet<AsignacionCliente>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int ClIdCliente { get; set; }
        public string ClIdentificacion { get; set; }
        public string ClNombres { get; set; }
        public string ClApellidos { get; set; }
        public string ClEdad { get; set; }
        public DateTime ClFechaNacimiento { get; set; }
        public string ClDireccion { get; set; }
        public string ClTelefono { get; set; }
        public string ClEstadoCivil { get; set; }
        public string ClIdentificacionConyuge { get; set; }
        public string ClNombreConyuge { get; set; }
        public bool ClSujetoCredito { get; set; }

        public virtual ICollection<AsignacionCliente> AsignacionClientes { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
