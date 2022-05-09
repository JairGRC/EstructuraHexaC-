using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PernameResponse : ItemResponse<bool>
    {

    }
    public class PernameItemResponse : ItemResponse<PernameEntity>
    {
    }
    public class PernameLstItemResponse : LstItemResponse<PernameEntity>
    {
    }
}
