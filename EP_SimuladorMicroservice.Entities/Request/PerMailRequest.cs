using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Request
{
    public class PerMailRequest : OperationRequest<PerMailEntity>
    {
    }
    public class PerMailItemRequest : FilterItemRequest<PerMailFilter, PerMailFilterItemType>
    {
    }
    public class PerMailLstItemRequest : FilterLstItemRequest<PerMailFilter, PerMailFilterItemType>
    {
    }
}
