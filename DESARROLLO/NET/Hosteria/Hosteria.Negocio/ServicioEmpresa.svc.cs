using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioEmpresa" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioEmpresa.svc o ServicioEmpresa.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioEmpresa : IServicioEmpresa
    {
        public async Task DoWork()
        {
        }
    }
}
