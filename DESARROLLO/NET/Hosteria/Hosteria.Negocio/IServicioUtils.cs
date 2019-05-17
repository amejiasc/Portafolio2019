using Hosteria.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioUtils" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioUtils
    {
        [OperationContract]
        List<Region> Regiones();

        [OperationContract]
        List<Comuna> Comunas();
    }
}
