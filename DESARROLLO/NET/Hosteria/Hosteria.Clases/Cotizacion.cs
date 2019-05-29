using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    public class Cotizacion
    {
        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public List<Pasajero> Pssajeros { get; set; }

    }
}
