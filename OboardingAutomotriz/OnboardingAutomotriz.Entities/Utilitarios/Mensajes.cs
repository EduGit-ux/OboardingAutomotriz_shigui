using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingAutomotriz.Entities.Utilitarios
{
    public class Mensajes
    {
        public const string ErrorModificar = "No se puede modifica";
        public const string ModificacionOK = "Registro modificado";
        public const string ErrorEliminar = "No se puede elimiar";
        public const string EliminarOk = "Registro eliminado";
        public const string ClienteCorrecto = " Cliente Creado Correctamente";
        public const string ClienteExiste = "Cliente ya existen";
        public const string MarcasOk = " Marca creado correctamente";
        public const string MarcasExiste = " Marca ya existen";
        public const string EjecutivosOK = " Ejecutivo Creado Correctamente";
        public const string EjecutivosExisten = " Ejecutivo ya existen";
        
        public const string PatioOk = "Patio creado exitosamente";
        public const string PatioExiste = "Ya existe el patio con este nombre";

        public const string AsignacionOK = "Cliente asignado correctamente.";
        public const string AsignacionExiste = "Cliente ya tiene asignación.";

        public const string VehiculoOk = "Vehiculo registrado exitosamente";
        public const string VehiculoError = "Ya existe vehiculo con id: ";

        public const string ExisteSolicirud = "Ya existe una soliciud ingresada con fecha ";
        public const string VehiculoReservado = "El vehiculo se encuentra en reserva.";
        public const string Activo = "A";
        public const string SolicitudCreadoOk = "Solicitud creada exitosamente";
        public const string RegistroNoExiste = "No existe registro.";
    }
}

