
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace EP_SimuladorMicroservice.Entities.Request
{
    public class PersonaRequest:OperationRequest<PersonaEntity>
    {
    }
    public class PersonaItemRequest : FilterItemRequest<PersonaFilter,PersonaFilterItemType>
    {
    }
    public class PersonaLstItemRequest : FilterLstItemRequest<PersonaFilter, PersonaFilterItemType>
    {
    }
}
