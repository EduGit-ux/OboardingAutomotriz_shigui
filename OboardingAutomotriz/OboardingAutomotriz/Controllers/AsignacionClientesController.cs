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
    public class AsignacionClientesController : ControllerBase
    {
        private readonly IAsigancionClientePatio _servicio;

        public AsignacionClientesController(IAsigancionClientePatio servicio)
        {
            _servicio = servicio;
        }

        // GET: api/AsignacionClientes
        [HttpGet]
        public async Task<Respuesta> GetAsignacionClientes()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.ConsultarAsignacionClientePatios();
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // GET: api/AsignacionClientes/5
        [HttpGet("{id}")]
        public async Task<Respuesta> GetAsignacionCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.ConsultarAsignacionClientePatio(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // PUT: api/AsignacionClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Respuesta> PutAsignacionCliente(int id, AsignacionCliente asignacionCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id == asignacionCliente.AsId)
                    respuesta = await _servicio.EditarAsignacionClientePatio(asignacionCliente);
                else
                    respuesta.MensajeRespuesta = Mensajes.ErrorModificar + " " + id;
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // POST: api/AsignacionClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Respuesta> PostAsignacionCliente(AsignacionCliente asignacionCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.CrearAsignacionClientePatio(asignacionCliente);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }

        // DELETE: api/AsignacionClientes/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> DeleteAsignacionCliente(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.EliminarAsignacionClientePatio(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
