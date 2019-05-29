using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    public class Trabajador
    {
        public int IdTrabajador { get; set; }
        public string RutTrabajador { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public string RutCliente { get; set; }
        public int IdCliente { get; set; }
    }
}
