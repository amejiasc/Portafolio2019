using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Front.Negocio
{
    public class Login
    {
        public RespuestaLogin LoginCliente(string rut, string clave) {
            ServicioUsuario.ServicioUsuarioClient servicioUsuarioClient = new ServicioUsuario.ServicioUsuarioClient();
            var respuesta = servicioUsuarioClient.LoginCliente(new Clases.Entrada.EntradaUsuarioLogin() { Clave = clave, Rut = rut, Email = "-1"});

            if (!respuesta.Exito) {
                switch (respuesta.MotivoNoExito)
                {
                    case Clases.Respuesta.MotivoNoExitoLogin.UsuarioClaveIncorrecta:
                        return new RespuestaLogin() { Exito = false, Mensaje = "Clave ingresada Incorrecta" };
                    case Clases.Respuesta.MotivoNoExitoLogin.UsuarioNoExiste:
                        return new RespuestaLogin() { Exito = false, Mensaje = "Cliente/Empresa no existe" };
                    case Clases.Respuesta.MotivoNoExitoLogin.ErrorNoControlado:
                        return new RespuestaLogin() { Exito = false, Mensaje = "Ha ocurrido un error no esperado" };
                    default:
                        break;
                }
            }

            return new RespuestaLogin() { Exito=true, Mensaje="", RespuestaCliente = respuesta };  

        }

    }
    public class RespuestaLogin
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public Clases.Respuesta.RespuestaClienteLogin RespuestaCliente { get; set; }
        public RespuestaLogin()
        {
            Exito = true;
            Mensaje = "";
            RespuestaCliente = new Clases.Respuesta.RespuestaClienteLogin();
        }
    }

}
