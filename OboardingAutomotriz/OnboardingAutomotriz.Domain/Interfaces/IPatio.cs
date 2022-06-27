using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface IPatio
    {
        Task<Respuesta> ConsultarPatioAutos();
        Task<Respuesta> ConsultarPatioAuto(int id);
        Task<Respuesta> CrearPatioAuto(Patio oPatioAuto);
        Task<Respuesta> EditarPatioAuto(Patio oPatioAuto);
        Task<Respuesta> EliminarPatioAuto(int id);
    }
}
