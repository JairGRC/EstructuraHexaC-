using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerIdentificaEntity:BaseEntity
    {
        
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerIdeTipo")]
        public Int32 nPerIdeTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerIdeNumero")]
        public string cPerIdeNumero { get; set; }
    }
}
