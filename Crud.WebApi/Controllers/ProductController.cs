using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    //[Authorize]
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
            var response = new ResponseList<ProductDTO>();
            try
            {
                response = await _service.GetAllAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = new ResponseTable<ProductDTO>();
            try
            {
                response = await _service.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string code)
        {
            var response = new ResponseTable<ProductDTO>();
            try
            {
                response = await _service.GetAsync(code);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Products model)
        {
            var response = new Response();
            try
            {
                response = await _service.AddAsync(model);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(ProductDTO model)
        {
            var response = new Response();
            try
            {
                response = await _service.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = new Response();
            try
            {
                response = await _service.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }
    }
}
