using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerRelacionEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerRelTipo")]
        public Int32 nPerRelTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerRelEstado")]
        public Int32 nPerRelEstado { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerRelFecha")]
        public DateTime dPerRelFecha { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerJuridica")]
        public string cPerJuridica { get; set; }
    }
}
