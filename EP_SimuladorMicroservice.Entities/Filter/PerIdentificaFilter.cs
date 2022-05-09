using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public class PerIdentificaFilter
    {
        public string nConstCodigo { get; set; }
        public Int32 nConstGrupo { get; set; }
        public Int32 nConstGrupoPadre { get; set; }
        public Int32 nConstValorPadre { get; set; }
    }
}
