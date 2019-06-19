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

        /// <summary>
        /// Returns a group of Fuels matching the given keyword.
        /// </summary>
        /// <param name="search">The fuel name to search for</param>
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

        /// <summary>
        /// Retrieve the fuel by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Fuel</param>
        /// <returns>A GorivoDto</returns>
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

        /// <summary>
        /// Kreiranje novog goriva 
        /// </summary>
        /// <param name="gorivo">DTO potreban za kreiranje novog goriva</param>
        /// <returns>Status</returns>
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

        /// <summary>
        /// Izmena postojeceg goriva
        /// </summary>
        /// <param name="gorivo">DTO potreban za izmenu postojeceg goriva</param>
        /// <returns>Status</returns>
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

        /// <summary>
        /// Brisanje postojeceg goriva
        /// </summary>
        /// <param name="id">id koji odgovara vrsti goriva</param>
        /// <returns>Status</returns>
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
