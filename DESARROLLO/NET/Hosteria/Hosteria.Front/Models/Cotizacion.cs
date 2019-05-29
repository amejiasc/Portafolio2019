using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hosteria.Front.Models
{
    public class Cotizacion
    {
        public int IdCliente { get; set; }
        public int IdSucursal { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
    }
}