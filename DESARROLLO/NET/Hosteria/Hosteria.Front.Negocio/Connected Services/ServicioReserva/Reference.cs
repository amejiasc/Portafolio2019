﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hosteria.Front.Negocio.ServicioReserva {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioReserva.IServicioReserva")]
    public interface IServicioReserva {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/CrearReserva", ReplyAction="http://tempuri.org/IServicioReserva/CrearReservaResponse")]
        Hosteria.Clases.Respuesta.RespuestaReservaCrear CrearReserva(Hosteria.Clases.Entrada.EntradaReservaCrear entradaReservaCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/CrearReserva", ReplyAction="http://tempuri.org/IServicioReserva/CrearReservaResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaCrear> CrearReservaAsync(Hosteria.Clases.Entrada.EntradaReservaCrear entradaReservaCrear);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarReserva", ReplyAction="http://tempuri.org/IServicioReserva/ListarReservaResponse")]
        Hosteria.Clases.Respuesta.RespuestaReservaListar ListarReserva(Hosteria.Clases.Entrada.EntradaReservaListar entradaListaReservas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarReserva", ReplyAction="http://tempuri.org/IServicioReserva/ListarReservaResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaListar> ListarReservaAsync(Hosteria.Clases.Entrada.EntradaReservaListar entradaListaReservas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarPasajeros", ReplyAction="http://tempuri.org/IServicioReserva/ListarPasajerosResponse")]
        Hosteria.Clases.Respuesta.RespuestaReservaPasajeros ListarPasajeros(int idReserva);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarPasajeros", ReplyAction="http://tempuri.org/IServicioReserva/ListarPasajerosResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaPasajeros> ListarPasajerosAsync(int idReserva);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarHabitaciones", ReplyAction="http://tempuri.org/IServicioReserva/ListarHabitacionesResponse")]
        Hosteria.Clases.Respuesta.RespuestaReservaHabitaciones ListarHabitaciones(int idReserva);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioReserva/ListarHabitaciones", ReplyAction="http://tempuri.org/IServicioReserva/ListarHabitacionesResponse")]
        System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaHabitaciones> ListarHabitacionesAsync(int idReserva);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioReservaChannel : Hosteria.Front.Negocio.ServicioReserva.IServicioReserva, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioReservaClient : System.ServiceModel.ClientBase<Hosteria.Front.Negocio.ServicioReserva.IServicioReserva>, Hosteria.Front.Negocio.ServicioReserva.IServicioReserva {
        
        public ServicioReservaClient() {
        }
        
        public ServicioReservaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioReservaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioReservaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioReservaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Hosteria.Clases.Respuesta.RespuestaReservaCrear CrearReserva(Hosteria.Clases.Entrada.EntradaReservaCrear entradaReservaCrear) {
            return base.Channel.CrearReserva(entradaReservaCrear);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaCrear> CrearReservaAsync(Hosteria.Clases.Entrada.EntradaReservaCrear entradaReservaCrear) {
            return base.Channel.CrearReservaAsync(entradaReservaCrear);
        }
        
        public Hosteria.Clases.Respuesta.RespuestaReservaListar ListarReserva(Hosteria.Clases.Entrada.EntradaReservaListar entradaListaReservas) {
            return base.Channel.ListarReserva(entradaListaReservas);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaListar> ListarReservaAsync(Hosteria.Clases.Entrada.EntradaReservaListar entradaListaReservas) {
            return base.Channel.ListarReservaAsync(entradaListaReservas);
        }
        
        public Hosteria.Clases.Respuesta.RespuestaReservaPasajeros ListarPasajeros(int idReserva) {
            return base.Channel.ListarPasajeros(idReserva);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaPasajeros> ListarPasajerosAsync(int idReserva) {
            return base.Channel.ListarPasajerosAsync(idReserva);
        }
        
        public Hosteria.Clases.Respuesta.RespuestaReservaHabitaciones ListarHabitaciones(int idReserva) {
            return base.Channel.ListarHabitaciones(idReserva);
        }
        
        public System.Threading.Tasks.Task<Hosteria.Clases.Respuesta.RespuestaReservaHabitaciones> ListarHabitacionesAsync(int idReserva) {
            return base.Channel.ListarHabitacionesAsync(idReserva);
        }
    }
}
