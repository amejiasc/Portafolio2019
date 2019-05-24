using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Hosteria.Clases;
using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioReserva" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioReserva.svc o ServicioReserva.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioReserva : IServicioReserva
    {
        Store.ServicioReserva servicioReserva;
        public ServicioReserva()
        {
            servicioReserva = new Store.ServicioReserva();
        }

        public RespuestaReservaPasajeros ListarPasajeros(int idReserva)
        {
            RespuestaReservaPasajeros respuesta = new RespuestaReservaPasajeros();

            List<Pasajero> pasajeros = servicioReserva.ListarPasajeros(idReserva);

            if (pasajeros == null)
            {
                return new RespuestaReservaPasajeros() { Datos = new List<Pasajero>(), Exito = false, MotivoNoExito = MotivoNoReservaPasajeros.ErrorNoControlado };
            }
            if (pasajeros.Count == 0)
            {
                return new RespuestaReservaPasajeros() { Datos = new List<Pasajero>(), Exito = false, MotivoNoExito = MotivoNoReservaPasajeros.SinDatos };
            }

            respuesta.Exito = true;
            respuesta.MotivoNoExito = MotivoNoReservaPasajeros.Exito;
            respuesta.Datos = pasajeros;

            return respuesta;
        }

        public RespuestaReservaHabitaciones ListarHabitaciones(int idReserva)
        {
            RespuestaReservaHabitaciones respuesta = new RespuestaReservaHabitaciones();

            List<Habitacion> habitaciones = servicioReserva.ListarHabitaciones(idReserva);

            if (habitaciones == null)
            {
                return new RespuestaReservaHabitaciones() { Datos = new List<Habitacion>(), Exito = false, MotivoNoExito = MotivoNoReservaHabitacion.ErrorNoControlado };
            }
            if (habitaciones.Count == 0)
            {
                return new RespuestaReservaHabitaciones() { Datos = new List<Habitacion>(), Exito = false, MotivoNoExito = MotivoNoReservaHabitacion.SinDatos };
            }

            respuesta.Exito = true;
            respuesta.MotivoNoExito = MotivoNoReservaHabitacion.Exito;
            respuesta.Datos = habitaciones;

            return respuesta;
        }

        public RespuestaReservaListar ListarReserva(EntradaReservaListar entradaListaReservas)
        {
            RespuestaReservaListar respuestaReservaListar = new RespuestaReservaListar();

            List<Reserva> reservas = servicioReserva.ListarReserva(entradaListaReservas.IdReserva, 
                                                                   !string.IsNullOrEmpty(entradaListaReservas.RutEmpresa) ? entradaListaReservas.RutEmpresa: "-1",
                                                                   !string.IsNullOrEmpty(entradaListaReservas.RutPasajero) ? entradaListaReservas.RutPasajero: "-1",
                                                                   !string.IsNullOrEmpty(entradaListaReservas.NombreEmpresa) ? entradaListaReservas.NombreEmpresa: "-1", 
                                                                   entradaListaReservas.FechaDesde.Equals(DateTime.MinValue) ? DateTime.Parse("1900-01-01") : entradaListaReservas.FechaDesde,
                                                                   entradaListaReservas.FechaHasta.Equals(DateTime.MinValue) ? DateTime.Parse("2100-12-31") : entradaListaReservas.FechaHasta,
                                                                   entradaListaReservas.EstadoReserva,
                                                                   entradaListaReservas.IdSucursal);

            if (reservas == null) {
                return new RespuestaReservaListar() { Datos = new List<Reserva>(), Exito = false, MotivoNoExito = MotivoNoReservaListar.ErrorNoControlado };
            }
            if (reservas.Count == 0)
            {
                return new RespuestaReservaListar() { Datos = new List<Reserva>(), Exito = false, MotivoNoExito = MotivoNoReservaListar.SinDatos };
            }

            respuestaReservaListar.Exito = true;
            respuestaReservaListar.MotivoNoExito = MotivoNoReservaListar.Exito;
            respuestaReservaListar.Datos = reservas;

            return respuestaReservaListar;                                              
        }

        public async Task<RespuestaReservaListar> ListarReservaAsync(EntradaReservaListar entradaListaReservas)
        {           
            return ListarReserva(entradaListaReservas);

        }
        public async Task<RespuestaReservaPasajeros> ListarPasajerosAsync(int idReserva)
        {
            return ListarPasajeros(idReserva);

        }
        public async Task<RespuestaReservaHabitaciones> ListarHabitacionesAsync(int idReserva)
        {
            return ListarHabitaciones(idReserva);

        }



    }
}
