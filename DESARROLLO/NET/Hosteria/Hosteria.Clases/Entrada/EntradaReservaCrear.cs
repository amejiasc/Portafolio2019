using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    public class EntradaReservaCrear
    {
        public List<Pasajero> Pasajeros { get; set; }
        public int IdCliente { get; set; }
        public int IdSucursal { get; set; }
    }
}
