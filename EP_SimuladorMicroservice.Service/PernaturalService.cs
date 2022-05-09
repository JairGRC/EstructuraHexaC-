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
    public class PernaturalService
    {
        #region Public Methods
        public PernaturalResponse Execute(PernaturalRequest request)
        {
            PernaturalResponse response = new PernaturalResponse();
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
                            response.Item = new PernaturalDomain().CreatePernatural(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new PernaturalDomain().EditPernatural(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new PernaturalDomain().DeletePernatural(request.Item.cPerCodigo);
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
        public PernaturalItemResponse GetPernatural(PernaturalItemRequest request)
        {
            PernaturalItemResponse response = new PernaturalItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case PernaturalFilterItemType.Undefined:
                            break;
                        case PernaturalFilterItemType.BycPerCodigo:
                            response.Item = new PernaturalDomain().GetBycPerCodigo(request.Filter.nConstCodigo);
                            break;
                        //case PernaturalFilterItemType.ByList:
                        //    response.Item = new PernaturalDomain().GetByList();
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
        public PernaturalLstItemResponse GetLstPernatural(PernaturalLstItemRequest request)
        {
            PernaturalLstItemResponse response = new PernaturalLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case (PernaturalFilterItemType)PernaturalFilterListType.Undefined:
                            break;
                        case (PernaturalFilterItemType)PernaturalFilterListType.ByList:
                            response.LstItem = new PernaturalDomain().GetByList(request.Filter,
                                (PernaturalFilterListType)request.FilterType, request.Pagination);
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
