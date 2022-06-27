using Microsoft.VisualStudio.TestTools.UnitTesting;
using OboardingAutomotriz.Entities.Models;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Repository.Servicio;
using OnboardingAutomotriz.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Test.ServicesTest
{
    [TestClass]
    public class GenerarSolicitudCreditoTest  : BaseTest
    {
        SolicitudCredito oSolicitudCredito = new SolicitudCredito()
        {
            ScIdCliente = 7,
            ScIdPatio = 2,
            ScIdVehiculo = 10,
            ScMesesPlazo = 10,
            ScCuotas = 10,
            ScEntrada = 100,
            ScIdEjecutivo = 10,
            ScObservacion = "Observaciones",
            ScEstado = "R"
        };
        [TestMethod]
        public async Task GenerarSolicitudCredito()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            
            contexto.Add(oSolicitudCredito);
            var resp =  await contexto.SaveChangesAsync();
            Assert.AreEqual(1, resp);
        }
        [TestMethod]
        public async Task ValidarSolicitudFecha()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ExisteSolicitudFecha(oSolicitudCredito.ScIdCliente, oSolicitudCredito.ScIdPatio);
            Assert.IsFalse(respuesta.EjecucionRespuesta,"false");
        }
        [TestMethod]
        public async Task ValidaEstado()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            oSolicitudCredito.ScId = 4;
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ValidarEstado(oSolicitudCredito.ScIdCliente, oSolicitudCredito.ScIdPatio);
            Assert.AreNotEqual(respuesta, "A");
        }
        [TestMethod]
        public async Task ValidarVehiculo()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ValidarVehiculo(oSolicitudCredito.ScIdVehiculo);
            Assert.IsFalse(respuesta, "false");

        }
    }
}
