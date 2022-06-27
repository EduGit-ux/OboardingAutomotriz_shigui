using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SMarca : IMarca
    {
        public readonly BBDDOnboardingContext _context;
        public SMarca(BBDDOnboardingContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> CrearMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarMarca(oMarca.MaMarcaAuto);
            if (respuesta.EjecucionRespuesta)
            {
                respuesta.RegistroExistente = true;
                respuesta.MensajeRespuesta = Mensajes.MarcasExiste;
                return respuesta;
            }
            _context.Marcas.Add(oMarca);
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.MarcasOk;
            return respuesta;
        }
        public async Task<Respuesta> ConsultarMarca(string Marca)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Marcas.AnyAsync(x => x.MaMarcaAuto == Marca);
            return respuesta;
        }
        public async Task<Respuesta> EditarMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oMarca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EliminarMarca(int idMarca)
        {
            Respuesta respuesta = new Respuesta();
            var oMarca = await _context.Marcas.FindAsync(idMarca);
            if (oMarca == null)
            {
                respuesta.MensajeRespuesta = Mensajes.ErrorEliminar;
                respuesta.ObjetoRespuesta = oMarca;
                return respuesta;
            }
            _context.Marcas.Remove(oMarca);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.EliminarOk;
            respuesta.ObjetoRespuesta = oMarca;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultarMarca(int idMarca)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Marcas.FindAsync(idMarca);
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
    }
}
