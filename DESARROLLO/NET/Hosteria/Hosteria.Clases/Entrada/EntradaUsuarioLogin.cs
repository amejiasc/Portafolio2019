using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    [DataContract]
    public class EntradaUsuarioLogin
    {
        [DataMember]
        public string Rut { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
