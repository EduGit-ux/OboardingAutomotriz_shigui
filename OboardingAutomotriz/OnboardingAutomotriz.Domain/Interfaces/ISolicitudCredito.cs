using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<Respuesta> ConsultaSolicitud(int idConsulta);
        Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito);
        Task<Respuesta> ExisteSolicitudFecha(int idCliente, int idPatio);
        Task<string> ValidarEstado(int IdCliente, int idPatio);
        Task<bool> ValidarVehiculo(int idVehiculo);
    }
}
