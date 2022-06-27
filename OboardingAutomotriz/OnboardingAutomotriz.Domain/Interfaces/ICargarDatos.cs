
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface ICargarDatos
    {
        Task<Respuesta> CargarDatosIniciales(string strTipoDocumento);
    }
}
