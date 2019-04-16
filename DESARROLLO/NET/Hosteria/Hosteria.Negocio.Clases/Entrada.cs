using Hosteria.Negocio.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio.Clases
{
    [MessageContract]
    public class Entrada : IEntrada
    {
        [MessageBodyMember(Order =1)]
        public string Datos { get; set; }

        public Entrada() {
            this.Datos = string.Empty;
        }
    }
}
