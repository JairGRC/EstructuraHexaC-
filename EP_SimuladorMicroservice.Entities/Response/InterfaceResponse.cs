using System;
using System.Collections.Generic;
using System.Text;


namespace EP_SimuladorMicroservice.Entities
{

    public class InterfaceResponse : ItemResponse<bool>
    {
    }

    public class InterfaceItemResponse : ItemResponse<InterfaceEntity>
    {
    }

    public class InterfaceLstItemResponse : LstItemResponse<InterfaceEntity>
    {
    }

}

