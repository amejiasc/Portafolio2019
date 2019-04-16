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
        //[OperationContract(Name = "InsertarUsuario")]
        //Task<RespuestaUsuarioCrear> InsertarAsync(IUsuario usuario);

        //[OperationContract(Name = "ActualizarUsuario")]
        //Task<RespuestaUsuarioActualizar> ActualizarAsync(IUsuario usuario);

        //[OperationContract(Name = "EliminarUsuario")]
        //Task<RespuestaUsuarioEliminar> EliminarAsync(IUsuario usuario);

        [OperationContract(Name = "TraerUsuario")]
        Task<RespuestaUsuarioTraer> TraerAsync(EntradaUsuarioTraer entradaUsuarioTraer);
    }
}
