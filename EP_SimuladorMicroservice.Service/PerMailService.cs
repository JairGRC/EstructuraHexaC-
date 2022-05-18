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
    public class PerMailService
    {
        #region Public Methods
        public PerMailResponse Execute(PerMailRequest request)
        {
            PerMailResponse response = new PerMailResponse();
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
                            response.Item = new PerMailDomain().CreatePerMail(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new PerMailDomain().EditPerMail(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new PerMailDomain().DeletePerMail(request.Item.cPerCodigo, request.Item.cPerMaiNombre);
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


        public PerMailItemResponse GetPerMail(PerMailItemRequest request)
        {
            PerMailItemResponse response = new PerMailItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case PerMailFilterItemType.Undefined:
                            break;
                        //case PerMailFilterItemType.BycPerCodigo:
                        //    response.Item = new PerMailDomain().GetBycPerCodigo(request.Filter.nConstCodigo);
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
        public PerMailLstItemResponse GetLstPerMail(PerMailLstItemRequest request)
        {
            PerMailLstItemResponse response = new PerMailLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case (PerMailFilterItemType)PerMailFilterListType.Undefined:
                            break;
                        case (PerMailFilterItemType)PerMailFilterListType.ByList:
                            response.LstItem = new PerMailDomain().GetByList(request.Filter,
                                (PerMailFilterListType)request.FilterType, request.Pagination);
                            break;
                        case (PerMailFilterItemType)PerMailFilterListType.BycPerCodigo:
                            response.LstItem = new PerMailDomain().GetByList(request.Filter,
                                (PerMailFilterListType)request.FilterType, request.Pagination);
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
