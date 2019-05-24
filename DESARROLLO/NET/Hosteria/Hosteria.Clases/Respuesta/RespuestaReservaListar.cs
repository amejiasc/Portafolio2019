using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaReservaListar
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoReservaListar MotivoNoExito { get; set; }
        [DataMember]
        public List<Reserva> Datos { get; set; }
    }
    [DataContract]
    public enum MotivoNoReservaListar {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        SinDatos = 1,
        [EnumMember]
        ErrorNoControlado =2
    }
}
