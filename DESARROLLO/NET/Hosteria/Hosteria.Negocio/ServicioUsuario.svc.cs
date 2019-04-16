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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioUsuario.svc o ServicioUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioUsuario : IServicioUsuario
    {

        //public async Task<RespuestaUsuarioCrear> InsertarAsync(IUsuario usuario)
        //{
        //    RespuestaUsuarioCrear respuestaUsuarioCrear = new RespuestaUsuarioCrear();
        //    Tipos.Store.IServicioUsuario servicioUsuario = new Store.ServicioUsuario();
        //    int idUsuario = await servicioUsuario.InsertarAsync(usuario);
        //    if (idUsuario.Equals(0))
        //    {
        //        respuestaUsuarioCrear.Exito = false;
        //        respuestaUsuarioCrear.MotivoNoExito = MotivoNoExitoUsuarioCrear.ErrorNoControlado;
        //        respuestaUsuarioCrear.Usuario = new Clases.Usuario();
        //        return respuestaUsuarioCrear;
        //    }

        //    respuestaUsuarioCrear.Exito = true;
        //    respuestaUsuarioCrear.Usuario = await servicioUsuario.TraerAsync(idUsuario, string.Empty);

        //    return respuestaUsuarioCrear;

        //}

        //public async Task<RespuestaUsuarioActualizar> ActualizarAsync(IUsuario usuario)
        //{
        //    RespuestaUsuarioActualizar respuestaUsuario = new RespuestaUsuarioActualizar();
        //    Tipos.Store.IServicioUsuario servicioUsuario = new Store.ServicioUsuario();
        //    bool exito = await servicioUsuario.ActualizarAsync(usuario);
        //    if (exito)
        //    {
        //        respuestaUsuario.Exito = false;
        //        respuestaUsuario.MotivoNoExito = MotivoNoExitoActualizarUsusario.ErrorNoControlado;
        //        respuestaUsuario.Usuario = new Clases.Usuario();
        //        return respuestaUsuario;
        //    }

        //    respuestaUsuario.Exito = true;
        //    respuestaUsuario.Usuario = await servicioUsuario.TraerAsync(usuario.IdUsuario, string.Empty);

        //    return respuestaUsuario;

        //}

        //public async Task<RespuestaUsuarioEliminar> EliminarAsync(IUsuario usuario)
        //{
        //    RespuestaUsuarioEliminar respuestaUsuario = new RespuestaUsuarioEliminar();
        //    Tipos.Store.IServicioUsuario servicioUsuario = new Store.ServicioUsuario();
        //    bool exito = await servicioUsuario.EliminarAsync(usuario);
        //    if (exito)
        //    {
        //        respuestaUsuario.Exito = false;
        //        respuestaUsuario.MotivoNoExito = MotivoNoExitoEliminarUsusario.ErrorNoControlado;
        //        respuestaUsuario.Usuario = new Clases.Usuario();
        //        return respuestaUsuario;
        //    }

        //    respuestaUsuario.Exito = true;
        //    respuestaUsuario.Usuario = await servicioUsuario.TraerAsync(usuario.IdUsuario, string.Empty);

        //    return respuestaUsuario;

        //}

        public async Task<RespuestaUsuarioTraer> TraerAsync(EntradaUsuarioTraer entradaUsuarioTraer)
        {
            RespuestaUsuarioTraer respuestaUsuario = new RespuestaUsuarioTraer();
            Tipos.Store.IServicioUsuario servicioUsuario = new Store.ServicioUsuario();
            IUsuario usuario = await servicioUsuario.TraerAsync(entradaUsuarioTraer.IdUsuario, entradaUsuarioTraer.RutUsuario);
            if (usuario == null)
            {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito = MotivoNoExitoTraerUsusario.UsuarioNoExiste;
                respuestaUsuario.Usuario = new Clases.Usuario();
                return respuestaUsuario;
            }

            respuestaUsuario.Exito = true;
            respuestaUsuario.Usuario = (Clases.Usuario)usuario;

            return respuestaUsuario;

        }
    }
}
