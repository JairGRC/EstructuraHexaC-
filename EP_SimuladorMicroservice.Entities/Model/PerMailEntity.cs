using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerMailEntity 
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerMaiTipo")]
        public Int32 nPerMaiTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerMaiNombre")]
        public string cPerMaiNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerEstado")]
        public Int32 nPerEstado { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerMaiFecRegistro")]
        public DateTime dPerMaiFecRegistro { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nuevoPerMaiTipo")]
        public string nuevoPerMaiTipo { get; set; }
    }
}
