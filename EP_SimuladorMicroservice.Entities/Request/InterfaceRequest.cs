using System;
using System.Collections.Generic;
using System.Text;


namespace EP_SimuladorMicroservice.Entities 

{

public class InterfaceRequest : OperationRequest<InterfaceEntity>
{
}

public class InterfaceItemRequest : FilterItemRequest<InterfaceFilter, InterfaceFilterItemType>
{
}

public class InterfaceLstItemRequest : FilterLstItemRequest<InterfaceFilter, InterfaceFilterLstItemType>
{
}

}

