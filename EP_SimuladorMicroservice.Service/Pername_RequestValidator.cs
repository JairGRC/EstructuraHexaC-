﻿using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Service
{
    public static class Pername_RequestValidator
    {
        #region Validate 
        public static void ValidateRequest(this PernameResponse response, PernameRequest request)
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
        public static void InitializeResponse(this PernameResponse response, PernameRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this PernameItemResponse response, PernameItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
        }
        public static void InitializeResponse(this PernameLstItemResponse response, PernameLstItemRequest request)
        {
            response.Ticket = request.Ticket;
            response.ServerName = request.ServerName;
            response.UserName = request.UserName;
            response.Pagination = request.Pagination;
        }
        #endregion
    }
}
