﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio.Clases
{
    [DataContract]
    public class Respuesta : Tipos.IRespuesta
    {
        [DataMember(Order = 1)]
        public bool Exito { get; set; }
        [DataMember(Order = 2)]
        public short MotivoNoExito { get; set; }
        [DataMember(Order = 3)]
        public string Datos { get; set; }

        public Respuesta()
        {

        }

        public Respuesta(object datos)
        {
            this.Exito = true;
            this.MotivoNoExito = 0;
            this.Datos = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
        }

        public Respuesta(object datos, short motivoNoExito)
        {
            this.Exito = true;
            this.MotivoNoExito = motivoNoExito;
            this.Datos = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
        }

        public Respuesta(short motivoNoExito)
        {
            this.Exito = false;
            this.MotivoNoExito = motivoNoExito;
            this.Datos = string.Empty;
        }
    }
}
