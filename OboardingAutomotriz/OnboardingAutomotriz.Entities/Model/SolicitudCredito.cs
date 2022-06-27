using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class SolicitudCredito
    {
        public int ScId { get; set; }
        public int ScIdCliente { get; set; }
        public int ScIdPatio { get; set; }
        public int ScIdVehiculo { get; set; }
        public int ScMesesPlazo { get; set; }
        public int ScCuotas { get; set; }
        public decimal ScEntrada { get; set; }
        public int ScIdEjecutivo { get; set; }
        public string ScObservacion { get; set; }
        public string ScEstado { get; set; }

        public virtual Cliente ScIdClienteNavigation { get; set; }
        public virtual Ejecutivo ScIdEjecutivoNavigation { get; set; }
        public virtual Patio ScIdPatioNavigation { get; set; }
        public virtual Vehiculo ScIdVehiculoNavigation { get; set; }
    }
}
