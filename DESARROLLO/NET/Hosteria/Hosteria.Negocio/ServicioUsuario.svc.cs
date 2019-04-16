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

        public async Task<Clases.Respuesta> TraerAsync(Clases.Entrada entradaDatos)
        {
            RespuestaUsuarioTraer respuestaUsuario = new RespuestaUsuarioTraer();
            Hosteria.Tipos.Store.IServicioUsuario servicioUsuario = new Store.ServicioUsuario();

            object ObjetoDeserializado;
            bool SePudoDeserializar = false; 

            EntradaUsuarioTraer entradaUsuarioTraer = new EntradaUsuarioTraer();
            ObjetoDeserializado = entradaUsuarioTraer.FromJson(ref SePudoDeserializar, entradaDatos.Datos);
            entradaUsuarioTraer = (EntradaUsuarioTraer)ObjetoDeserializado;

            IUsuario usuario = await servicioUsuario.TraerAsync(entradaUsuarioTraer.IdUsuario, entradaUsuarioTraer.RutUsuario);

            Hosteria.Negocio.Clases.Respuesta Respuesta = new Clases.Respuesta();
            if (usuario == null)
            {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito = MotivoNoExitoTraerUsusario.UsuarioNoExiste;
                respuestaUsuario.Usuario = new Hosteria.Clases.Usuario();
            }
            else {
                respuestaUsuario.Exito = true;
                respuestaUsuario.Usuario = (Hosteria.Clases.Usuario)usuario;
            }

            Respuesta = new Clases.Respuesta(respuestaUsuario);
            return Respuesta;

        }
    }
}
