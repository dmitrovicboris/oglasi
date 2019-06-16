using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DataTransfer;
using Application.DataTransfer.CreateDtos;
using Application.Exceptions;
using Application.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Gorivo")]
    [ApiController]
    public class GorivoController : ControllerBase
    {
        private readonly IGetFuelsCommand _getFuelsCommand;
        private readonly IGetFuelCommand _getFuelCommand;
        private readonly IAddNewFuelTypeCommand _addFuelCommand;
        private readonly IEditFuelCommand _editFuelCommand;
        private readonly IDeleteFuelCommand _deleteFuelCommand;

        public GorivoController(IGetFuelsCommand getFuelsCommand, IGetFuelCommand getFuelCommand, IAddNewFuelTypeCommand addFuelCommand, IDeleteFuelCommand deleteFuelCommand, IEditFuelCommand editFuelCommand)
        {
            _getFuelsCommand = getFuelsCommand;
            _getFuelCommand = getFuelCommand;
            _addFuelCommand = addFuelCommand;
            _deleteFuelCommand = deleteFuelCommand;
            _editFuelCommand = editFuelCommand;
        }

        // GET: api/Gorivo
        [HttpGet]
        public IActionResult Get([FromQuery] FuelSearch search)
        {
            try
            {
                var goriva = _getFuelsCommand.Execute(search);
                return Ok(goriva);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Gorivo doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        // GET: api/Gorivo/5
        [HttpGet("{id}", Name = "GetGorivo")]
        public ActionResult<GorivoDto> Get(int id)
        {
            try
            {
                var gorivo = _getFuelCommand.Execute(id);
                return Ok(gorivo);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Gorivo doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        // POST: api/Gorivo
        [HttpPost]
        public IActionResult Post([FromBody] NapraviVrstuGoriva gorivo)
        {
            try
            {
                _addFuelCommand.Execute(gorivo);
                return Ok();
            }
            catch(EntityAlreadyExists e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        // PUT: api/Gorivo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NapraviVrstuGoriva gorivo)
        {
            try
            {
                gorivo.GorivoId = id;
                _editFuelCommand.Execute(gorivo);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteFuelCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Gorivo doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
        }
    }
}
