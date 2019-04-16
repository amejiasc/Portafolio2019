using Hosteria.Tipos.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    //[MessageContract]
    public class RespuestaUsuarioTraer
    {
        //[MessageBodyMember(Order = 1)]
        public bool Exito { get; set; }
        //[MessageBodyMember(Order = 2)]
        public MotivoNoExitoTraerUsusario MotivoNoExito { get; set; }
       // [MessageBodyMember(Order = 3)]
        public IUsuario Usuario { get; set; }

        public RespuestaUsuarioTraer() {
            this.Exito = false;
            this.MotivoNoExito = MotivoNoExitoTraerUsusario.ErrorNoControlado;
            this.Usuario = new Usuario();
        }
    }

    public enum MotivoNoExitoTraerUsusario
    {
        ErrorNoControlado = 1,
        UsuarioNoExiste = 2
    }
}
