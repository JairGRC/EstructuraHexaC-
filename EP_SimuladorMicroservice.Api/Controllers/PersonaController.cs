using EP_SimuladorMicroservice.Entities.Filter;
using EP_SimuladorMicroservice.Entities.Request;
using EP_SimuladorMicroservice.Entities.Response;
using EP_SimuladorMicroservice.Entities;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP_SimuladorMicroservice.Service;
using EP_SimuladorMicroservice.Entities.Model;

namespace EP_SimuladorMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PersonaController : ControllerBase
    {

        [HttpGet("GetByCodigo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBycPerCodigo()
        {
            PersonaLstItemResponse response = null;
            PersonaLstItemRequest request = new PersonaLstItemRequest()
            {
                Filter = new PersonaFilter(){ },
                FilterType = (PersonaFilterItemType)PersonaFilterListType.ByList
            };
            try
            {
                response = new PersonaService().GetLstPersona(request);
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
            PersonaItemResponse response = null;
            PersonaItemRequest request = new PersonaItemRequest()
            {
                Filter = new PersonaFilter()
                {
                    nConstCodigo = cPercodigo
                },
                FilterType=PersonaFilterItemType.BycPerCodigo
            };
            try
            {
                response = new PersonaService().GetPersona(request);
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
        public IActionResult Post([FromBody] PersonaEntity Persona)
        {
            PersonaResponse response = null;
            PersonaRequest request = new PersonaRequest()
            {
                Item = Persona,
                Operation = Operation.Add
            };
            try
            {
                response = new PersonaService().Execute(request);
                if (!response.IsSuccess)
                    return BadRequest(response);
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(response);
        }
        [HttpPut]
        public IActionResult Put([FromBody] PersonaEntity Persona)
        {
            PersonaResponse response = null;
            PersonaRequest request = new PersonaRequest()
            {
                Item = Persona,
                Operation = Operation.Edit
            };
            try
            {
                response = new PersonaService().Execute(request);
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
            PersonaResponse response = null;
            PersonaRequest request = new PersonaRequest()
            {
                Item = new PersonaEntity() {cPerCodigo= cPerCodigo },
                Operation = Operation.Delete
            };
            try
            {
                response = new PersonaService().Execute(request);
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
