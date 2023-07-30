using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.Response;

namespace Crud.Core.Services.Contracts
{
    public interface IRoleService
    {
        Task<ResponseList<RoleDTO>> GetAll();
        Task<Response> AddRole(Role model);
        Task<ResponseTable<RoleDTO>> GetRoleById(string id);
    }
}
