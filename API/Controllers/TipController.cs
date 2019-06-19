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
    [Route("api/[controller]")]
    [ApiController]
    public class TipController : ControllerBase
    {
        private readonly IGetTypesCommand _getTypesCommand;
        private readonly IGetTypeCommand _getTypeCommand;
        private readonly IAddNewTypeCommand _addNewTypeCommand;
        private readonly IEditTypeCommand _editTypeCommand;
        private readonly IDeleteTypeCommand _deleteTypeCommand;

        public TipController(IGetTypesCommand getTypesCommand, IGetTypeCommand getTypeCommand, IDeleteTypeCommand deleteTypeCommand, IAddNewTypeCommand addNewTypeCommand, IEditTypeCommand editTypeCommand)
        {
            _getTypesCommand = getTypesCommand;
            _getTypeCommand = getTypeCommand;
            _deleteTypeCommand = deleteTypeCommand;
            _addNewTypeCommand = addNewTypeCommand;
            _editTypeCommand = editTypeCommand;
        }

        /// <summary>
        /// Returns a group of Types matching the given keyword.
        /// </summary>
        /// <param name="search">The type name to search for</param>
        // GET: api/Tip
        [HttpGet]
        public IActionResult Get([FromQuery] TypeSearch search)
        {
            try
            {
                var tip = _getTypesCommand.Execute(search);
                return Ok(tip);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Type doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Retrieve the type by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Type</param>
        /// <returns>A TypeDto</returns>
        // GET: api/Tip/5
        [HttpGet("{id}", Name = "GetTip")]
        public ActionResult<TypeDto> Get(int id)
        {
            try
            {
                var tip = _getTypeCommand.Execute(id);
                return Ok(tip);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Type doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Kreiranje novog tipa 
        /// </summary>
        /// <param name="tip">DTO potreban za kreiranje novog tipa</param>
        /// <returns>Status</returns>
        // POST: api/Tip
        [HttpPost]
        public IActionResult Post([FromBody] NapraviNoviTip tip)
        {
            try
            {
                _addNewTypeCommand.Execute(tip);
                return Ok();
            }
            catch (EntityAlreadyExists e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Izmena postojeceg tipa
        /// </summary>
        /// <param name="tip">DTO potreban za izmenu postojeceg tipa</param>
        /// <returns>Status</returns>
        // PUT: api/Tip/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NapraviNoviTip tip)
        {
            try
            {
                tip.TipId = id;
                _editTypeCommand.Execute(tip);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Brisanje postojeceg tipa
        /// </summary>
        /// <param name="id">id koji odgovara tipu</param>
        /// <returns>Status</returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteTypeCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Type doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
        }
    }
}
