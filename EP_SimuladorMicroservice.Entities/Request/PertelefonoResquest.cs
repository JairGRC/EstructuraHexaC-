using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Request
{
    public class PertelefonoRequest : OperationRequest<PertelefonoEntity>
    {
    }
    public class PertelefonoItemRequest : FilterItemRequest<PertelefonoFilter, PertelefonoFilterItemType>
    {
    }
    public class PertelefonoLstItemRequest : FilterLstItemRequest<PertelefonoFilter, PertelefonoFilterItemType>
    {
    }
}
