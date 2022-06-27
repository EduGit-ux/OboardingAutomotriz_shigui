using System;
using System.Collections.Generic;

#nullable disable

namespace OboardingAutomotriz.Entities.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int MaIdMarca { get; set; }
        public string MaMarcaAuto { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
