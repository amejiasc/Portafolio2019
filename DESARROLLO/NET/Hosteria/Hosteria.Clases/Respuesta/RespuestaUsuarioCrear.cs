using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    public class RespuestaUsuarioCrear
    {   
        public bool Exito { get; set; }
        public MotivoNoExitoUsuarioCrear MotivoNoExito { get; set; }                
        public Tipos.Store.IUsuario Usuario { get; set; }
    }

    public enum MotivoNoExitoUsuarioCrear
    {
        ErrorNoControlado = 1,
        UsuarioyaExiste = 2
    }
}
