using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.MongoDB.ViewModels;
using Crud.Core.Model.Response;

namespace Crud.Core.Services.Contracts
{
    public interface IRoleService
    {
        Task<Response> AddRole(RoleViewModel model);
        ResponseList<Role> GetList();
    }
}
