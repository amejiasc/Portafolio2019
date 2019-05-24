using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaReservaHabitaciones
    { 
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoReservaHabitacion MotivoNoExito { get; set; }
        [DataMember]
        public List<Habitacion> Datos { get; set; }
    }
    [DataContract]
    public enum MotivoNoReservaHabitacion
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        SinDatos = 1,
        [EnumMember]
        ErrorNoControlado = 2
    }
}
