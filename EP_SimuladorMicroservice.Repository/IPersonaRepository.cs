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
    public interface IPersonaRepository:IGenericRepository<PersonaEntity>
    {
        long Insert(PersonaEntity item);
        PersonaEntity GetItem(PersonaFilter filter, PersonaFilterItemType filterType);
        IEnumerable<PersonaEntity> GetLstItem(PersonaFilter filter, 
            PersonaFilterListType filterType, Pagination pagination);
        bool Delete(string nConstcodigo);
    }
}
