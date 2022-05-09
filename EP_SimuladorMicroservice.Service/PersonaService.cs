using EP_SimuladorMicroservice.Domain;
using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using EP_SimuladorMicroservice.Exceptions;
using EP_SimuladorMicroservice.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Service
{
    public class PersonaService
    {
        #region Public Methods
        public PersonaResponse Execute(PersonaRequest request)
        {
            PersonaResponse response = new PersonaResponse();
            response.InitializeResponse(request);
            try
            {
                if(response.LstError.Count==0)
                {
                    switch (request.Operation)
                    {
                        case Operation.Undefined:
                            break;
                        case Operation.Add:
                            response.Item = new PersonaDomain().CreatePersona(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new PersonaDomain().EditPersona(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new PersonaDomain().DeletePersona(request.Item.cPerCodigo);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch(CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch(Exception ex)
            {
                response.LstError.Add(ex.Message);
            }
            return response;
        }
        public PersonaItemResponse GetPersona(PersonaItemRequest request)
        {
            PersonaItemResponse response = new PersonaItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case PersonaFilterItemType.Undefined:
                            break;
                        case PersonaFilterItemType.BycPerCodigo:
                            response.Item = new PersonaDomain().GetBycPerCodigo(request.Filter.nConstCodigo);
                            break;
                        //case PersonaFilterItemType.ByList:
                        //    response.Item = new PersonaDomain().GetByList();
                        //    break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;

        }
        public PersonaLstItemResponse GetLstPersona(PersonaLstItemRequest request)
        {
            PersonaLstItemResponse response = new PersonaLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case (PersonaFilterItemType)PersonaFilterListType.Undefined:
                            break;
                        case (PersonaFilterItemType)PersonaFilterListType.ByList:
                            response.LstItem = new PersonaDomain().GetByList(request.Filter,
                                (PersonaFilterListType)request.FilterType,request.Pagination);
                            break;
                        default:
                            break;
                    }
                    response.IsSuccess = true;
                }
            }
            catch (CustomException ex)
            {
                response.LstError.Add(ex.CustomMessage);
            }
            catch (Exception ex)
            {
                response.LstError.Add("Server Error");
            }
            return response;
        }
        #endregion
    }
}
