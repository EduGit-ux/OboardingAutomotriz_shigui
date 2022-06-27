
using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SCliente : ICliente
    {
        private readonly BBDDOnboardingContext _context;
        public SCliente(BBDDOnboardingContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Clientes.FirstOrDefaultAsync(x => x.ClIdentificacion == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearCliente(Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarCliente(oCliente.ClIdentificacion);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = Mensajes.ClienteExiste;
                respuesta.ObjetoRespuesta = oCliente;
            }
            else
            {
                _context.Clientes.Add(oCliente);
                respuesta.MensajeRespuesta = Mensajes.ClienteCorrecto;
                respuesta.ObjetoRespuesta = oCliente;
                await _context.SaveChangesAsync();

            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultaCliente(int idCliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Clientes.FindAsync(idCliente);
            return respuesta;
        }
        public async Task<Respuesta> EditarCliente(Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oCliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EliminarCliente(int idCliente)
        {
            Respuesta respuesta = new Respuesta();
            var oCliente = await _context.Clientes.FindAsync(idCliente);
            if (oCliente == null)
            {
                respuesta.EjecucionRespuesta = false;
                respuesta.MensajeRespuesta = Mensajes.ErrorEliminar;
                return respuesta;
            }
            _context.Clientes.Remove(oCliente);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.EliminarOk;
            respuesta.ObjetoRespuesta = oCliente;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }        
    }
}
