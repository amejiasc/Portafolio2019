using System;
using System.Collections.Generic;
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
        #endregion

    }
}
