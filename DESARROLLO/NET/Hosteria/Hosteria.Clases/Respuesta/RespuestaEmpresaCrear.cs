using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaEmpresaCrear
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoEmpresaCrear MotivoNoExito { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
    }

    [DataContract]
    public enum MotivoNoExitoEmpresaCrear
    {
        [EnumMember]
        Exito =0,
        [EnumMember]
        ErrorNoControlado = 1,
        [EnumMember]
        EmpresayaExiste = 2
    }
}
