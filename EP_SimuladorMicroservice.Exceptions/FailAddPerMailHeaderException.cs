using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Exceptions
{
     public  class FailAddPerMailHeaderException : CustomException
    {
        public override string CustomMessage
        {
            get
            {
                return "Error al insertar PerMail, No existe codigo Persona o parametros mal ingresados";
            }
        }
    }
}
