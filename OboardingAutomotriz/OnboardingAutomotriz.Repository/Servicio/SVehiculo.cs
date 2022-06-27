using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SVehiculo : IVehiculo
    {
        private readonly BBDDOnboardingContext _context;
        public SVehiculo(BBDDOnboardingContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> CrearVehiculo(Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            if (respuesta.EjecucionRespuesta)
            {
                respuesta.MensajeRespuesta = Mensajes.VehiculoError + oVehiculo.VeId;
                respuesta.EjecucionRespuesta = false;
                return respuesta;
            }
            _context.Add(oVehiculo);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.VehiculoOk;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ExisteVehiculo(int inId)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Vehiculos.AnyAsync(x => x.VeId == inId);
            return respuesta;
        }
        public async Task<Respuesta> ConsultarVehiculo(int idVe)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Vehiculos.FindAsync(idVe);
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> EditaVehiculo(Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oVehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EliminarVehiculo(int idVe)
        {
            Respuesta respuesta = new Respuesta();
            var oVehiculo = await _context.Vehiculos.FindAsync(idVe);
            if (oVehiculo == null)
            {
                respuesta.EjecucionRespuesta = false;
                respuesta.MensajeRespuesta = Mensajes.ErrorEliminar;
                return respuesta;
            }
            _context.Vehiculos.Remove(oVehiculo);
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.EliminarOk;
            return respuesta;
        }
    }
}
