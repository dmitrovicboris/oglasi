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
        private readonly IEditModelCommand _editModelCommand;
        private readonly IDeleteModelCommand _deleteModelCommand;
        private readonly IGetModelsOfBrandCommand _getModelsOfBrandCommand;

        public ModelController(IGetModelsCommand getModelsCommand, IGetModelCommand getModelCommand, IDeleteModelCommand deleteModelCommand, IAddNewModelCommand addNewModelCommand, IEditModelCommand editModelCommand, IGetModelsOfBrandCommand getModelsOfBrandCommand)
        {
            _getModelsCommand = getModelsCommand;
            _getModelCommand = getModelCommand;
            _deleteModelCommand = deleteModelCommand;
            _addNewModelCommand = addNewModelCommand;
            _editModelCommand = editModelCommand;
            _getModelsOfBrandCommand = getModelsOfBrandCommand;
        }

        /// <summary>
        /// Returns a group of Models matching the given keyword.
        /// </summary>
        /// <param name="search">The name to search for</param>
        // GET: api/Model
        [HttpGet]
        [Route("api/[controller]")]
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

        /// <summary>
        /// Retrieve the model by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Model</param>
        /// <returns>A ModelDto</returns>
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

        // GET: api/Model/5
        [Route("~/api/GetModelWithBrandId")]
        [HttpGet]
        public ActionResult<ModelDto> GetModelWithBrandId([FromQuery]int brandId)
        {
            try
            {
                var model = _getModelsOfBrandCommand.Execute(brandId);
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

        /// <summary>
        /// Kreiranje novog modela 
        /// </summary>
        /// <param name="model">DTO potreban za kreiranje novog modela</param>
        /// <returns>Status</returns>
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

        /// <summary>
        /// Izmena postojeceg modela
        /// </summary>
        /// <param name="model">DTO potreban za izmenu postojeceg modela</param>
        /// <returns>Status</returns>
        // PUT: api/Model/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NapraviNovModel model)
        {
            try
            {
                model.ModelId = id;
                _editModelCommand.Execute(model);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Brisanje postojeceg modela
        /// </summary>
        /// <param name="id">id koji odgovara modelu</param>
        /// <returns>Status</returns>
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
