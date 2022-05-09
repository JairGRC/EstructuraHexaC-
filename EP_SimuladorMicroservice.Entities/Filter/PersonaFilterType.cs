using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PersonaFilterItemType :byte
    {
        Undefined,
        BycPerCodigo
    }
    public enum PersonaFilterListType : byte
    {
        Undefined,
        ByList,
        ByListID,
        ByPagination,
        BycPerCodigo,
        ByCabecera,
        ByDependencia
    }
}
