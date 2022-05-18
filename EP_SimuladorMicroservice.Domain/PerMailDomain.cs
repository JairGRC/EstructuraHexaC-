using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Entities.Response;
using EP_SimuladorMicroservice.Exceptions;
using EP_SimuladorMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Util;

namespace EP_SimuladorMicroservice.Domain
{
    public class PerMailDomain
    {
        #region MEF
        [Import]
        private IPerMailRepository _PerMailRepository { get; set; }
        private PersonaDomain _PersonaDomain { get; set; }
        #endregion
        #region Constructor 
        public PerMailDomain()
        {
            _PerMailRepository = MEFContainer.Container.GetExport<IPerMailRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePerMail(PerMailEntity PerMail)
        {
            long id = 0;
            bool exito = false;
            using (TransactionScope tx = new TransactionScope())
            {
                    id = _PerMailRepository.Insert(PerMail);
                    if (id == 1)
                    {
                            exito = true; 
                    }
                    else
                    {
                      throw new FailAddPerMailHeaderException();
                    }
                if (exito) tx.Complete();
            }
            return exito;
        }
        public bool EditPerMail(PerMailEntity PerMail)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (_PerMailRepository.Update(PerMail))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePerMail(string cPerCodigo, string cPerMaiNombre)
        {
            bool exito = false;
            exito = _PerMailRepository.delete(cPerCodigo, cPerMaiNombre);
            return exito;
        }
        public PerMailEntity GetBycPerCodigo(string nConstCodigo)
        {
            PerMailEntity PerMail = null;
            PerMail = _PerMailRepository.GetItem(
                new PerMailFilter()
                {
                    cPerCodigo = nConstCodigo
                }, PerMailFilterItemType.BycPerCodigo);
            return PerMail;
        }
        public IEnumerable<PerMailEntity> GetByList(PerMailFilter filter,
            PerMailFilterListType filterType, Pagination pagination)
        {
            List<PerMailEntity> lst = null;
            lst = _PerMailRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }
        #endregion
    }
}
