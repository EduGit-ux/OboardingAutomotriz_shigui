using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> CrearCliente(Cliente oCliente);
        Task<Respuesta> ConsultaCliente(int idCliente);
        Task<Respuesta> EditarCliente(Cliente oCliente);
        Task<Respuesta> EliminarCliente(int idCliente);
    }
}
