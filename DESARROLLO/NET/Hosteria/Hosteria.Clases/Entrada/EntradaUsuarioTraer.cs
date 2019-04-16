using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    //[MessageContract]
    public class EntradaUsuarioTraer
    {
        //[MessageBodyMember(Order = 1)]
        public int IdUsuario { get; set; }
        //[MessageBodyMember(Order = 2)]
        public string RutUsuario { get; set; }
        public EntradaUsuarioTraer() {
            this.IdUsuario = 0;
            this.RutUsuario = string.Empty;
        }
    }
}
