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
    public class PatiosController : ControllerBase
    {
        private readonly IPatio _servicio;

        public PatiosController(IPatio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Patios
        [HttpGet]
        public async Task<Respuesta> GetPatios()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.ConsultarPatioAutos();
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // GET: api/Patios/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetPatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.ConsultarPatioAuto(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;

        }

        // PUT: api/Patios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutPatio(int id, Patio patio)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != patio.PaId)
                {
                    respuesta.MensajeRespuesta = Mensajes.ErrorModificar;
                    respuesta.EjecucionRespuesta = false;
                    return respuesta;
                }
                respuesta = await _servicio.EditarPatioAuto(patio);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/Patios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("patio")]
        public async Task<Respuesta> PostPatio(Patio patio)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.CrearPatioAuto(patio);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/Patios/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeletePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.EliminarPatioAuto(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
