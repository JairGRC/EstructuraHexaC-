using System;
using System.Collections.Generic;
using System.Text;

namespace EP_SimuladorMicroservice.Exceptions
{
    public class CustomException : ApplicationException
    {
        public virtual string CustomMessage { get; }
    }
}
