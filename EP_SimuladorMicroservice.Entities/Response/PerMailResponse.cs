using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PerMailResponse : ItemResponse<bool>
    {

    }
    public class PerMailItemResponse : ItemResponse<PerMailEntity>
    {
    }
    public class PerMailLstItemResponse : LstItemResponse<PerMailEntity>
    {
    }
}
