using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hosteria.Front.Models
{
    public class Cliente : Clases.Empresa
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
    }
}