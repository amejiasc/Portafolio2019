using Hosteria.Negocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    public class EntradaUsuarioTraer : Base
    {
        public int IdUsuario { get; set; }
        public string RutUsuario { get; set; }
        public EntradaUsuarioTraer() {            
        }
    }
}
