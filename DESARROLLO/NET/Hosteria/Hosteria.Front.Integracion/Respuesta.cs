using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hosteria.Front.Integracion
{
    public class Respuesta : Hosteria.Front.Tipos.Integracion.IRespuesta
    {
        public bool Exito { get; set; }
        public short MotivoNoExito { get; set; }
        public string Datos { get; set; }

        public Respuesta()
        {
            this.Exito = false;
            this.MotivoNoExito = -1;
            this.Datos = string.Empty;
        }

        public T ObtenerDatos<T>()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(this.Datos);
        }

        public T ObtenerDatos<T>(JsonSerializerSettings settings)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(this.Datos, settings);
        }
    }
}
