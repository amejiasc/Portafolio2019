using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio.Tipos
{
    public interface IRespuesta
    {
        bool Exito { get; set; }
        short MotivoNoExito { get; set; }
        string Datos { get; set; }
    }
}
