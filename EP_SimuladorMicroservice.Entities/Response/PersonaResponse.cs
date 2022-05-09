using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Response
{
    public class PersonaResponse : ItemResponse<bool>
    {
       
    }
    public class PersonaItemResponse : ItemResponse<PersonaEntity>
    {
    }
    public class PersonaLstItemResponse : LstItemResponse<PersonaEntity>
    {
    }
}
