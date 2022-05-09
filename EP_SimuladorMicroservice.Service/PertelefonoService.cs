using EP_SimuladorMicroservice.Domain;
using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using EP_SimuladorMicroservice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Service
{
    public class PertelefonoService
    {
        #region Public Methods
        public PertelefonoResponse Execute(PertelefonoRequest request)
        {
            PertelefonoResponse response = new PertelefonoResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.Operation)
                    {
                        case Operation.Undefined:
                            break;
                        case Operation.Add:
                            response.Item = new PertelefonoDomain().CreatePertelefono(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new PertelefonoDomain().EditPertelefono(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new PertelefonoDomain().DeletePertelefono(request.Item.cPerCodigo);
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
                response.LstError.Add(ex.Message);
            }
            return response;
        }
        public PertelefonoItemResponse GetPertelefono(PertelefonoItemRequest request)
        {
            PertelefonoItemResponse response = new PertelefonoItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case PertelefonoFilterItemType.Undefined:
                            break;
                        case PertelefonoFilterItemType.BycPerCodigo:
                            response.Item = new PertelefonoDomain().GetBycPerCodigo(request.Filter.nConstCodigo);
                            break;
                        //case PertelefonoFilterItemType.ByList:
                        //    response.Item = new PertelefonoDomain().GetByList();
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
        public PertelefonoLstItemResponse GetLstPertelefono(PertelefonoLstItemRequest request)
        {
            PertelefonoLstItemResponse response = new PertelefonoLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case (PertelefonoFilterItemType)PertelefonoFilterListType.Undefined:
                            break;
                        case (PertelefonoFilterItemType)PertelefonoFilterListType.ByList:
                            response.LstItem = new PertelefonoDomain().GetByList(request.Filter,
                                (PertelefonoFilterListType)request.FilterType, request.Pagination);
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
