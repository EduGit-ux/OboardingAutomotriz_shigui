using Microsoft.AspNetCore.Mvc;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OboardingAutomotriz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargarDatosController : ControllerBase
    {
        private readonly ICargarDatos _servicio;
        public CargarDatosController(ICargarDatos iServicio)
        {
            _servicio = iServicio;
        }

        /// <summary>
        /// Método para cargar datos iniciales
        /// Cliente
        /// Ejecutivo
        /// Marca
        /// </summary>
        /// <param name="strTipoDoc">Tipo Documento</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CargarDatosIniciales/{strTipoDoc}")]
        public async Task<Respuesta> CargarDarosIniciales(string strTipoDoc)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await _servicio.CargarDatosIniciales(strTipoDoc);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = ex.ToString();
            }
            return respuesta;
        }
    }
}
