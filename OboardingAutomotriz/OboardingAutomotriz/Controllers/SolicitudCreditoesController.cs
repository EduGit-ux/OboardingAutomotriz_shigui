using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;

namespace OboardingAutomotriz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudCreditoesController : ControllerBase
    {
        private readonly ISolicitudCredito _service;

        public SolicitudCreditoesController(ISolicitudCredito servicio)
        {
            _service = servicio;
        }

        // GET: api/SolicitudCreditoes
        [HttpGet]
        public async Task<Respuesta> GetSolicitudCreditos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {

            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // GET: api/SolicitudCreditoes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.ConsultaSolicitud(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/SolicitudCreditoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutSolicitudCredito(int id, SolicitudCredito solicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            try
            {

            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/SolicitudCreditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostSolicitudCredito(SolicitudCredito solicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.CrearSolicitudCredito(solicitudCredito);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/SolicitudCreditoes/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {

            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }       
    }
}
