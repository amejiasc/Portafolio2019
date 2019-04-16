using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    public class RespuestaUsuarioActualizar
    {
        public bool Exito { get; set; }
        public MotivoNoExitoActualizarUsusario MotivoNoExito { get; set; }
        public Tipos.Store.IUsuario Usuario { get; set; }
    }

    public enum MotivoNoExitoActualizarUsusario
    {
        ErrorNoControlado = 1,
        UsuarioyaExiste = 2
    }
}
