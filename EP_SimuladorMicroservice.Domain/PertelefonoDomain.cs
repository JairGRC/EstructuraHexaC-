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
    public class PertelefonoDomain
    {
        #region MEF
        [Import]
        private IPertelefonoRepository _PertelefonoRepository { get; set; }
        #endregion
        #region Constructor 
        public PertelefonoDomain()
        {
            _PertelefonoRepository = MEFContainer.Container.GetExport<IPertelefonoRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePertelefono(PertelefonoEntity Pertelefono)
        {
            long id = 0;
            bool exito = false;
            using (TransactionScope tx = new TransactionScope())
            {
                PersonaItemResponse response = new PersonaItemResponse();
                response.Item = new PersonaDomain().GetBycPerCodigo(Pertelefono.cPerCodigo);
                if (response.Item == null)
                {
                    throw new FailAddPernamePertelefonoException();
                }
                else
                {
                    id = _PertelefonoRepository.Insert(Pertelefono);
                    if (id == 0)
                    {
                        throw new FailAddPertelefonoHeaderException();
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
        public bool EditPertelefono(PertelefonoEntity Pertelefono)
        {
            using (TransactionScope tx = new TransactionScope())
            {
                if (_PertelefonoRepository.Update(Pertelefono))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePertelefono(string nConstcodigo)
        {
            bool exito = false;
            PertelefonoEntity PertelefonoFound = _PertelefonoRepository.GetItem(
                new PertelefonoFilter()
                {
                    nConstCodigo = nConstcodigo
                }, PertelefonoFilterItemType.BycPerCodigo);
            exito = _PertelefonoRepository.Delete(nConstcodigo);
            return exito;
        }
        public PertelefonoEntity GetBycPerCodigo(string nConstCodigo)
        {
            PertelefonoEntity Pertelefono = null;
            Pertelefono = _PertelefonoRepository.GetItem(
                new PertelefonoFilter()
                {
                    nConstCodigo = nConstCodigo
                }, PertelefonoFilterItemType.BycPerCodigo);
            return Pertelefono;
        }
        public IEnumerable<PertelefonoEntity> GetByList(PertelefonoFilter filter,
            PertelefonoFilterListType filterType, Pagination pagination)
        {
            List<PertelefonoEntity> lst = null;
            lst = _PertelefonoRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }
        #endregion
    }
}
