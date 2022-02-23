using EP_SimuladorMicroservice.Entities; 
using System.Linq;  
namespace EP_SimuladorMicroservice.Service.Validators 
{ 
public static class Interface_RequestValidator 
{ 
#region Validate 
public static void ValidateRequest(this InterfaceResponse response, InterfaceRequest request) 
{ 
if (request.Item == null) 
{ 
response.LstError.Add("Se requiere la entidad Interface"); 
} 
if (string.IsNullOrEmpty(request.ServerName)) 
{ 
response.LstError.Add("No se identifico el servidor de origen para la solicitud"); 
} 
if (string.IsNullOrEmpty(request.UserName)) 
{ 
response.LstError.Add("No se identifico el usuario que realizo la solicitud"); 
} 
} 
#endregion 
#region Initialize 
public static void InitializeResponse(this InterfaceResponse response, InterfaceRequest request) 
{ 
response.Ticket = request.Ticket; 
response.ServerName = request.ServerName; 
response.UserName = request.UserName; 
} 
public static void InitializeResponse(this InterfaceItemResponse response, InterfaceItemRequest request)
{
response.Ticket = request.Ticket;
response.ServerName = request.ServerName;
response.UserName = request.UserName;
}
public static void InitializeResponse(this InterfaceLstItemResponse response, InterfaceLstItemRequest request)
{
response.Ticket = request.Ticket;
response.ServerName = request.ServerName;
response.UserName = request.UserName;
response.Pagination = request.Pagination;
}
#endregion 
} 
} 

