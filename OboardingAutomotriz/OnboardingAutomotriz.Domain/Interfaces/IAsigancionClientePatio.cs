using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface IAsigancionClientePatio
    {
        Task<Respuesta> ConsultarAsignacionClientePatios();
        Task<Respuesta> ConsultarAsignacionClientePatio(int id);
        Task<Respuesta> CrearAsignacionClientePatio(AsignacionCliente oAsignacioncliente);
        Task<Respuesta> EditarAsignacionClientePatio(AsignacionCliente oAsignacioncliente);
        Task<Respuesta> EliminarAsignacionClientePatio(int id);
    }
}
