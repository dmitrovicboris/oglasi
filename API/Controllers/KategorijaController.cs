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
    public class KategorijaController : ControllerBase
    {
        private readonly IGetCategoriesCommand _getCategoriesCommand;
        private readonly IGetCategoryCommand _getCategoryCommand;
        private readonly IAddCategoryCommand _addCategoryCommand;
        private readonly IEditCategoryCommand _editCategoryCommand;
        private readonly IDeleteCategoryCommand _deleteCategoryCommand;

        public KategorijaController(IGetCategoriesCommand getCategoriesCommand, IGetCategoryCommand getCategoryCommand, IAddCategoryCommand addCategoryCommand, IEditCategoryCommand editCategoryCommand, IDeleteCategoryCommand deleteCategoryCommand)
        {
            _getCategoriesCommand = getCategoriesCommand;
            _getCategoryCommand = getCategoryCommand;
            _addCategoryCommand = addCategoryCommand;
            _editCategoryCommand = editCategoryCommand;
            _deleteCategoryCommand = deleteCategoryCommand;
        }

        /// <summary>
        /// Returns a group of Categories matching the given keyword.
        /// </summary>
        /// <param name="search">The category name to search for</param>
        // GET: api/Kategorija
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search)
        {
            try
            {
                var kategorija = _getCategoriesCommand.Execute(search);
                return Ok(kategorija);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Kategorija doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Retrieve the category by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Category</param>
        /// <returns>A KategorijaDTO</returns>
        // GET: api/Kategorija/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<KategorijaDto> Get(int id)
        {
            try
            {
                var kategorija = _getCategoryCommand.Execute(id);
                return Ok(kategorija);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Kategorija doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Kreiranje nove kategorije 
        /// </summary>
        /// <param name="kategorija">DTO potreban za kreiranje nove kategorije</param>
        /// <returns>Status</returns>
        // POST: api/Kategorija
        [HttpPost]
        public IActionResult Post([FromBody] NapraviNovuKategoriju kategorija)
        {
            try
            {
                _addCategoryCommand.Execute(kategorija);
                return Ok();
            }
            catch (EntityAlreadyExists e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Izmena postojece kategorije
        /// </summary>
        /// <param name="kategorija">DTO potreban za izmenu postojeceg modela</param>
        /// <returns>Status</returns>
        // PUT: api/Kategorija/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NapraviNovuKategoriju kategorija)
        {
            try
            {
                kategorija.KategorijaId = id;
                _editCategoryCommand.Execute(kategorija);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Brisanje postojece kategorije
        /// </summary>
        /// <param name="id">id koji odgovara kategoriji</param>
        /// <returns>Status</returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCategoryCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Kategorija doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
        }
    }
}
