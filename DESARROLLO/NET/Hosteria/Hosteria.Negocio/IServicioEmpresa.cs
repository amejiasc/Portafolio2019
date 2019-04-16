using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioEmpresa" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioEmpresa
    {
        [OperationContract]
        Task DoWork();
    }
}
