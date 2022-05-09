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
    public interface IPernameRepository : IGenericRepository<PernameEntity>
    {
        long Insert(PernameEntity item);
        PernameEntity GetItem(PernameFilter filter, PernameFilterItemType filterType);
        IEnumerable<PernameEntity> GetLstItem(PernameFilter filter,
            PernameFilterListType filterType, Pagination pagination);
    }
}
