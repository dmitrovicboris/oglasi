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
    public class ModelController : ControllerBase
    {
        private readonly IGetModelsCommand _getModelsCommand;
        private readonly IGetModelCommand _getModelCommand;
        private readonly IAddNewModelCommand _addNewModelCommand;
        private readonly IDeleteModelCommand _deleteModelCommand;

        public ModelController(IGetModelsCommand getModelsCommand, IGetModelCommand getModelCommand, IDeleteModelCommand deleteModelCommand, IAddNewModelCommand addNewModelCommand)
        {
            _getModelsCommand = getModelsCommand;
            _getModelCommand = getModelCommand;
            _deleteModelCommand = deleteModelCommand;
            _addNewModelCommand = addNewModelCommand;
        }

        // GET: api/Model
        [HttpGet]
        public IActionResult Get([FromQuery] ModelSearch search)
        {
            try
            {
                var model = _getModelsCommand.Execute(search);
                return Ok(model);
            }
            catch (EntityNotFoundException e)
            {
                if(e.Message == "Model doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        // GET: api/Model/5
        [HttpGet("{id}", Name = "GetModel")]
        public ActionResult<ModelDto> Get(int id)
        {
            try
            {
                var model = _getModelCommand.Execute(id);
                return Ok(model);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Model doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        // POST: api/Model
        [HttpPost]
        public IActionResult Post([FromBody] NapraviNovModel model)
        {
            try
            {
                _addNewModelCommand.Execute(model);
                return Ok();
            }
            catch (EntityAlreadyExists e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        // PUT: api/Model/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteModelCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Model doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
        }
    }
}
