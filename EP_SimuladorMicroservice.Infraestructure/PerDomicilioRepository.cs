using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Infraestructure
{
    [Export(typeof(IPerDomicilioRepository))]
    public class PerDomicilioRepository : BaseRepository, IPerDomicilioRepository
    {
        #region Constructor
        [ImportingConstructor]
        public PerDomicilioRepository(IConnectionFactory cn) : base(cn)
        {

        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PerDomicilioEntity GetItem(PerDomicilioFilter filter, PerDomicilioFilterItemType filterType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PerDomicilioEntity> GetLstItem(PerDomicilioFilter filter, PerDomicilioFilterListType filterType, Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public long Insert(PerDomicilioEntity item)
        {
            throw new NotImplementedException();
        }

        public bool Update(PerDomicilioEntity item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
