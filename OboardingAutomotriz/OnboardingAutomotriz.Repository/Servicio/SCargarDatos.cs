using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OboardingAutomotriz.Entities.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Entities.Utilitarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Repository.Servicio
{
    public class SCargarDatos : ICargarDatos
    {
        private readonly IConfiguration _configuration;
        private readonly BBDDOnboardingContext _context;
        public SCargarDatos(BBDDOnboardingContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<Respuesta> CargarDatosIniciales(string strTipoDocumento)
        {
            string strDocumento = string.Empty;
            Respuesta respuesta = new Respuesta();
            switch (strTipoDocumento)
            {
                case Utils.docClientes:
                    strDocumento = _configuration["RutasFile:Clientes"];
                    break;
                case Utils.docEjecutivos:
                    strDocumento = _configuration["RutasFile:Ejecutivo"];
                    break;
                case Utils.docMarcas:
                    strDocumento = _configuration["RutasFile:Marcas"];
                    break;
            }
            respuesta = await ProcesarCarga(strDocumento, strTipoDocumento);           
            return respuesta;
        }
        public async Task<Respuesta> ProcesarCarga(string strDocumento, string strTipoDocumento)
        {
            List<Cliente> lstCliente = new List<Cliente>();
            List<Ejecutivo> lstEjecutivo = new List<Ejecutivo>();
            List<Marca> lstMarca = new List<Marca>();
            Respuesta respuesta = new Respuesta();
            StreamReader StrArchivo = new StreamReader(strDocumento);
            string lineaDatos;
            int index = 0;
            while ((lineaDatos = StrArchivo.ReadLine()) != null)
            {
                index++;
                string[] fila = lineaDatos.Split(Utils.Separador);
                switch (strTipoDocumento)
                {
                    case Utils.docClientes:
                        Cliente oCliente = new Cliente()
                        {
                            ClIdentificacion = fila[0],
                            ClNombres = fila[1],
                            ClEdad = fila[2],
                            ClFechaNacimiento = Convert.ToDateTime(fila[3]),
                            ClApellidos = fila[4],
                            ClDireccion = fila[5],
                            ClTelefono = fila[6],
                            ClEstadoCivil = fila[7],
                            ClIdentificacionConyuge = fila[8],
                            ClNombreConyuge = fila[9],
                            ClSujetoCredito = Convert.ToBoolean(Convert.ToInt32(fila[10]))
                        };
                        lstCliente.Add(oCliente);
                        break;
                    case Utils.docEjecutivos:
                        Ejecutivo oEjecutivos = new Ejecutivo() { 
                            EjIdPatio = Convert.ToInt32(fila[0]),
                            EjIdentificacion = fila[1],
                            EjNombre = fila[2],
                            EjApellido = fila[3],
                            EjDireccion = fila[4],
                            EjTelefono = fila[5],
                            EjCelular = fila[6],
                            EjEdad = fila[7]
                        };
                        lstEjecutivo.Add(oEjecutivos);
                        break;
                    case Utils.docMarcas:
                        Marca oMarcas = new Marca() { 
                            MaMarcaAuto = fila[0]
                        };
                        lstMarca.Add(oMarcas);
                        break;
                    default:
                        break;
                }
            }
            switch (strTipoDocumento)
            {
                case Utils.docClientes:
                    respuesta = await GuardaClientes(lstCliente);
                    break;
                case Utils.docEjecutivos:
                    respuesta = await GuardarEjecutivos(lstEjecutivo);
                    break;
                case Utils.docMarcas:
                    respuesta = await GuardarMarcas(lstMarca);
                    break;
                default:
                    break;
            }
            return respuesta;
        }
        public async Task<Respuesta> GuardaClientes(List<Cliente> lstCliente) 
        {
            Respuesta respuesta = new Respuesta();
            List<Cliente> oClientesExistentes = new List<Cliente>();
            List<Cliente> oClienteFinal = new List<Cliente>(lstCliente);
            foreach (Cliente item in lstCliente)
            {
                respuesta = await ExisteCliente(item.ClIdentificacion);
                if (respuesta.RegistroExistente)
                {
                    oClienteFinal.Remove(item);
                    oClientesExistentes.Add(item);
                }
            }
            if (oClienteFinal.Count > 0)
            {
                _context.Clientes.AddRange(oClienteFinal);
                await _context.SaveChangesAsync();
                respuesta.MensajeRespuesta = oClienteFinal.Count + Mensajes.ClienteCorrecto;
            }
            if (oClientesExistentes.Count > 0)
            {
                respuesta.MensajeRespuesta = Mensajes.ClienteExiste;
                respuesta.ObjetoRespuesta = oClientesExistentes;
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;

        }
        public async Task<Respuesta> ExisteCliente(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.RegistroExistente = await _context.Clientes.AnyAsync(x => x.ClIdentificacion == Identificacion);
            return respuesta;
        }
        public async Task<Respuesta> GuardarMarcas(List<Marca> lstMarca)
        {
            Respuesta respuesta = new Respuesta();
            List<Marca> oMarcaFinal = new List<Marca>(lstMarca);
            List<Marca> oMarcaExiste = new List<Marca>();
            foreach (Marca item in lstMarca)
            {
                respuesta = await ConsultaMarca(item.MaMarcaAuto);
                if (respuesta.EjecucionRespuesta)
                {
                    oMarcaFinal.Remove(item);
                    oMarcaExiste.Add(item);
                }
            }
            if (oMarcaFinal.Count > 0)
            {
                _context.Marcas.AddRange(oMarcaFinal);
                await _context.SaveChangesAsync();
                respuesta.MensajeRespuesta = oMarcaFinal.Count + Mensajes.MarcasOk;
            }
            if (oMarcaExiste.Count > 0)
            {
                respuesta.ObjetoRespuesta = oMarcaExiste;
                respuesta.MensajeRespuesta = Mensajes.MarcasExiste;
            }            
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultaMarca(string strMarca)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Marcas.AnyAsync(x => x.MaMarcaAuto == strMarca);
            return respuesta;
        }
        public async Task<Respuesta> GuardarEjecutivos(List<Ejecutivo> lstEjecutivo) 
        {
            Respuesta respuesta = new Respuesta();
            List<Ejecutivo> oEjecutivoFinal = new List<Ejecutivo>(lstEjecutivo);
            List<Ejecutivo> oEjecutivoExiste = new List<Ejecutivo>();
            foreach (Ejecutivo item in lstEjecutivo)
            {
                respuesta = await ConsultarEjecutivo(item.EjIdentificacion);
                if (respuesta.EjecucionRespuesta)
                {
                    oEjecutivoFinal.Remove(item);
                    oEjecutivoExiste.Add(item);
                }
            }
            if (oEjecutivoFinal.Count > 0)
            {
                _context.Ejecutivos.AddRange(oEjecutivoFinal);
                await _context.SaveChangesAsync();
                respuesta.MensajeRespuesta = oEjecutivoFinal.Count + Mensajes.EjecutivosOK;
            }
            if (oEjecutivoExiste.Count > 0)
            {
                respuesta.ObjetoRespuesta = oEjecutivoExiste;
                respuesta.MensajeRespuesta = Mensajes.EjecutivosExisten;
                respuesta.RegistroExistente = true;
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultarEjecutivo(string stridentificacion)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.EjecucionRespuesta = await _context.Ejecutivos.AnyAsync(x => x.EjIdentificacion == stridentificacion);
            return respuesta;
        }
    }
}
