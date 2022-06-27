using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnboardingAutomotriz.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using OnboardingAutomotriz.Test.Utils;
using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Repository.Servicio;

namespace OnboardingAutomotriz.Test.ServicesTest
{
    [TestClass]
    public class ClienteTest: BaseTest
    {
        [TestMethod]
        public async Task CrearCliente()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            Cliente oCliente = new Cliente() {
                ClIdentificacion = "0503618464",
                ClNombres = "Jorge Eduardo",
                ClApellidos = "Shigui Guanoluisa",
                ClEdad = "30",
                ClFechaNacimiento = DateTime.Now,
                ClDireccion = "La Napo",
                ClTelefono = "2356456",
                ClEstadoCivil = "SOLTERO",
                ClIdentificacionConyuge = string.Empty,
                ClNombreConyuge = string.Empty,
                ClSujetoCredito = false
            };
            contexto.Clientes.Add(oCliente);
            await contexto.SaveChangesAsync();
            ICliente _iCliente = new SCliente(contexto);
            var respuesta = await _iCliente.CrearCliente (oCliente);
            Assert.IsTrue(respuesta.EjecucionRespuesta, "true");
        }
    }
}
