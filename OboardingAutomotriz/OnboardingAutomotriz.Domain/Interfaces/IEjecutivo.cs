using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo);
        Task<Respuesta> ConsultaEjecutivo(int idEj);
        Task<Respuesta> EditarEjcutivo(Ejecutivo oEjecutivo);
        Task<Respuesta> EliminarEjecutivo(int idEj);
    }
}
