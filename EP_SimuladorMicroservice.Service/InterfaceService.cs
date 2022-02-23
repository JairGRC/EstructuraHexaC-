using System;
using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Domain;
using EP_SimuladorMicroservice.Service.Validators;
using EP_SimuladorMicroservice.Exceptions;
namespace EP_SimuladorMicroservice.Service
{
public class InterfaceService
{
#region Public Methods
public InterfaceResponse Execute(InterfaceRequest request)
{
InterfaceResponse response = new InterfaceResponse();
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
response.Item = new InterfaceDomain().CreateInterface(request.Item);
break;
case Operation.Edit:
response.Item = new InterfaceDomain().EditInterface(request.Item);
break;
case Operation.Delete:
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
public InterfaceItemResponse GetInterface(InterfaceItemRequest request)
{
InterfaceItemResponse response = new InterfaceItemResponse();        
response.InitializeResponse(request);
try
{
if (response.LstError.Count == 0)
{
switch (request.FilterType)
{
case InterfaceFilterItemType.Undefined:
break;
case InterfaceFilterItemType.ById:
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
public InterfaceLstItemResponse GetLstInterface(InterfaceLstItemRequest request)
{
InterfaceLstItemResponse response = new InterfaceLstItemResponse();
//response.ValidateRequest(request);
response.InitializeResponse(request);
try
{
if (response.LstError.Count == 0)
{
switch (request.FilterType)
{
case InterfaceFilterLstItemType.Undefined:
break;
case InterfaceFilterLstItemType.ByPagination:
response.LstItem = new InterfaceDomain().GetByPagination(request.Filter, request.FilterType, request.Pagination);
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

