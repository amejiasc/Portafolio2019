using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    [DataContract]
    public class Region
    {
        [DataMember]
        public int IdRegion { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}
