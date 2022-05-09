using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PerDomicilioResponse : ItemResponse<bool>
    {

    }
    public class PerDomicilioItemResponse : ItemResponse<PerDomicilioEntity>
    {
    }
    public class PerDomicilioLstItemResponse : LstItemResponse<PerDomicilioEntity>
    {
    }
}
