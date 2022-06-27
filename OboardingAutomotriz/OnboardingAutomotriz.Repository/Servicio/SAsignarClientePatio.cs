using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SAsignarClientePatio : IAsigancionClientePatio
    {
        private readonly BBDDOnboardingContext _context;
        public SAsignarClientePatio(BBDDOnboardingContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarAsignacionClientePatios()
        {
            Respuesta respuesta = new Respuesta();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarAsignacionClientePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            return respuesta;
        }
        public async Task<Respuesta> CrearAsignacionClientePatio(AsignacionCliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ExisteAsignacion(oAsignacioncliente.AsIdCliente);
            if (respuesta.EjecucionRespuesta)
            {
                respuesta.MensajeRespuesta = Mensajes.AsignacionExiste;
                respuesta.RegistroExistente = true;
                return respuesta;
            }
            oAsignacioncliente.AsFechaAsignacion = DateTime.Now.ToString("dd-MM-yyyy");
            _context.AsignacionClientes.Add(oAsignacioncliente);
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.AsignacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EditarAsignacionClientePatio(AsignacionCliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oAsignacioncliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            respuesta.EjecucionRespuesta = true;
            respuesta.ObjetoRespuesta = oAsignacioncliente;
            return respuesta;
        }
        public async Task<Respuesta> EliminarAsignacionClientePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            return respuesta;
        }
        public async Task<Respuesta> ExisteAsignacion(int idAsg)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.AsignacionClientes.AnyAsync(x => x.AsIdCliente == idAsg);
            return respuesta;
        }
    }
}
