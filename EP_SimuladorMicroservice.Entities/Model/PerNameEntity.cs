using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PernameEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerFecEfectiva")]
        public DateTime dPerFecEfectiva { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerApellPaterno")]
        public string cPerApellPaterno { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerApellMaterno")]
        public string cPerApellMaterno { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerPriNombre")]
        public string cPerPriNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerSegNombre")]
        public string cPerSegNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerTerNombre")]
        public string cPerTerNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerTratamiento")]
        public int nPerTratamiento { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cPerNombreCompleto")]
        public string cPerNombreCompleto { get; set; }

    }
}
