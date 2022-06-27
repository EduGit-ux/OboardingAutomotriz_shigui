using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface IVehiculo
    {
        Task<Respuesta> CrearVehiculo(Vehiculo oVehiculo);
        Task<Respuesta> ConsultarVehiculo(int idVehiculo);
        Task<Respuesta> EditaVehiculo(Vehiculo oVehiculo);
        Task<Respuesta> EliminarVehiculo(int idVehiculo);

    }
}
