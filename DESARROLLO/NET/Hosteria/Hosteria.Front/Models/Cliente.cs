﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hosteria.Front.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string RutCliente { get; set; }
        public string Nombrecliente { get; set; }
        public string Direccion { get; set; }
        public int Region { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public int Comuna { get; set; }
        public string Clave { get; set; }
        public string Giro { get; set; }
    }
}