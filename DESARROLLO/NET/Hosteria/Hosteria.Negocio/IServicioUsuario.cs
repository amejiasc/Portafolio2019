using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;
using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioUsuario
    {

        /// <summary>
        ///      Obtiene una clase generica con datos variables en JSON En el parametros Datos de la Entrada
        /// </summary>
        /// <param name="entradaDatos">En Datos serializar la Clase EntradaUsuarioCrear</param>
        /// <returns>De datos DesSerializar RespuestaUsuarioCrear</returns>
        [OperationContract(Name = "InsertarUsuario")]
        Task<Clases.Respuesta> InsertarAsync(Clases.Entrada entradaDatos);

        [OperationContract(Name = "ActualizarUsuario")]
        Task<Clases.Respuesta> ActualizarAsync(Clases.Entrada entradaDatos);

        [OperationContract(Name = "EliminarUsuario")]
        Task<Clases.Respuesta> EliminarAsync(Clases.Entrada entradaDatos);

        /// <summary>
        ///      Obtiene una clase generica con datos variables en JSON En el parametros Datos de la Entrada
        /// </summary>
        /// <param name="entradaDatos">En Datos serializar la Clase EntradaUsuarioTraer</param>
        /// <returns>De datos DesSerializar RespuestaUsuarioTraer</returns>
        [OperationContract(Name = "TraerUsuario")]
        Task<Clases.Respuesta> TraerAsync(Clases.Entrada entradaDatos);
    }
}
