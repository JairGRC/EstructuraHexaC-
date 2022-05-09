using System;
using System.Collections.Generic;
using System.Text;
using EP_SimuladorMicroservice.Entities;


namespace EP_SimuladorMicroservice.Repository
{

    public interface IInterfaceRepository : IGenericRepository<InterfaceEntity>
    {
        long Insert(InterfaceEntity item);
        InterfaceEntity GetItem(InterfaceFilter filter, InterfaceFilterItemType filterType);
        IEnumerable<InterfaceEntity> GetLstItem(InterfaceFilter filter, InterfaceFilterLstItemType filterType, Pagination pagination);
    }
}

