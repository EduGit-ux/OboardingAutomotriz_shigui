using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface IMarca
    {
        Task<Respuesta> CrearMarca(Marca oMarca);
        Task<Respuesta> EditarMarca(Marca oMarca);
        Task<Respuesta> EliminarMarca(int idMarca);
        Task<Respuesta> ConsultarMarca(int idMarca);
    }
}
