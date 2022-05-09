using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PernaturalFilterItemType : byte
    {
        Undefined,
        BycPerCodigo
    }
    public enum PernaturalFilterListType : byte
    {
        Undefined,
        ByList,
        ByPagination,
        BycPerCodigo,
        ByCabecera,
        ByDependencia
    }
}
