using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Store
{
    public class ServicioUsuario : IServicioUsuario
    {
        public Task<bool> ActualizarAsync(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IUsuario> TraerAsync(int idUsuario, string rut)
        {
            IUsuario usuario = new Clases.Usuario() { Nombres = "Alexis", Rut=rut, IdUsuario=idUsuario };
            return usuario;
        }

        public async Task<int> InsertarAsync(IUsuario usuario)
        {
            return 1;
            //throw new NotImplementedException();
        }
    }
}
