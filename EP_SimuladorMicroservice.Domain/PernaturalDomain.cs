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
    public class PernaturalDomain
    {
        #region MEF
        [Import]
        private IPernaturalRepository _PernaturalRepository { get; set; }
        #endregion
        #region Constructor 
        public PernaturalDomain()
        {
            _PernaturalRepository = MEFContainer.Container.GetExport<IPernaturalRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePernatural(PernaturalEntity Pernatural)
        {
            long id = 0;
            bool exito = false;
            using (TransactionScope tx = new TransactionScope())
            {
                PersonaItemResponse response = new PersonaItemResponse();
                response.Item = new PersonaDomain().GetBycPerCodigo(Pernatural.cPerCodigo);
                if (response.Item == null)
                {
                    throw new FailAddPernaturalPersonaException();
                }
                else
                {
                    id = _PernaturalRepository.Insert(Pernatural);
                    if (id == 0)
                    {
                        throw new FailAddPernaturalHeaderException();
                    }
                    else
                    {
                        exito = true;
                    }
                    if (exito) tx.Complete();
                }
                    
            }
            return id > 0;
        }
        public bool EditPernatural(PernaturalEntity Pernatural)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (_PernaturalRepository.Update(Pernatural))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePernatural(string nConstcodigo)
        {
            bool exito = false;
            PernaturalEntity PernaturalFound = _PernaturalRepository.GetItem(
                new PernaturalFilter()
                {
                    nConstCodigo = nConstcodigo
                }, PernaturalFilterItemType.BycPerCodigo);
            exito = _PernaturalRepository.Delete(nConstcodigo);
            return exito;
        }
        public PernaturalEntity GetBycPerCodigo(string nConstCodigo)
        {
            PernaturalEntity Pernatural = null;
            Pernatural = _PernaturalRepository.GetItem(
                new PernaturalFilter()
                {
                    nConstCodigo = nConstCodigo
                }, PernaturalFilterItemType.BycPerCodigo);
            return Pernatural;
        }
        public IEnumerable<PernaturalEntity> GetByList(PernaturalFilter filter,
            PernaturalFilterListType filterType, Pagination pagination)
        {
            List<PernaturalEntity> lst = null;
            lst = _PernaturalRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }
        #endregion
    }
}
