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
    public class PernameService
    {
        #region Public Methods
        public PernameResponse Execute(PernameRequest request)
        {
            PernameResponse response = new PernameResponse();
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
                            response.Item = new PernameDomain().CreatePername(request.Item);
                            break;
                        case Operation.Edit:
                            response.Item = new PernameDomain().EditPername(request.Item);
                            break;
                        case Operation.Delete:
                            response.Item = new PernameDomain().DeletePername(request.Item.cPerCodigo,request.Item.dPerFecEfectiva);
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
        public PernameItemResponse GetPername(PernameItemRequest request)
        {
            PernameItemResponse response = new PernameItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case PernameFilterItemType.Undefined:
                            break;
                        case PernameFilterItemType.BycPerCodigo:
                            response.Item = new PernameDomain().GetBycPerCodigo(request.Filter.nConstCodigo);
                            break;
                        //case PernameFilterItemType.ByList:
                        //    response.Item = new PernameDomain().GetByList();
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
        public PernameLstItemResponse GetLstPername(PernameLstItemRequest request)
        {
            PernameLstItemResponse response = new PernameLstItemResponse();
            response.InitializeResponse(request);
            try
            {
                if (response.LstError.Count == 0)
                {
                    switch (request.FilterType)
                    {
                        case (PernameFilterItemType)PernameFilterListType.Undefined:
                            break;
                        case (PernameFilterItemType)PernameFilterListType.ByList:
                            response.LstItem = new PernameDomain().GetByList(request.Filter,
                                (PernameFilterListType)request.FilterType, request.Pagination);
                            break;
                        case (PernameFilterItemType)PernameFilterListType.ByListID:
                            response.LstItem = new PernameDomain().GetByList(request.Filter,
                                (PernameFilterListType)request.FilterType, request.Pagination);
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
