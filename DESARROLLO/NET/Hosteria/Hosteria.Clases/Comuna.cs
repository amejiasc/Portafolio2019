using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    [DataContract]
    public class Comuna
    {
        [DataMember]
        public int IdComuna { get; set; }
        [DataMember]        
        public string Nombre { get; set; }
        [DataMember]
        public int IdRegion { get; set; }
    }
}
