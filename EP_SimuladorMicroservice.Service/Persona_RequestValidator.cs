using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using System;


namespace EP_SimuladorMicroservice.Service.Validators
{
    public static class Persona_RequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this PersonaResponse response, PersonaRequest request)
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
        public static void InitializeResponse(this PersonaResponse response, PersonaRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this PersonaItemResponse response, PersonaItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this PersonaLstItemResponse response, PersonaLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
