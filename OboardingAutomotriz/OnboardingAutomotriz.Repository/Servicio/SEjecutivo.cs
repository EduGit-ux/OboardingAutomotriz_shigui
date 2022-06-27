using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SEjecutivo : IEjecutivo
    {
        private readonly BBDDOnboardingContext _context;
        public SEjecutivo(BBDDOnboardingContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ExisteEjecutivo(oEjecutivo.EjIdentificacion);
            if (respuesta.EjecucionRespuesta)
            {
                respuesta.MensajeRespuesta = Mensajes.EjecutivosExisten;
                respuesta.EjecucionRespuesta = true;
                return respuesta;
            }
            _context.Ejecutivos.Add(oEjecutivo);
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.EjecutivosOK;
            return respuesta;
        }
        public async Task<Respuesta> ExisteEjecutivo(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Ejecutivos.AnyAsync(x => x.EjIdentificacion == Identificacion);
            return respuesta;
        }
        public async Task<Respuesta> ConsultaEjecutivo(int idEj)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Ejecutivos.FindAsync(idEj);
            return respuesta;
        }
        public async Task<Respuesta> EditarEjcutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oEjecutivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.ModificacionOK;
            return respuesta;
        }
        public async Task<Respuesta> EliminarEjecutivo(int idEj)
        {
            Respuesta respuesta = new Respuesta();
            var oEjcutivo = await _context.Ejecutivos.FindAsync(idEj);
            if (oEjcutivo == null)
            {
                respuesta.EjecucionRespuesta = false;
                respuesta.MensajeRespuesta = Mensajes.ErrorEliminar;
                return respuesta;
            }
            _context.Ejecutivos.Remove(oEjcutivo);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.EliminarOk;
            respuesta.ObjetoRespuesta = oEjcutivo;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

    }
}
