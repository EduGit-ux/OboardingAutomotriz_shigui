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
    public class VehiculoesController : ControllerBase
    {
        private readonly IVehiculo _service;

        public VehiculoesController(IVehiculo service)
        {
            _service = service;
        }

        // GET: api/Vehiculoes
        [HttpGet]
        public async Task<Respuesta> GetVehiculos()
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

        // GET: api/Vehiculoes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetVehiculo(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.ConsultarVehiculo(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/Vehiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutVehiculo(int id, Vehiculo vehiculo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != vehiculo.VeId) {
                    respuesta.MensajeRespuesta = Mensajes.ErrorModificar;
                    respuesta.EjecucionRespuesta = false;
                    return respuesta;
                }
                respuesta = await _service.EditaVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/Vehiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostVehiculo(Vehiculo vehiculo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.CrearVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/Vehiculoes/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteVehiculo(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.EliminarVehiculo(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
