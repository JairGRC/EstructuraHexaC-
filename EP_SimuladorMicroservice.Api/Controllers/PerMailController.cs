using EP_SimuladorMicroservice.Entities;
using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Model;
using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using EP_SimuladorMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP_SimuladorMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerMailController : ControllerBase
    {
        [HttpGet("GetByCodigo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo(string cPerCodigo)
        {
            PerMailLstItemResponse response = null;
            PerMailLstItemRequest request = new PerMailLstItemRequest()
            {
                Filter = new PerMailFilter()
                { 
                    cPerCodigo=cPerCodigo
                },
                FilterType = (PerMailFilterItemType)PerMailFilterListType.BycPerCodigo
            };
            try
            {
                response = new PerMailService().GetLstPerMail(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPost("PerMailCreate")]
        public IActionResult PerMailCreate([FromBody] PerMailEntity PerMail)
        {
            PerMailResponse response = null;
            PerMailRequest request = new PerMailRequest()
            {
                Item = PerMail,
                Operation = Operation.Add
            };
            try
            {
                response = new PerMailService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPut("PerMailEdit")]
        public IActionResult PerMailEdit([FromBody] PerMailEntity permail)
        {
            PerMailResponse response = null;
            PerMailRequest request = new PerMailRequest()
            {
                Item= permail,
                Operation =Operation.Edit
            };
            try
            {
                response = new PerMailService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

        [HttpPost("PerMailDelete")]
        public IActionResult PerMailDelete([FromBody] PerMailEntity PerMail)
        {
            PerMailResponse response = null;
            PerMailRequest request = new PerMailRequest()
            {
                Item = PerMail,
                Operation = Operation.Delete
            };
            try
            {
                response = new PerMailService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }

    }
}
