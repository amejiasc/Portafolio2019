using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaReservaPasajeros
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoReservaPasajeros MotivoNoExito { get; set; }
        [DataMember]
        public List<Pasajero> Datos { get; set; }
    }
    [DataContract]
    public enum MotivoNoReservaPasajeros
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        SinDatos = 1,
        [EnumMember]
        ErrorNoControlado = 2
    }
}
