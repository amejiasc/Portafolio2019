using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    public class RespuestaUsuarioTraer
    {
        public bool Exito { get; set; }
        public MotivoNoExitoTraerUsusario MotivoNoExito { get; set; }
        public IUsuario Usuario { get; set; }

        public RespuestaUsuarioTraer() {
            this.Exito = false;
            this.Usuario = new Usuario();
        }
    }

    public enum MotivoNoExitoTraerUsusario
    {
        ErrorNoControlado = 1,
        UsuarioNoExiste = 2
    }
}
