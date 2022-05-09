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
    public interface IPerDomicilioRepository : IGenericRepository<PerDomicilioEntity>
    {
        long Insert(PerDomicilioEntity item);
        PerDomicilioEntity GetItem(PerDomicilioFilter filter, PerDomicilioFilterItemType filterType);
        IEnumerable<PerDomicilioEntity> GetLstItem(PerDomicilioFilter filter,
            PerDomicilioFilterListType filterType, Pagination pagination);
    }
}
