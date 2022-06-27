using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System.Threading.Tasks;


namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SPatio : IPatio
    {
        private readonly BBDDOnboardingContext _context;
        public SPatio(BBDDOnboardingContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> CrearPatioAuto(Patio oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultaPatio(oPatioAuto.PaNombre);
            if (respuesta.EjecucionRespuesta)
            {
                respuesta.MensajeRespuesta = Mensajes.PatioExiste;
                respuesta.ObjetoRespuesta = oPatioAuto;
                respuesta.EjecucionRespuesta = true;
                respuesta.RegistroExistente = true;
                return respuesta;
            }
            _context.Patios.Add(oPatioAuto);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.PatioOk;
            respuesta.EjecucionRespuesta = true;            
            return respuesta;
        }
        public async Task<Respuesta> ConsultarPatioAutos()
        {
            Respuesta respuesta = new Respuesta();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Patios.FindAsync(id);
            return respuesta;
        }
        public async Task<Respuesta> EditarPatioAuto(Patio oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oPatioAuto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EliminarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            var oPatio = await _context.Patios.FindAsync(id);
            if (oPatio == null)
            {
                respuesta.MensajeRespuesta = Mensajes.ErrorEliminar;
                respuesta.ObjetoRespuesta = oPatio;
                return respuesta;
            }
            _context.Patios.Remove(oPatio);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.EliminarOk;
            respuesta.ObjetoRespuesta = oPatio;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultaPatio(string strPatio)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Patios.AnyAsync(x => x.PaNombre == strPatio);
            return respuesta;
        }
    }
}
