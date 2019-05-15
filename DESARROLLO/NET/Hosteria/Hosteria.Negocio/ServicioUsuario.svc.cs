using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;
using Hosteria.Negocio.Tipos;
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

        Hosteria.Tipos.Store.IServicioUsuario servicioUsuario;
        public ServicioUsuario()
        {
            servicioUsuario = new Store.ServicioUsuario();
        }

        #region "Sincrono"        
        public RespuestaUsuarioTraer Traer(EntradaUsuarioTraer entradaUsuarioTraer)
        {
            RespuestaUsuarioTraer respuestaUsuario = new RespuestaUsuarioTraer();

            IUsuario usuario = servicioUsuario.Traer(entradaUsuarioTraer.IdUsuario, entradaUsuarioTraer.RutUsuario);

            if (usuario == null)
            {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito = MotivoNoExitoTraerUsuario.UsuarioNoExiste;
                respuestaUsuario.Usuario = new Hosteria.Clases.Usuario();
            }
            else
            {
                respuestaUsuario.Exito = true;
                respuestaUsuario.Usuario = (Hosteria.Clases.Usuario)usuario;
            }
            return respuestaUsuario;

        }
        public RespuestaUsuarioLogin LoginUsuario(EntradaUsuarioLogin entradaDatos)
        {
            RespuestaUsuarioLogin respuestaUsuario = new RespuestaUsuarioLogin();

            int IdUsuario = servicioUsuario.TraerLogin(entradaDatos.Rut, entradaDatos.Email, entradaDatos.Clave);
            IUsuario usuario = servicioUsuario.Traer(IdUsuario, string.Empty);
            if (usuario == null)
            {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito = MotivoNoExitoLoginUsuario.UsuarioNoExiste;
                respuestaUsuario.Usuario = new Hosteria.Clases.Usuario();
                return respuestaUsuario;

            }

            Guid guid = Guid.NewGuid();
            try
            {
                servicioUsuario.CrearLoginUsuario(usuario.Rut, guid);
            }
            catch (Exception ex)
            {
                return new RespuestaUsuarioLogin()
                {
                    Exito = false,
                    IdSesion = Guid.Empty,
                    MotivoNoExito = MotivoNoExitoLoginUsuario.ErrorNoControlado,
                    Usuario = new Clases.Usuario()
                };
            }
            respuestaUsuario.Exito = true;
            respuestaUsuario.IdSesion = guid;
            respuestaUsuario.Usuario = (Hosteria.Clases.Usuario)usuario;

            return respuestaUsuario;
        }
        #endregion

        #region "Asincrono"        
        public async Task<RespuestaUsuarioTraer> TraerAsync(EntradaUsuarioTraer entradaUsuarioTraer)
        {
            return Traer(entradaUsuarioTraer);
        }
        public async Task<RespuestaUsuarioLogin> LoginUsuarioAsync(EntradaUsuarioLogin entradaDatos)
        {
            return LoginUsuario(entradaDatos);
        }
        #endregion


    }
}
