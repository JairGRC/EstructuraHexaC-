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
        private IPernameRepository _PerNameRepository { get; set; }
        private IPernaturalRepository _PernaturalRepository { get; set; }
        private IPerMailRepository _PerMailRepository { get; set; }
        #endregion
        #region Constructor 
        public PersonaDomain ()
        {
            _PersonaRepository = MEFContainer.Container.GetExport<IPersonaRepository>();
            _PertelefonoRepository = MEFContainer.Container.GetExport<IPertelefonoRepository>();
            _PerNameRepository = MEFContainer.Container.GetExport<IPernameRepository>();
            _PernaturalRepository= MEFContainer.Container.GetExport<IPernaturalRepository>();
            _PerMailRepository = MEFContainer.Container.GetExport<IPerMailRepository>();
        }
        #endregion
        #region Method Publics 
        public bool CreatePersona(PersonaEntity Persona)
        {
            long id = 0;
            long Pernameexito = 0;
            long PerTelefonoexito = 0;
            long Pernaturalexito = 0;
            long PermailExito = 0;
            bool exito = false;
            using (TransactionScope tx=new TransactionScope())
            {
                id = _PersonaRepository.Insert(Persona);
                if (id == 0)
                {
                    throw new FailAddPersonaHeaderException();
                }
                else
                {
                    if (Persona.Pername != null)
                    {
                        foreach (var Pername in Persona.Pername)
                        {
                            Pername.cPerCodigo = Convert.ToString(id);
                            Pernameexito=_PerNameRepository.Insert(Pername);
                            if(Pernameexito<=0)
                            {
                                throw new FailAddPernameHeaderException();
                            }
                        }
                    }
                    if(Persona.Pertelefono != null)
                    {
                        foreach (var pertelefono in Persona.Pertelefono)
                        {
                            pertelefono.cPerCodigo = Convert.ToString(id);
                            PerTelefonoexito = _PertelefonoRepository.Insert(pertelefono);
                            if (PerTelefonoexito <= 0)
                            {
                                throw new FailAddPertelefonoHeaderException();
                            }
                        }
                    }
                    if (Persona.Pernatural != null)
                    {
                        Persona.Pernatural.cPerCodigo= Convert.ToString(id);
                        Pernaturalexito = _PernaturalRepository.Insert(Persona.Pernatural);
                        if(Pernaturalexito<=0)
                        {
                            throw new FailAddPernaturalHeaderException();
                        }
                    }
                    if(Persona.Permail!=null)
                    {
                        foreach(var Permail in Persona.Permail)
                        {
                            Permail.cPerCodigo = Convert.ToString(id);
                            PermailExito = _PerMailRepository.Insert(Permail);
                            if (PermailExito <= 0)
                            {
                                throw new FailAddPerMailHeaderException();
                            }
                        }
                    }
                        //if(Persona.Pername!=null)
                        //{
                        //    foreach (var Pername in Persona.Pername)
                        //    {
                        //        List<PernameEntity> lspername = null;
                        //        PernameLstItemRequest requestName = new PernameLstItemRequest()
                        //        {
                        //            Filter = new PernameFilter()
                        //            {
                        //                nConstCodigo = Convert.ToString(id)
                        //            },
                        //            FilterType = (PernameFilterItemType)PernameFilterListType.ByListID
                        //        };
                        //        lspername = _PerNameRepository.GetLstItem(requestName.Filter, (PernameFilterListType)requestName.FilterType, null).ToList();
                        //        //bool hola = lspername.Exists(x => x.dPerFecEfectiva == Pername.dPerFecEfectiva);
                        //        if()
                        //        if (!lspername.Exists(x => x.dPerFecEfectiva == Pername.dPerFecEfectiva))
                        //        {
                        //            Pername.cPerCodigo = Convert.ToString(id);
                        //            _PerNameRepository.Insert(Pername);
                        //        }
                        //    }
                        //}

                    //if (Persona.Pertelefono != null)
                    //{
                    //    foreach (var pertelefono in Persona.Pertelefono)
                    //    {
                    //        List<PertelefonoEntity> lsperTel = null;
                    //        PertelefonoLstItemRequest requestPerTel = new PertelefonoLstItemRequest()
                    //        {
                    //            Filter = new PertelefonoFilter()
                    //            {
                    //                nConstCodigo = Convert.ToString(id)
                    //            },
                    //            FilterType = (PertelefonoFilterItemType)PertelefonoFilterListType.BycPerCodigo
                    //        };
                    //        lsperTel = _PertelefonoRepository.GetLstItem(requestPerTel.Filter, (PertelefonoFilterListType)requestPerTel.FilterType, null).ToList();
                    //        if (!lsperTel.Exists(x => x.cPerTelNumero == pertelefono.cPerTelNumero))
                    //        {
                    //            pertelefono.cPerCodigo = Convert.ToString(id);
                    //            _PertelefonoRepository.Insert(pertelefono);
                    //        }
                    //    }
                    //}
                    //if(Persona.Pernatural != null)
                    //{
                    //    PernaturalEntity Pernatural = null;
                    //    Pernatural = _PernaturalRepository.GetItem(
                    //        new PernaturalFilter()
                    //        {
                    //            nConstCodigo = Convert.ToString(id)
                    //        }, PernaturalFilterItemType.BycPerCodigo);

                    //   if(Pernatural)
                    //        if (!lsperTel.Exists(x => x.cPerTelNumero == pertelefono.cPerTelNumero))
                    //        {
                    //            pertelefono.cPerCodigo = Convert.ToString(id);
                    //            _PertelefonoRepository.Insert(pertelefono);
                    //        }

                    //}
                    exito = true;
            }
                if (exito) tx.Complete();
            }
            return id > 0;
        }
        public bool EditPersona(PersonaEntity Persona)
        {
            //bool flag = true;
            bool exitoPersona = false;
            bool exitoPername = false;
            bool exitoPerTelefono = false;
            bool exitoPerNatural = false;
            bool exitoPermail = false;
            long createPername = 0;
            long createPerTelefono = 0;
            long createPerNatural = 0;
            long createPermail = 0;
            using (TransactionScope tx=new TransactionScope())
            {
                exitoPersona = _PersonaRepository.Update(Persona);
                if(exitoPersona)
                {
                    if (Persona.Pername != null)
                    {
                        foreach(var pername in Persona.Pername)
                        {
                            exitoPername = _PerNameRepository.Update(pername);
                            if (!exitoPername)
                            {
                                createPername = _PerNameRepository.Insert(pername);
                                if (createPername <= 0)
                                {
                                    exitoPersona = false;
                                    throw new FailAddPernameHeaderException();
                                }

                            }
                        }
                    }
                    if (Persona.Pertelefono != null)
                    {
                        foreach (var pertelefono in Persona.Pertelefono)
                        {
                            exitoPerTelefono = _PertelefonoRepository.Update(pertelefono);
                            if (!exitoPerTelefono)
                            {
                                createPerTelefono = _PertelefonoRepository.Insert(pertelefono);
                                if (createPerTelefono <= 0)
                                {
                                    exitoPersona = false;
                                    throw new FailAddPertelefonoHeaderException();
                                }
                            }
                        }
                    }
                    if (Persona.Pernatural != null)
                    {
                        exitoPerNatural = _PernaturalRepository.Update(Persona.Pernatural);
                        if (!exitoPerNatural)
                        {
                            createPerNatural = _PernaturalRepository.Insert(Persona.Pernatural);
                            if (createPerNatural <= 0)
                            {
                                exitoPersona = false;
                                throw new FailAddPernaturalHeaderException();
                            }
                        }
                    }
                    if (Persona.Permail != null)
                    {
                        foreach (var permail in Persona.Permail)
                        {
                            exitoPermail = _PerMailRepository.Update(permail);
                            if (!exitoPermail)
                            {
                                createPermail = _PerMailRepository.Insert(permail);
                                if (createPermail <= 0)
                                {
                                    exitoPersona = false;
                                    throw new FailAddPerMailHeaderException();
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
                if (exitoPersona)
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

                List<PernameEntity> pername = new List<PernameEntity>();
                PernameLstItemRequest requestName = new PernameLstItemRequest()
                {
                    Filter = new PernameFilter()
                    {
                        nConstCodigo = persona.cPerCodigo
                    },
                    FilterType = (PernameFilterItemType)PernameFilterListType.ByListID
                };
                pername = _PerNameRepository.GetLstItem(requestName.Filter, (PernameFilterListType)requestName.FilterType, null).ToList();
                if (pername.Count > 0)
                {
                    persona.Pername = new List<PernameEntity>(pername);
                }
                PernaturalEntity pernatural = new PernaturalEntity();
                
                pernatural = _PernaturalRepository.GetItem(
                    new PernaturalFilter()
                    {
                        nConstCodigo = persona.cPerCodigo
                    }, PernaturalFilterItemType.BycPerCodigo);
             
                if (pernatural != null)
                {
                    persona.Pernatural = pernatural;
                }
                List<PerMailEntity> perMail = new List<PerMailEntity>();
                PerMailLstItemRequest requestPermail = new PerMailLstItemRequest()
                {
                    Filter = new PerMailFilter()
                    {
                        cPerCodigo= persona.cPerCodigo
                    },
                    FilterType = (PerMailFilterItemType)PerMailFilterListType.BycPerCodigo
                };
                perMail= _PerMailRepository.GetLstItem(requestPermail.Filter, (PerMailFilterListType)requestPermail.FilterType, null).ToList();
                if (perMail != null)
                {
                    persona.Permail = new List<PerMailEntity>(perMail);
                }
            }
            return persona;
        }
        public IEnumerable<PersonaEntity> GetByList(PersonaFilter filter,
            PersonaFilterListType filterType,Pagination pagination)
        {
            List<PersonaEntity> lst = new List<PersonaEntity>();
            lst = _PersonaRepository.GetLstItem(filter, filterType, pagination).ToList();

            if (lst.Count > 0)
            {
                foreach (var lstPersona in lst)
                {
                    List<PertelefonoEntity> pertelefonos = new List<PertelefonoEntity>();
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
                    List<PernameEntity> pername = new List<PernameEntity>();
                    PernameLstItemRequest requestName = new PernameLstItemRequest()
                    {
                        Filter = new PernameFilter()
                        {
                            nConstCodigo = lstPersona.cPerCodigo
                        },
                        FilterType = (PernameFilterItemType)PernameFilterListType.ByListID
                    };
                    pername = _PerNameRepository.GetLstItem(requestName.Filter, (PernameFilterListType)requestName.FilterType, null).ToList();
                    if (pername.Count > 0)
                    {
                        lstPersona.Pername = new List<PernameEntity>(pername);
                    }
                    PernaturalEntity pernatural = new PernaturalEntity();
                    pernatural = _PernaturalRepository.GetItem(
                        new PernaturalFilter()
                        {
                            nConstCodigo = lstPersona.cPerCodigo
                        }, PernaturalFilterItemType.BycPerCodigo);

                    if (pernatural != null)
                    {
                        lstPersona.Pernatural = pernatural;
                    }
                    List<PerMailEntity> perMail = new List<PerMailEntity>();
                    PerMailLstItemRequest requestPermail = new PerMailLstItemRequest()
                    {
                        Filter = new PerMailFilter()
                        {
                            cPerCodigo = lstPersona.cPerCodigo
                        },
                        FilterType = (PerMailFilterItemType)PerMailFilterListType.ByList
                    };
                    perMail = _PerMailRepository.GetLstItem(requestPermail.Filter, (PerMailFilterListType)requestPermail.FilterType, null).ToList();
                    if (perMail != null)
                    {
                        lstPersona.Permail = new List<PerMailEntity>(perMail);
                    }
                }
            }
            return lst;
        }
        #endregion
    }
}
