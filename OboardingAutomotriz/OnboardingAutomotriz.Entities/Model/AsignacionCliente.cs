using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class AsignacionCliente
    {
        public int AsId { get; set; }
        public int AsIdCliente { get; set; }
        public int AsIdPatio { get; set; }
        public string AsFechaAsignacion { get; set; }

        public virtual Cliente AsIdClienteNavigation { get; set; }
        public virtual Patio AsIdPatioNavigation { get; set; }
    }
}
