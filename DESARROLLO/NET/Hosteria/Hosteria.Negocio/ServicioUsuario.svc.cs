using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;
using Hosteria.Negocio.Clases;
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
        Respuesta Respuesta;
        public ServicioUsuario() {
            servicioUsuario = new Store.ServicioUsuario();
            Respuesta = new Respuesta();
        }

        public Task<Respuesta> ActualizarAsync(Entrada entradaDatos)
        {
            throw new NotImplementedException();
        }

        public Task<Respuesta> EliminarAsync(Entrada entradaDatos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserta un Usuario al Sistema, Recibe Parametros en Datos un JSON
        /// </summary>
        /// <param name="entradaDatos">Datos = Json de EntradaUsuarioCrear</param>
        /// <returns>Datos Respuesta en Json de RespuestaUsuarioCrear</returns>
        public async Task<Respuesta> InsertarAsync(Entrada entradaDatos)
        {
            RespuestaUsuarioCrear respuestaUsuario = new RespuestaUsuarioCrear();
            object ObjetoDeserializado;
            bool SePudoDeserializar = false;

            EntradaUsuarioCrear entradaUsuarioCrear = new EntradaUsuarioCrear();
            ObjetoDeserializado = entradaUsuarioCrear.FromJson(ref SePudoDeserializar, entradaDatos.Datos);
            if (!SePudoDeserializar)
            {
                return new Respuesta(ErroresTransaccionales.DatosMalSerializados);
            }
            entradaUsuarioCrear = (EntradaUsuarioCrear)ObjetoDeserializado;

            IUsuario ExisteUsuario = await servicioUsuario.TraerAsync(0, entradaUsuarioCrear.Usuario.Rut);
            

            if (ExisteUsuario != null) {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito = MotivoNoExitoUsuarioCrear.UsuarioyaExiste;
                respuestaUsuario.Usuario = new Hosteria.Clases.Usuario();
                Respuesta = new Clases.Respuesta(respuestaUsuario);
                return Respuesta;
            }

            int IdUsuario = await servicioUsuario.InsertarAsync(entradaUsuarioCrear.Usuario);
            if (IdUsuario == 0)
            {
                respuestaUsuario.Exito = false;
                respuestaUsuario.MotivoNoExito =  MotivoNoExitoUsuarioCrear.ErrorNoControlado;
                respuestaUsuario.Usuario = new Hosteria.Clases.Usuario();
            }
            else
            {
                respuestaUsuario.Exito = true;
                respuestaUsuario.Usuario = await servicioUsuario.TraerAsync(0, entradaUsuarioCrear.Usuario.Rut);
            }

            Respuesta = new Clases.Respuesta(respuestaUsuario);
            return Respuesta;
        }

        /// <summary>
        /// Trae un Usuario dal Sistema, Recibe Parametros en Datos un JSON
        /// </summary>
        /// <param name="entradaDatos">Datos = Json de EntradaUsuarioTraer</param>
        /// <returns>Datos Respuesta en Json de RespuestaUsuarioTraer</returns>

        public async Task<Clases.Respuesta> TraerAsync(Entrada entradaDatos)
        {
            RespuestaUsuarioTraer respuestaUsuario = new RespuestaUsuarioTraer();
            object ObjetoDeserializado;
            bool SePudoDeserializar = false; 

            EntradaUsuarioTraer entradaUsuarioTraer = new EntradaUsuarioTraer();
            ObjetoDeserializado = entradaUsuarioTraer.FromJson(ref SePudoDeserializar, entradaDatos.Datos);
            if (!SePudoDeserializar)
            {
                return new Respuesta(ErroresTransaccionales.DatosMalSerializados);
            }
            entradaUsuarioTraer = (EntradaUsuarioTraer)ObjetoDeserializado;

            IUsuario usuario = await servicioUsuario.TraerAsync(entradaUsuarioTraer.IdUsuario, entradaUsuarioTraer.RutUsuario);

            Respuesta Respuesta = new Respuesta();
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
