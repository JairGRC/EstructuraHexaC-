using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Entities.Filter
{
    public enum PerMailFilterItemType : byte
    {
        Undefined,
        BycPerCodigo,
        ByEdit
    }
    public enum PerMailFilterListType : byte
    {
        Undefined,
        ByList,
        ByPagination,
        BycPerCodigo,
        ByCabecera,
        ByDependencia
    }
}
