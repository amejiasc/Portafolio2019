﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Respuesta
{
    [DataContract]
    public class RespuestaUsuarioLogin
    {
        [DataMember]
        public bool Exito { get; set; }
        [DataMember]
        public MotivoNoExitoLoginUsuario MotivoNoExito { get; set; }

        [DataMember]
        public Clases.Usuario Usuario { get; set; }

        [DataMember]
        public Guid IdSesion { get; set; }

    }
    [DataContract]
    public enum MotivoNoExitoLoginUsuario
    {
        [EnumMember]
        Exito = 0,
        [EnumMember]
        ErrorNoControlado = 1,
        [EnumMember]
        UsuarioNoExiste = 2,
        [EnumMember]
        UsuarioClaveIncorrecta = 3,

    }
}