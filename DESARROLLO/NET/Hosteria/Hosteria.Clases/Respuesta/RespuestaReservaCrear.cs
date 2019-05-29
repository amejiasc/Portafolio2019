using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaReservaCrear
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoReservaCrear MotivoNoExito { get; set; }
    }
    [DataContract]
    public enum MotivoNoReservaCrear
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        NoSeCreoReserva = 0,
        [EnumMember]
        ErrorNoControlado = 2
    }
}
