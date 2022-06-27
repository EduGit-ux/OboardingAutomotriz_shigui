using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int VeId { get; set; }
        public string VePlaca { get; set; }
        public string VeModelo { get; set; }
        public int VeMarcaId { get; set; }
        public string VeTipo { get; set; }
        public string VeCilindraje { get; set; }
        public string VeAvaluo { get; set; }

        public virtual Marca VeMarca { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
