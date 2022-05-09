using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PerDomicilioFilterItemType : byte
    {
        Undefined,
        BycPerCodigo
    }
    public enum PerDomicilioFilterListType : byte
    {
        Undefined,
        ByList,
        ByPagination,
        BycPerCodigo,
        ByCabecera,
        ByDependencia
    }
}
