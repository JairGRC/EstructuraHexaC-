using System;
using System.Collections.Generic;
using System.Text;

namespace EP_SimuladorMicroservice.Entities
{
    public abstract class BaseEntity
    {
        public DateTime DateReg { get; set; }
        public DateTime DateMod { get; set; }
        public string UsrReg { get; set; }
        public string UsrMod { get; set; }
    }
}
