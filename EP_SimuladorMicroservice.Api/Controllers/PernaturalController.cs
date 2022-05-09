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
    public class PernaturalController : ControllerBase
    {
        [HttpGet("GetByCodigo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo()
        {
            PernaturalLstItemResponse response = null;
            PernaturalLstItemRequest request = new PernaturalLstItemRequest()
            {
                Filter = new PernaturalFilter() { },
                FilterType = (PernaturalFilterItemType)PernaturalFilterListType.ByList
            };
            try
            {
                response = new PernaturalService().GetLstPernatural(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }


        [HttpGet("GetByCodigo/{cPercodigo}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo(string cPercodigo)
        {
            PernaturalItemResponse response = null;
            PernaturalItemRequest request = new PernaturalItemRequest()
            {
                Filter = new PernaturalFilter()
                {
                    nConstCodigo = cPercodigo
                },
                FilterType = PernaturalFilterItemType.BycPerCodigo
            };
            try
            {
                response = new PernaturalService().GetPernatural(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
                if (response.Item == null)
                    return NotFound(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PernaturalEntity Pernatural)
        {
            PernaturalResponse response = null;
            PernaturalRequest request = new PernaturalRequest()
            {
                Item = Pernatural,
                Operation = Operation.Add
            };
            try
            {
                response = new PernaturalService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put([FromBody] PernaturalEntity Pernatural)
        {
            PernaturalResponse response = null;
            PernaturalRequest request = new PernaturalRequest()
            {
                Item = Pernatural,
                Operation = Operation.Edit
            };
            try
            {
                response = new PernaturalService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpDelete("Delete/{cPerCodigo}")]
        public IActionResult Delete(string cPerCodigo)
        {
            PernaturalResponse response = null;
            PernaturalRequest request = new PernaturalRequest()
            {
                Item = new PernaturalEntity() { cPerCodigo = cPerCodigo },
                Operation = Operation.Delete
            };
            try
            {
                response = new PernaturalService().Execute(request);
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
