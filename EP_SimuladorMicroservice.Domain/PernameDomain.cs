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
    public class PernameDomain
    {
        #region MEF
        [Import]
        private IPernameRepository _PernameRepository { get; set; }
        private PersonaDomain _PersonaDomain { get; set; }
        #endregion
        #region Constructor 
        public PernameDomain()
        {
            _PernameRepository = MEFContainer.Container.GetExport<IPernameRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePername(PernameEntity Pername)
        {
            long id = 0;
            
            bool exito = false;
            using (TransactionScope tx = new TransactionScope())
            {
                //PersonaItemResponse response = new PersonaItemResponse();
                //response.Item = new PersonaDomain().GetBycPerCodigo(Pername.cPerCodigo);
                //if (response.Item == null)
                //{
                //    throw new FailAddPernamePersonaException();
                //}
                //else
                //{
                    id = _PernameRepository.Insert(Pername);
                    if (id == 0)
                    {
                        throw new FailAddPernameHeaderException();
                    }
                    else
                    {
                        exito = true;
                    }
                    if (exito) tx.Complete();
                //}
                
            }
            return id > 0;
        }
        public bool EditPername(PernameEntity Pername)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (_PernameRepository.Update(Pername))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePername(string nConstcodigo,DateTime dPerFecEfectiva)
        {
            bool exito = false;
            exito = _PernameRepository.delete(nConstcodigo, dPerFecEfectiva);
            return exito;
        }
        public PernameEntity GetBycPerCodigo(string nConstCodigo)
        {
            PernameEntity Pername = null;
            Pername = _PernameRepository.GetItem(
                new PernameFilter()
                {
                    nConstCodigo = nConstCodigo
                }, PernameFilterItemType.BycPerCodigo);
            return Pername;
        }
        public IEnumerable<PernameEntity> GetByList(PernameFilter filter,
            PernameFilterListType filterType, Pagination pagination)
        {
            List<PernameEntity> lst = null;
            lst = _PernameRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }

        
        #endregion
    }
}
