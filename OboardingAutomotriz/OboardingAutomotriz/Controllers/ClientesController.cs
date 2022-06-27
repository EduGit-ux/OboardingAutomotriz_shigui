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
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _servicio;

        public ClientesController(ICliente servicio)
        {
            _servicio = servicio;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<Respuesta> GetClientes()
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

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.ConsultaCliente(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutCliente(int id, Cliente cliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.EditarCliente(cliente);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.CrearCliente(cliente);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.EliminarCliente(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
