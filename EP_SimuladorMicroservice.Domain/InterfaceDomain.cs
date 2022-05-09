using System.Transactions;
using System.Linq;
using EP_SimuladorMicroservice.Repository;
using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Exceptions;
using System.Collections.Generic;
using System.Composition;
using Util;
using System;
namespace EP_SimuladorMicroservice.Domain
{
    public class InterfaceDomain
    {
        #region MEF
        //This attribute declares something to be an import; that is, it will be filled by the composition engine when the object is composed.        
        [Import]
        private IInterfaceRepository _InterfaceRepository { get; set; }
        #endregion
        #region Constructor
        public InterfaceDomain()
        {
            //MEF will create an instance of the exported class and assign it to the import property for you.
            _InterfaceRepository = MEFContainer.Container.GetExport<IInterfaceRepository>();
        }
        #endregion
        #region Methods Public 
        public bool CreateInterface(InterfaceEntity Interface)
        {
            long id = 0;
            bool exito = false;
#if !debug
            using (TransactionScope tx = new TransactionScope())
            {
#endif
                id = _InterfaceRepository.Insert(Interface);
                if (id == 0)
                {
                    throw new FailAddInterfaceHeaderException();
                }
                else
                {
                    exito = true;
                }
                if (exito) tx.Complete();
            }
            return id > 0;
        }
        public bool EditInterface(InterfaceEntity Interface)
        {
#if !debug
            using (TransactionScope tx = new TransactionScope())
            {
#endif
                if (_InterfaceRepository.Update(Interface))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<InterfaceEntity> GetByPagination(InterfaceFilter filter, InterfaceFilterLstItemType filterType, Pagination pagination)
        {
            List<InterfaceEntity> lst = null;
            lst = _InterfaceRepository.GetLstItem(filter, filterType, pagination).ToList();
            return lst;
        }
        #endregion
    }
}

