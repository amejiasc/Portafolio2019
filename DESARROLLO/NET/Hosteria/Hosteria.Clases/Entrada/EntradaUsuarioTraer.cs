using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    [DataContract]
    public class EntradaUsuarioTraer
    {
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string RutUsuario { get; set; }
    }
}
