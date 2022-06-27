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
    public class MarcasController : ControllerBase
    {
        private readonly IMarca _service;

        public MarcasController(IMarca service)
        {
            _service = service;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<Respuesta> GetMarcas()
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

        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.ConsultarMarca(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutMarca(int id, Marca marca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != marca.MaIdMarca)
                {
                    respuesta.MensajeRespuesta = Mensajes.ErrorModificar;
                    respuesta.EjecucionRespuesta = false;
                    return respuesta;
                }
                respuesta = await _service.EditarMarca(marca);

            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/Marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostMarca(Marca marca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.CrearMarca(marca);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _service.EliminarMarca(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
