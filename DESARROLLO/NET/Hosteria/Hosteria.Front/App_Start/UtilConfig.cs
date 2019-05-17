using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Hosteria.Front
{
    public class UtilConfig
    {
        public static List<Clases.Region> Regiones() {

            List<Clases.Region> regiones = new List<Clases.Region>();
            if (HttpRuntime.Cache.Get("regiones") == null)
            {
                using (ServicioUtils.ServicioUtilsClient servicioUtilsClient = new ServicioUtils.ServicioUtilsClient())
                {              
                    regiones = servicioUtilsClient.Regiones().ToList();
                    servicioUtilsClient.Close();
                }
                HttpRuntime.Cache.Insert("regiones", regiones, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
            }
            else
            {
                regiones = (List<Clases.Region>)HttpRuntime.Cache.Get("regiones");
            }

            return regiones;
            
            
        }
        public static List<Clases.Comuna> Comunas()
        {

            List<Clases.Comuna> comunas = new List<Clases.Comuna>();
            if (HttpRuntime.Cache.Get("comunas") == null)
            {
                using (ServicioUtils.ServicioUtilsClient servicioUtilsClient = new ServicioUtils.ServicioUtilsClient())
                {
                    comunas = servicioUtilsClient.Comunas().ToList();
                    servicioUtilsClient.Close();
                }
                HttpRuntime.Cache.Insert("comunas", comunas, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
            }
            else
            {
                comunas = (List<Clases.Comuna>)HttpRuntime.Cache.Get("comunas");
            }

            return comunas;


        }
    }
}