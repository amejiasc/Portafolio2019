using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Hosteria.Front.Negocio.Helper
{
    public class Autenticacion
    {
        public static void DestruirSesionUsuario()
        {
            FormsAuthentication.SignOut();
        }

        public static RespuestaLogin TraerUsuarioAutenticado()
        {
            RespuestaLogin UsuarioAutenticado = new RespuestaLogin();
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    UsuarioAutenticado = Newtonsoft.Json.JsonConvert.DeserializeObject<RespuestaLogin>(ticket.UserData);
                }
            }
            return UsuarioAutenticado;
        }

        public static void Login(RespuestaLogin usuarioAutenticado)
        {
            DestruirSesionUsuario();

            HttpCookie Cookie = FormsAuthentication.GetAuthCookie("Hostal.Seguridad", false);

            Cookie.Name = FormsAuthentication.FormsCookieName;
            Cookie.Expires = DateTime.Now.AddMinutes(30);

            FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(Cookie.Value);
            FormsAuthenticationTicket NewTicket = new FormsAuthenticationTicket(Ticket.Version,
                                                                                Ticket.Name,
                                                                                Ticket.IssueDate,
                                                                                Ticket.Expiration,
                                                                                Ticket.IsPersistent,
                                                                                Newtonsoft.Json.JsonConvert.SerializeObject(usuarioAutenticado));

            Cookie.Value = FormsAuthentication.Encrypt(NewTicket);
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }
    }
}
