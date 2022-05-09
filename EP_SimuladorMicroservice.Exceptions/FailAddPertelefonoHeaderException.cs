﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Exceptions
{
    public class FailAddPertelefonoHeaderException : CustomException 
    {
        public override string CustomMessage
        {
            get
            {
                return "Error al insertar la datos del Telefono";
            }
        }
    }
}
