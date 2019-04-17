using Hosteria.Negocio.Clases;
using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    public class EntradaUsuarioCrear     : Base
    {
        public IUsuario Usuario { get; set; }
        public EntradaUsuarioCrear() {

        }
    }
}
