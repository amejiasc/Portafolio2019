using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaEjecutor
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoEjecutor MotivoNoExito { get; set; }
        [DataMember]
        public string Datos { get; set; }

        public RespuestaEjecutor() {
          
        }
    }
    [DataContract]
    public enum MotivoNoExitoEjecutor
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        ErrorNoControlado = 1
    }
    
}
