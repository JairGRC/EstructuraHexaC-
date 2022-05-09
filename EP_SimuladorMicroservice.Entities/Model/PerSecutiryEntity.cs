using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerSecutiryEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerJurCodigo")]
        public string cPerJurCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
    }
}
