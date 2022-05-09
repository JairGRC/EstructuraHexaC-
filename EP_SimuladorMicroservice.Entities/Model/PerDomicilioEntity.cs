using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerDomicilioEntity : BaseEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomTipo")]
        public int nPerDomTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomDireccion")]
        public string cPerDomDireccion { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomNumero")]
        public string cPerDomNumero { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomManzana")]
        public string cPerDomManzana { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomLote")]
        public string cPerDomLote { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomSubTipo")]
        public Int32 nPerDomSubTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomSubTipoNumero")]
        public string cPerDomSubTipoNumero { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomResTipo")]
        public Int32 nPerDomResTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomResNombre")]
        public string cPerDomResNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomSecTipo")]
        public Int32 nPerDomSecTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomSecNombre")]
        public string cPerDomSecNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cUbiGeoCodigo")]
        public string cUbiGeoCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomCarta")]
        public Int32 nPerDomCarta { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomActual")]
        public Int32 nPerDomActual { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerDomStatus")]
        public Int32 nPerDomStatus { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nUbiCodigo")]
        public Int32 nUbiCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nUbiGeoCodigo")]
        public Int32 nUbiGeoCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerDomFullDireccion")]
        public string cPerDomFullDireccion { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dEffDate")]
        public DateTime dEffDate { get; set; }
    }
}
