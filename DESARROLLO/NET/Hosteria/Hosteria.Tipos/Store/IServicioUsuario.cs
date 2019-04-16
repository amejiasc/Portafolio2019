using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Tipos.Store
{
    public interface IServicioUsuario
    {
        Task<int> InsertarAsync(IUsuario usuario);
        Task<bool> ActualizarAsync(IUsuario usuario);
        Task<bool> EliminarAsync(IUsuario usuario);
        Task<IUsuario> TraerAsync(int idUsuario, string rut);
    }

    public interface IUsuario
    {
        int IdUsuario { get; set; }
        string Rut { get; set; }
        string Nombres { get; set; }
        string Apellidos { get; set; }
        string Email { get; set; }
        string Clave { get; set; }
    }
}
