using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PertelefonoResponse : ItemResponse<bool>
    {

    }
    public class PertelefonoItemResponse : ItemResponse<PertelefonoEntity>
    {
    }
    public class PertelefonoLstItemResponse : LstItemResponse<PertelefonoEntity>
    {
    }
}
