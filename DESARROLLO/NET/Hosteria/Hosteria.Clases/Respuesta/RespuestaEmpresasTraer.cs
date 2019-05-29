using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaEmpresasTraer
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoEmpresaTraer MotivoNoExito { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
    }
    [DataContract]
    public enum MotivoNoExitoEmpresaTraer
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        NoExiste = 1,
        [EnumMember]
        ErrorNoControlado = 2
    }
}
