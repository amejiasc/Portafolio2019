﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hosteria.Front.Negocio.ServicioUsuario {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioUsuario.IServicioUsuario")]
    public interface IServicioUsuario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/Traer", ReplyAction="http://tempuri.org/IServicioUsuario/TraerResponse")]
        Hosteria.Clases.Respuesta.RespuestaUsuarioTraer Traer(Hosteria.Clases.Entrada.EntradaUsuarioTraer entradaDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/Traer", ReplyAction="http://tempuri.org/IServicioUsuario/TraerResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaUsuarioTraer> TraerAsync(Hosteria.Clases.Entrada.EntradaUsuarioTraer entradaDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/LoginUsuario", ReplyAction="http://tempuri.org/IServicioUsuario/LoginUsuarioResponse")]
        Hosteria.Clases.Respuesta.RespuestaUsuarioLogin LoginUsuario(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/LoginUsuario", ReplyAction="http://tempuri.org/IServicioUsuario/LoginUsuarioResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaUsuarioLogin> LoginUsuarioAsync(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/LoginCliente", ReplyAction="http://tempuri.org/IServicioUsuario/LoginClienteResponse")]
        Hosteria.Clases.Respuesta.RespuestaClienteLogin LoginCliente(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUsuario/LoginCliente", ReplyAction="http://tempuri.org/IServicioUsuario/LoginClienteResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaClienteLogin> LoginClienteAsync(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioUsuarioChannel : Hosteria.Front.Negocio.ServicioUsuario.IServicioUsuario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioUsuarioClient : System.ServiceModel.ClientBase<Hosteria.Front.Negocio.ServicioUsuario.IServicioUsuario>, Hosteria.Front.Negocio.ServicioUsuario.IServicioUsuario {
        
        public ServicioUsuarioClient() {
        }
        
        public ServicioUsuarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioUsuarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioUsuarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioUsuarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Hosteria.Clases.Respuesta.RespuestaUsuarioTraer Traer(Hosteria.Clases.Entrada.EntradaUsuarioTraer entradaDatos) {
            return base.Channel.Traer(entradaDatos);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaUsuarioTraer> TraerAsync(Hosteria.Clases.Entrada.EntradaUsuarioTraer entradaDatos) {
            return base.Channel.TraerAsync(entradaDatos);
        }
        
        public Hosteria.Clases.Respuesta.RespuestaUsuarioLogin LoginUsuario(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos) {
            return base.Channel.LoginUsuario(entradaDatos);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaUsuarioLogin> LoginUsuarioAsync(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos) {
            return base.Channel.LoginUsuarioAsync(entradaDatos);
        }
        
        public Hosteria.Clases.Respuesta.RespuestaClienteLogin LoginCliente(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos) {
            return base.Channel.LoginCliente(entradaDatos);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaClienteLogin> LoginClienteAsync(Hosteria.Clases.Entrada.EntradaUsuarioLogin entradaDatos) {
            return base.Channel.LoginClienteAsync(entradaDatos);
        }
    }
}
