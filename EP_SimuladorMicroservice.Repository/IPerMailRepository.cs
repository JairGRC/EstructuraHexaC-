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
    public interface IPerMailRepository : IGenericRepository<PerMailEntity>
    {
        long Insert(PerMailEntity item);
        bool delete(string cPerCodigo, string cPerMaiNombre);
        PerMailEntity GetItem(PerMailFilter filter, PerMailFilterItemType filterType);
        IEnumerable<PerMailEntity> GetLstItem(PerMailFilter filter,
            PerMailFilterListType filterType, Pagination pagination);
    }
}
