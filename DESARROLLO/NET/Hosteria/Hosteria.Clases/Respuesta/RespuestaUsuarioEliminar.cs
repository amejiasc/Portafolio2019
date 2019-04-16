using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    public class RespuestaUsuarioEliminar
    {
        public bool Exito { get; set; }
        public MotivoNoExitoEliminarUsusario MotivoNoExito { get; set; }
        public Tipos.Store.IUsuario Usuario { get; set; }
    }

    public enum MotivoNoExitoEliminarUsusario
    {
        ErrorNoControlado = 1,
        UsuarioyaExiste = 2
    }
}
