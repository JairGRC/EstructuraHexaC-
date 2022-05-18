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
    public class PernameController : ControllerBase
    {
        [HttpGet("GetByCodigo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo()
        {
            PernameLstItemResponse response = null;
            PernameLstItemRequest request = new PernameLstItemRequest()
            {
                Filter = new PernameFilter() { },
                FilterType = (PernameFilterItemType)PernameFilterListType.ByList
            };
            try
            {
                response = new PernameService().GetLstPername(request);
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
            PernameLstItemResponse response = null;
            PernameLstItemRequest request = new PernameLstItemRequest()
            {
                Filter = new PernameFilter()
                {
                    nConstCodigo = cPercodigo
                },
                FilterType = (PernameFilterItemType)PernameFilterListType.ByListID
            };
            try
            {
                response = new PernameService().GetLstPername(request);
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
        public IActionResult Post([FromBody] PernameEntity Pername)
        {
            PernameResponse response = null;
            PernameRequest request = new PernameRequest()
            {
                Item = Pername,
                Operation = Operation.Add
            };
            try
            {
                response = new PernameService().Execute(request);
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
        public IActionResult Put([FromBody] PernameEntity Pername)
        {
            PernameResponse response = null;
            PernameRequest request = new PernameRequest()
            {
                Item = Pername,
                Operation = Operation.Edit
            };
            try
            {
                response = new PernameService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpDelete("Delete/{cPerCodigo}/{dPerFecEfectiva}")]
        public IActionResult Delete(string cPerCodigo,DateTime dPerFecEfectiva)
        {
            PernameResponse response = null;
            PernameRequest request = new PernameRequest()
            {
                Item = new PernameEntity() { 
                    cPerCodigo = cPerCodigo ,
                    dPerFecEfectiva= dPerFecEfectiva
                },
                Operation = Operation.Delete
            };
            try
            {
                response = new PernameService().Execute(request);
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
