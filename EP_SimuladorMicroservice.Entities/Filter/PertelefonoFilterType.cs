using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PertelefonoFilterItemType : byte
    {
        Undefined,
        BycPerCodigo
    }
    public enum PertelefonoFilterListType : byte
    {
        Undefined,
        ByList,
        ByPagination,
        BycPerCodigo,
        ByCabecera,
        ByDependencia
    }
}
