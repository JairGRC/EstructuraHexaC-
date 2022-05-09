using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PertelefonoEntity: BaseEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerTelTipo")]
        public Int32 nPerTelTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerTelNumero")]
        public string cPerTelNumero { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerTelStatus")]
        public Int32 nPerTelStatus { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerTelFecRegistro")]
        public DateTime dPerTelFecRegistro { get; set; }
    }
}
