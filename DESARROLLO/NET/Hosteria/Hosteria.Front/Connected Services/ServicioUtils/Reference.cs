﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hosteria.Front.ServicioUtils {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioUtils.IServicioUtils")]
    public interface IServicioUtils {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUtils/Regiones", ReplyAction="http://tempuri.org/IServicioUtils/RegionesResponse")]
        Hosteria.Clases.Region[] Regiones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUtils/Regiones", ReplyAction="http://tempuri.org/IServicioUtils/RegionesResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Region[]> RegionesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUtils/Comunas", ReplyAction="http://tempuri.org/IServicioUtils/ComunasResponse")]
        Hosteria.Clases.Comuna[] Comunas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioUtils/Comunas", ReplyAction="http://tempuri.org/IServicioUtils/ComunasResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Comuna[]> ComunasAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioUtilsChannel : Hosteria.Front.ServicioUtils.IServicioUtils, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioUtilsClient : System.ServiceModel.ClientBase<Hosteria.Front.ServicioUtils.IServicioUtils>, Hosteria.Front.ServicioUtils.IServicioUtils {
        
        public ServicioUtilsClient() {
        }
        
        public ServicioUtilsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioUtilsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioUtilsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioUtilsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Hosteria.Clases.Region[] Regiones() {
            return base.Channel.Regiones();
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Region[]> RegionesAsync() {
            return base.Channel.RegionesAsync();
        }
        
        public Hosteria.Clases.Comuna[] Comunas() {
            return base.Channel.Comunas();
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Comuna[]> ComunasAsync() {
            return base.Channel.ComunasAsync();
        }
    }
}