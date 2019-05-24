using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Hosteria.Clases;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioUtils" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioUtils.svc o ServicioUtils.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioUtils : IServicioUtils
    {

        Store.ServicioUtils ServicioUtil;
        public ServicioUtils() {
            ServicioUtil = new Store.ServicioUtils();
        }

        #region "Sincronos"
        public List<Comuna> Comunas()
        {
            return ServicioUtil.ListarComunas();
        }

        public List<Region> Regiones()
        {
            return ServicioUtil.ListarRegiones();

        }
        public Clases.Respuesta.RespuestaEjecutor Ejecutor(string sql, TipoConsulta tipoConsulta )
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(ServicioUtil.Ejecutor(sql));            

            switch (tipoConsulta)
            {
                case TipoConsulta.Consulta:
                    sql = string.Concat("SELECT ", sql);
                    break;
                case TipoConsulta.Insertar:
                    sql = string.Concat("INSERT ", sql);
                    break;
                case TipoConsulta.Modificar:
                    sql = string.Concat("UPDATE ", sql);
                    break;
                case TipoConsulta.Eliminar:
                    sql = string.Concat("DELETE ", sql);
                    break;
            }

            Clases.Respuesta.RespuestaEjecutor respuesta = new Clases.Respuesta.RespuestaEjecutor();
            DataSet dataset = ServicioUtil.Ejecutor(sql);

            if (dataset == null)
            {
                respuesta.Exito = false;
                respuesta.Datos = "";
                respuesta.MotivoNoExito = Clases.Respuesta.MotivoNoExitoEjecutor.ErrorNoControlado;
            }
            else
            {
                respuesta.Exito = true;
                respuesta.Datos = Newtonsoft.Json.JsonConvert.SerializeObject(dataset);
                respuesta.MotivoNoExito = Clases.Respuesta.MotivoNoExitoEjecutor.Exito;
            }
            return respuesta;
        }
        #endregion
        #region "Asincronos"
        public async Task<List<Region>> RegionesAsync()
        {
            return ServicioUtil.ListarRegiones();

        }
        public async Task<List<Comuna>> ComunasAsync()
        {
            return ServicioUtil.ListarComunas();

        }
        public async Task<Clases.Respuesta.RespuestaEjecutor> EjecutorAsync(string sql, TipoConsulta tipoConsulta)
        {
            return Ejecutor(sql, tipoConsulta);

        }

        #endregion

    }
}
