using Hosteria.Clases.Entrada;
using Hosteria.Clases.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hosteria.Negocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioReserva" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioReserva
    {
        [OperationContract]
        RespuestaReservaCrear CrearReserva(EntradaReservaCrear entradaReservaCrear);
        [OperationContract]
        RespuestaReservaListar ListarReserva(EntradaReservaListar entradaListaReservas);
        [OperationContract]
        RespuestaReservaPasajeros ListarPasajeros(int idReserva);
        [OperationContract]
        RespuestaReservaHabitaciones ListarHabitaciones(int idReserva);
    }
}
