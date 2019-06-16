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
        private readonly IDeleteBrandCommand _deleteBrandCommand;
        public MarkaController(IGetBrandsCommand getBrandsCommand, IGetBrandCommand getBrandCommand, IDeleteBrandCommand deleteBrandCommand, IAddNewBrandCommand addNewBrandCommand)
        {
            _getBrandsCommand = getBrandsCommand;
            _getBrandCommand = getBrandCommand;
            _deleteBrandCommand = deleteBrandCommand;
            _addNewBrandCommand = addNewBrandCommand;
        }
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

        // PUT: api/Marka/5
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
