using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EP_SimuladorMicroservice.Entities.Model
{
    [DataContract]
    public class PerImagenEntity
    {
        [DataMember(EmitDefaultValue = false, Name = "cPerCodigo")]
        public string cPerCodigo { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nPerTipImagen")]
        public Int32 nPerTipImagen { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "iPerImaFoto")]
        public string iPerImaFoto  { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dPerImaFecRegistro")]
        public DateTime dPerImaFecRegistro { get; set; }

    }
}
