using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PernaturalEntity : BaseEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatSexo")]
        public Int32 nPerNatSexo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatEstCivil")]
        public Int32 nPerNatEstCivil { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatTipResidencia")]
        public Int32 nPerNatTipResidencia { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatSitLaboral")]
        public Int32 nPerNatSitLaboral { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatOcupacion")]
        public Int32 nPerNatOcupacion { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerNatCondicion")]
        public Int32 nPerNatCondicion { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerFecEfectiva")]
        public DateTime dPerFecEfectiva { get; set; }
    }
}
