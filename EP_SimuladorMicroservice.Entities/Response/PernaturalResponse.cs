using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PernaturalResponse : ItemResponse<bool>
    {

    }
    public class PernaturalItemResponse : ItemResponse<PernaturalEntity>
    {
    }
    public class PernaturalLstItemResponse : LstItemResponse<PernaturalEntity>
    {
    }
}
