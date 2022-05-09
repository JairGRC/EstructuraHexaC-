using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Entities.Request;
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
    public class PersonaDomain
    {
        #region MEF
        [Import]
        private IPersonaRepository _PersonaRepository { get; set; }
        #endregion
        #region Constructor 
        public PersonaDomain ()
        {
            _PersonaRepository = MEFContainer.Container.GetExport<IPersonaRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePersona(PersonaEntity Persona)
        {
            long id = 0;
            bool exito = false;
            using (TransactionScope tx=new TransactionScope())
            {
                id = _PersonaRepository.Insert(Persona);
                if(id==0)
                {
                    throw new FailAddPersonaHeaderException();
                }
                else
                {
                    exito = true;
                }
                if (exito) tx.Complete();
            }
            return id > 0;
        }
        public bool EditPersona(PersonaEntity Persona)
        {
            using(TransactionScope tx=new TransactionScope())
            {
                if (_PersonaRepository.Update(Persona))
                {
                    tx.Complete();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePersona(string nConstcodigo)
        {
            bool exito = false;
            PersonaEntity personaFound = _PersonaRepository.GetItem(
                new PersonaFilter() 
                { 
                nConstCodigo= nConstcodigo
                },PersonaFilterItemType.BycPerCodigo);
            exito = _PersonaRepository.Delete(nConstcodigo);
            return exito;
        }
        public PersonaEntity GetBycPerCodigo(string nConstCodigo)
        {
            PersonaEntity persona = null;
            persona = _PersonaRepository.GetItem(
                new PersonaFilter()
                { 
                nConstCodigo=nConstCodigo
                },PersonaFilterItemType.BycPerCodigo);
            return persona;
        }
        public IEnumerable<PersonaEntity> GetByList(PersonaFilter filter,
            PersonaFilterListType filterType,Pagination pagination)
        {
            //PernameLstItemResponse response = new PernameLstItemResponse();
            //PernameFilterListType filterlist=new PernameFilterListType();
            //new PernameDomain().GetByList(filter.nConstCodigo)
            List<PersonaEntity> lst = null;
            List<PernameEntity> pernames = null;
            PernameLstItemRequest request = new PernameLstItemRequest()
            {
                Filter = new PernameFilter() { },
                FilterType = (PernameFilterItemType)PernameFilterListType.ByListID
            };


            lst = _PersonaRepository.GetLstItem(filter, filterType, pagination).ToList();
            pernames = (List<PernameEntity>)new PernameDomain().GetByList(request.Filter,
                                (PernameFilterListType)request.FilterType, request.Pagination);
            foreach (PersonaEntity item in lst)
            {

            }
            return lst;
        }
        #endregion
    }
}
