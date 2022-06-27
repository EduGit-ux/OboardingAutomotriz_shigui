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
    public class AsignarClientePatioTest : BaseTest
    {
        [TestMethod]
        public async Task AsignarCliente()
        {
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            AsignacionCliente oAsignacion = new AsignacionCliente()
            {
                AsIdCliente = 5,
                AsIdPatio = 2,
                AsFechaAsignacion = DateTime.Now.ToString("dd-MM-yyyy")
            };
            contexto.Add(oAsignacion);
            await contexto.SaveChangesAsync();

            //Validación prueba
            IAsigancionClientePatio _servicio = new SAsignarClientePatio(contexto);
            var respuesta = await _servicio.CrearAsignacionClientePatio(oAsignacion);            
            Assert.IsTrue(respuesta.EjecucionRespuesta, "true");
        }
    }
}
