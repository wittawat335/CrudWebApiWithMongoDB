using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.MongoDB.ViewModels;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetList()
        {
            var response = new ResponseList<RoleDTO>();
            try
            {
                response = await _service.GetAll();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("getRoleById")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var response = new ResponseTable<RoleDTO>();
            try
            {
                response = await _service.GetRoleById(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddRole(RoleDTO model)
        {
            var response = new Response();
            try
            {
                response = await _service.AddRole(model);
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
