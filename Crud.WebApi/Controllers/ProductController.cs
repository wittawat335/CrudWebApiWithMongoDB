using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("getListByCreateBy")]
        public IActionResult GetListByCreateBy(string filter)
        {
            return Ok(_service.GetListByCreateBy(filter));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string code)
        {
            return Ok(await _service.GetOneAsync(code));
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductInput model)
        {
            return Ok(await _service.AddAsync(model));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductDTO model)
        {
            return Ok(await _service.UpdateAsync(model));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _service.DeleteByIdAsync(id));
        }

        [HttpDelete("deleteListBy")]
        public async Task<IActionResult> DeleteListByCreateBy(string text)
        {
            return Ok(await _service.DeleteListAsyncByCreateBy(text));
        }


        //[HttpGet("getPeopleData")]
        //public IEnumerable<string> GetPeopleData()
        //{
        //    var people = _peopleRepository.FilterBy(
        //        filter => filter.FirstName != "rrr",
        //        projection => projection.Id.ToString()
        //    );
        //    return people;
        //}
    }
}
