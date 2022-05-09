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
    public interface IPertelefonoRepository : IGenericRepository<PertelefonoEntity>
    {
        long Insert(PertelefonoEntity item);
        PertelefonoEntity GetItem(PertelefonoFilter filter, PertelefonoFilterItemType filterType);
        IEnumerable<PertelefonoEntity> GetLstItem(PertelefonoFilter filter,
            PertelefonoFilterListType filterType, Pagination pagination);
    }
}
