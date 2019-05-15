using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaUsuarioTraer
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoTraerUsuario MotivoNoExito { get; set; }
        [DataMember]
        public Clases.Usuario Usuario { get; set; }

    }
    [DataContract]
    public enum MotivoNoExitoTraerUsuario
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        ErrorNoControlado = 1,
        [EnumMember]
        UsuarioNoExiste = 2
    }
}
