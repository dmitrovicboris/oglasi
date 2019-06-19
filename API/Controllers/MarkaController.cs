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
    public class MarkaController : ControllerBase
    {
        private readonly IGetBrandsCommand _getBrandsCommand;
        private readonly IGetBrandCommand _getBrandCommand;
        private readonly IAddNewBrandCommand _addNewBrandCommand;
        private readonly IEditBrandCommand _editBrandCommand;
        private readonly IDeleteBrandCommand _deleteBrandCommand;
        public MarkaController(IGetBrandsCommand getBrandsCommand, IGetBrandCommand getBrandCommand, IDeleteBrandCommand deleteBrandCommand, IAddNewBrandCommand addNewBrandCommand, IEditBrandCommand editBrandCommand)
        {
            _getBrandsCommand = getBrandsCommand;
            _getBrandCommand = getBrandCommand;
            _deleteBrandCommand = deleteBrandCommand;
            _addNewBrandCommand = addNewBrandCommand;
            _editBrandCommand = editBrandCommand;
        }

        /// <summary>
        /// Returns a group of Brands matching the given keyword.
        /// </summary>
        /// <param name="search">The brand name to search for</param>
        // GET: api/Marka
        [HttpGet]
        public IActionResult Get([FromQuery] BrandSearch search)
        {
            try
            {
                var marke = _getBrandsCommand.Execute(search);
                return Ok(marke);
            }
            catch (EntityNotFoundException e)
            {
                if(e.Message == "Marka doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Retrieve the brand by their ID.
        /// </summary>
        /// <param name="id">The ID of the desired Brand</param>
        /// <returns>A MarkaDto</returns>
        // GET: api/Marka/5
        [HttpGet("{id}", Name = "GetMarka")]
        public ActionResult<MarkaDto> Get(int id)
        {
            try
            {
                var marka = _getBrandCommand.Execute(id);
                return Ok(marka);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Marka doesn't exist.")
                {
                    return NotFound(e.Message);
                }
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Kreiranje nove marke 
        /// </summary>
        /// <param name="model">DTO potreban za kreiranje nove marke</param>
        /// <returns>Status</returns>
        // POST: api/Marka
        [HttpPost]
        public IActionResult Post([FromBody] NapraviIzmeniMarku marka)
        {
            try
            {
                _addNewBrandCommand.Execute(marka);
                return Ok();
            }
            catch (EntityAlreadyExists e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Izmena postojece marke
        /// </summary>
        /// <param name="marka">DTO potreban za izmenu postojeceg marke</param>
        /// <returns>Status</returns>
        // PUT: api/Marka/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NapraviIzmeniMarku marka)
        {
            try
            {
                marka.MarkaId = id;
                _editBrandCommand.Execute(marka);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        /// <summary>
        /// Brisanje postojece marke
        /// </summary>
        /// <param name="id">id koji odgovara marci</param>
        /// <returns>Status</returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteBrandCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Marka doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
        }
    }
}
