using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio.Clases
{
    public class Base
    {
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public object FromJson(ref bool exito, string json)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
            {
                exito = false;
                return null;
            }

            try
            {
                object ObjetoDeserializado = Newtonsoft.Json.JsonConvert.DeserializeObject(json, this.GetType());
                exito = true;
                return ObjetoDeserializado;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());

                exito = false;
                return null;
            }
        }
    }
}
