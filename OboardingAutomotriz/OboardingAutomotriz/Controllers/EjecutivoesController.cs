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
    public class EjecutivoesController : ControllerBase
    {
        private readonly IEjecutivo _service;
        public EjecutivoesController(IEjecutivo servicio)
        {
            _service = servicio;
        }

        // GET: api/Ejecutivoes
        [HttpGet]
        public async Task<Respuesta> GetEjecutivos()
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

        // GET: api/Ejecutivoes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetEjecutivo(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.ConsultaEjecutivo(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/Ejecutivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutEjecutivo(int id, Ejecutivo ejecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != ejecutivo.EjId)
                {
                    respuesta.EjecucionRespuesta = false;
                    respuesta.MensajeRespuesta = Mensajes.ErrorModificar;
                    return respuesta;
                }
                respuesta = await _service.EditarEjcutivo(ejecutivo);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/Ejecutivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostEjecutivo(Ejecutivo ejecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.CrearEjecutivo(ejecutivo);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/Ejecutivoes/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteEjecutivo(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.EliminarEjecutivo(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
