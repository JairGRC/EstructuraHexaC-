using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Repository
{
    public interface IPernaturalRepository : IGenericRepository<PernaturalEntity>
    {
        long Insert(PernaturalEntity item);
        PernaturalEntity GetItem(PernaturalFilter filter, PernaturalFilterItemType filterType);
        IEnumerable<PernaturalEntity> GetLstItem(PernaturalFilter filter,
            PernaturalFilterListType filterType, Pagination pagination);
    }
}
