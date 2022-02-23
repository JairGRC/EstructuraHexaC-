using System;
using System.Collections.Generic;
using System.Text;
namespace EP_SimuladorMicroservice.Exceptions
{
public class FailAddInterfaceHeaderException : CustomException
{
public override string CustomMessage
{
get
{
return "Interface Fail inserting header";
}
}
}
}

