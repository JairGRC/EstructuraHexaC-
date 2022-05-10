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
        private IPertelefonoRepository _PertelefonoRepository { get; set; }
        #endregion
        #region Constructor 
        public PersonaDomain ()
        {
            _PersonaRepository = MEFContainer.Container.GetExport<IPersonaRepository>();
            _PertelefonoRepository = MEFContainer.Container.GetExport<IPertelefonoRepository>();
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

            if (persona != null)
            {
                List<PertelefonoEntity> pertelefonos = new List<PertelefonoEntity>();
                PertelefonoLstItemResponse response = null;
                PertelefonoLstItemRequest request = new PertelefonoLstItemRequest()
                {
                    Filter = new PertelefonoFilter()
                    {
                        nConstCodigo = persona.cPerCodigo
                    },
                    FilterType = (PertelefonoFilterItemType)PertelefonoFilterListType.BycPerCodigo
                };


                pertelefonos = _PertelefonoRepository.GetLstItem(request.Filter, (PertelefonoFilterListType)request.FilterType, null).ToList();


                if (pertelefonos.Count > 0)
                {
                    persona.Pertelefono = new List<PertelefonoEntity>(pertelefonos);
                }
            }

            return persona;
        }
        public IEnumerable<PersonaEntity> GetByList(PersonaFilter filter,
            PersonaFilterListType filterType,Pagination pagination)
        {
            List<PersonaEntity> lst = new List<PersonaEntity>();
            lst = _PersonaRepository.GetLstItem(filter, filterType, pagination).ToList();

            if(lst.Count>0)
            {
                foreach (var lstPersona in lst)
                {
                    List<PertelefonoEntity> pertelefonos = new List<PertelefonoEntity>();
                    PertelefonoLstItemResponse response = null;
                    PertelefonoLstItemRequest request = new PertelefonoLstItemRequest()
                    {
                        Filter = new PertelefonoFilter()
                        {
                            nConstCodigo = lstPersona.cPerCodigo
                        },
                        FilterType = (PertelefonoFilterItemType)PertelefonoFilterListType.BycPerCodigo
                    };


                    pertelefonos = _PertelefonoRepository.GetLstItem(request.Filter, (PertelefonoFilterListType)request.FilterType, pagination).ToList();


                    if (pertelefonos.Count > 0)
                    {
                        lstPersona.Pertelefono = new List<PertelefonoEntity>(pertelefonos);
                    }
                }
            }

            return lst;
        }
        #endregion
    }
}
