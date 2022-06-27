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
    public class SSolicitudCredito : ISolicitudCredito
    {
        private readonly BBDDOnboardingContext _context;
        public SSolicitudCredito(BBDDOnboardingContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ExisteSolicitudFecha(oSolicitudCredito.ScIdCliente, oSolicitudCredito.ScIdPatio);
            string Estado = await ValidarEstado(oSolicitudCredito.ScIdCliente, oSolicitudCredito.ScIdPatio);
            if (respuesta.EjecucionRespuesta && Estado.Equals(Mensajes.Activo))
            {
                respuesta.MensajeRespuesta = Mensajes.ExisteSolicirud + DateTime.Now.Date + " en estado " + Estado;
                respuesta.EjecucionRespuesta = true;
                return respuesta;
            }
            bool VehiculoActivo = await ValidarVehiculo(oSolicitudCredito.ScIdVehiculo);
            if (VehiculoActivo)
            {
                respuesta.MensajeRespuesta = Mensajes.VehiculoReservado;
                respuesta.EjecucionRespuesta = true;
                return respuesta;
            }
            // Asignar Solcitud credito
            _context.SolicitudCreditos.Add(oSolicitudCredito);
            // Asignar Cliente Patio
            AsignacionCliente OClientePatio = new AsignacionCliente() { 
                AsIdCliente = oSolicitudCredito.ScIdCliente,
                AsIdPatio = oSolicitudCredito.ScIdPatio,
                AsFechaAsignacion = DateTime.Now.ToString("dd-MM-yyyy")
            };
            _context.AsignacionClientes.Add(OClientePatio);
            await _context.SaveChangesAsync();
            respuesta.EjecucionRespuesta = true;
            respuesta.MensajeRespuesta = Mensajes.SolicitudCreadoOk;
            return respuesta;
        }
        public async Task<Respuesta> ExisteSolicitudFecha(int idCliente, int idPatio)
        {
            Respuesta respuesta = new Respuesta();
            if (await _context.SolicitudCreditos.AnyAsync(x => x.ScIdCliente == idCliente))
            {
                AsignacionCliente LstAsignacionCliente = new AsignacionCliente();
                LstAsignacionCliente = await _context.AsignacionClientes.Where(x => x.AsIdCliente == idCliente).OrderByDescending(x => x.AsFechaAsignacion).FirstOrDefaultAsync();
                if (LstAsignacionCliente != null)
                {
                    if (DateTime.Compare(Convert.ToDateTime(LstAsignacionCliente.AsFechaAsignacion), DateTime.Now.Date) == 0)
                        respuesta.EjecucionRespuesta = true;
                }
            }
            return respuesta;
        }
        public async Task<string> ValidarEstado(int IdCliente, int idPatio)
        {
            SolicitudCredito oValidarSolicitud = new SolicitudCredito();
            oValidarSolicitud = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdCliente == IdCliente
            && x.ScIdPatio == idPatio);
            if (oValidarSolicitud != null && !string.IsNullOrEmpty(oValidarSolicitud.ScEstado))
                return oValidarSolicitud.ScEstado;

            return string.Empty;
        }
        public async Task<bool> ValidarVehiculo(int idVehiculo)
        {
            SolicitudCredito oValidarVehiculo = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdVehiculo == idVehiculo
            && x.ScEstado.Equals(Mensajes.Activo));
            if (oValidarVehiculo != null)
                return true;
            return false;
        }
        public async Task<Respuesta> ConsultaSolicitud(int idSolicitud)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScId == idSolicitud);
            if (respuesta.ObjetoRespuesta == null)
                respuesta.MensajeRespuesta = Mensajes.RegistroNoExiste;
            return respuesta;
        }
    }
}
