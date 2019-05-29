using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Tipos.Store
{
    public interface IServicioUsuario
    {
        int Insertar(IUsuario usuario);
        bool Actualizar(IUsuario usuario);
        bool Eliminar(IUsuario usuario);
        IUsuario Traer(int idUsuario, string rut);
        int TraerLogin(string rut, string email, string clave);
        int TraerLoginCliente(string rut, string email, string clave);
        void CrearLoginUsuario(string rut, Guid guid);
        void CrearLoginCliente(string rut, Guid guid);
        List<IUsuario> Listar(int idUsuario, string rut);
    }

    public interface IUsuario
    {
        int IdUsuario { get; set; }
        string Rut { get; set; }
        string Nombres { get; set; }
        string Apellidos { get; set; }
        string Email { get; set; }
        string Clave { get; set; }
        int IdSucursal { get; set; }
        string Codigo { get; set; }
    }
}
