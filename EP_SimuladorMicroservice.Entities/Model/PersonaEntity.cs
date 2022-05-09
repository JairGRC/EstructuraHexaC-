using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PersonaEntity:BaseEntity
    {
        [DataMember(EmitDefaultValue =false,Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        public virtual List<PernameEntity> Pername { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "cPerApellido")]
        public string cPerApellido { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "EmitDefaultValue")]
        public string cPerApellPat { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "EmitDefaultValue")]
        public string cPerNombre { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerNacimiento")]
        public DateTime dPerNacimiento { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerTipo")]
        public Int32 nPerTipo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerEstado")]
        public Int32 nPerEstado { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "cUbiGeoCodigo")]
        public string cUbiGeoCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nUbiGeoCodigo")]
        public Int32 nUbiGeoCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerDate")]
        public DateTime dPerDate { get; set; }
    }
}
