using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaEmpresasListar
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoEmpresaListar MotivoNoExito { get; set; }
        [DataMember]
        public List<Empresa> Empresas { get; set; }
    }
    [DataContract]
    public enum MotivoNoExitoEmpresaListar
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        NoHayDatos = 1,
        [EnumMember]
        ErrorNoControlado= 2
    }
}
