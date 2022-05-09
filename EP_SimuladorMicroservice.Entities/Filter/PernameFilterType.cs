using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PernameFilterItemType : byte
    {
        Undefined,
        BycPerCodigo
    }
    public enum PernameFilterListType : byte
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
