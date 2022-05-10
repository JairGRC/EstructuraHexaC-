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

    public class PertelefonoController : ControllerBase
    {
        [HttpGet("GetByCodigo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo()
        {
            PertelefonoLstItemResponse response = null;
            PertelefonoLstItemRequest request = new PertelefonoLstItemRequest()
            {
                Filter = new PertelefonoFilter() { },
                FilterType = (PertelefonoFilterItemType)PertelefonoFilterListType.ByList
            };
            try
            {
                response = new PertelefonoService().GetLstPertelefono(request);
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
            PertelefonoLstItemResponse response = null;
            PertelefonoLstItemRequest request = new PertelefonoLstItemRequest()
            {
                Filter = new PertelefonoFilter()
                {
                    nConstCodigo = cPercodigo
                },
                FilterType = (PertelefonoFilterItemType)PertelefonoFilterListType.BycPerCodigo
            };
            try
            {
                response = new PertelefonoService().GetLstPertelefono(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
                if (response.LstItem == null)
                    return NotFound(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PertelefonoEntity Pertelefono)
        {
            PertelefonoResponse response = null;
            PertelefonoRequest request = new PertelefonoRequest()
            {
                Item = Pertelefono,
                Operation = Operation.Add
            };
            try
            {
                response = new PertelefonoService().Execute(request);
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
        public IActionResult Put([FromBody] PertelefonoEntity Pertelefono)
        {
            PertelefonoResponse response = null;
            PertelefonoRequest request = new PertelefonoRequest()
            {
                Item = Pertelefono,
                Operation = Operation.Edit
            };
            try
            {
                response = new PertelefonoService().Execute(request);
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
            PertelefonoResponse response = null;
            PertelefonoRequest request = new PertelefonoRequest()
            {
                Item = new PertelefonoEntity() { cPerCodigo = cPerCodigo },
                Operation = Operation.Delete
            };
            try
            {
                response = new PertelefonoService().Execute(request);
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
