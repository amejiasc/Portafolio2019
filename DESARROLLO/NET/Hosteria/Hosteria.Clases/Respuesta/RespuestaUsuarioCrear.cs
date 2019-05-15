using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaUsuarioCrear
    {   
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoUsuarioCrear MotivoNoExito { get; set; }
        [DataMember]
        public Tipos.Store.IUsuario Usuario { get; set; }
    }

    public enum MotivoNoExitoUsuarioCrear
    {
        ErrorNoControlado = 1,
        UsuarioyaExiste = 2
    }
}
