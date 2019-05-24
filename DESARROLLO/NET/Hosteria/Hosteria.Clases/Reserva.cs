using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string FechaReserva { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string RutCliente { get; set; }
        public string NombreCliente { get; set; }
        public int EstadoReserva { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public int Monto { get; set; }
    }
    public class Pasajero : Trabajador
    {
        public string Estado { get; set; }
        public int Habitacion { get; set; }
        public string FechaCheckin { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
    }
    public class Habitacion
    {
        public int NroHabitacion { get; set; }
        public int Tipo { get; set; }
        public int Precio { get; set; }
        public int Estado { get; set; }
        public string Nombre { get; set; }
    }
    
}
