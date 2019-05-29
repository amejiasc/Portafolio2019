using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosteria.Clases
{
    public class Sucursal
    {
        public List<Result> Result { get; set; }        
    }
    public class Result {
        public int IDSUCURSAL { get; set; }
        public string NOMBRESUCURSAL { get; set; }
    }
}
