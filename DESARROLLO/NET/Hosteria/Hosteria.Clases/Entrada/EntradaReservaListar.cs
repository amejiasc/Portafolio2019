using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases.Entrada
{
    [DataContract]
    public class EntradaReservaListar
    {
        [DataMember]
        public int IdReserva { get; set; }
        [DataMember]
        public string RutEmpresa { get; set; }
        [DataMember]
        public string RutPasajero { get; set; }
        [DataMember]
        public string NombreEmpresa { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
        public int EstadoReserva { get; set; }
        [DataMember]
        public int IdSucursal { get; set; }

        public EntradaReservaListar() {
            this.IdReserva = 0;
            this.RutEmpresa = "-1";
            this.RutPasajero = "-1";
            this.NombreEmpresa = "-1";
            this.FechaDesde = DateTime.MinValue;
            this.FechaHasta = DateTime.MaxValue;
            this.EstadoReserva = 0;
            this.IdSucursal = 0;
        }

    }

}
