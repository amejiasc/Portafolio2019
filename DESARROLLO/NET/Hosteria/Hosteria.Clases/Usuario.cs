using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    [MessageContract(WrapperName = "Usuario")]
    public class Usuario  : IUsuario
    {
        [MessageBodyMember(Order = 1)]
        public int IdUsuario { get; set; }
        [MessageBodyMember(Order = 2)]
        public string Rut { get; set; }
        [MessageBodyMember(Order = 3)]
        public string Nombres { get; set; }
        [MessageBodyMember(Order = 4)]
        public string Apellidos { get; set; }
        [MessageBodyMember(Order = 5)]
        public string Email { get; set; }
        [MessageBodyMember(Order = 6)]
        public string Clave { get; set; }
    }
}
