using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.MongoDB.ViewModels;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Crud.Core.Utility;

namespace Crud.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMongoRepository<Role> _repository;

        public RoleService(IMongoRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<Response> AddRole(RoleViewModel model)
        {
            var response = new Response();
            var role = new Role();
            try
            {
                role.RoleName = model.RoleName;
                role.IsActive = model.IsActive;
                role.CreateBy = model.CreateBy;

                await _repository.InsertOneAsync(role);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.Complete;
            }
            catch
            {
                throw;
            }

            return response;
        }

        public ResponseList<Role> GetList()
        {
            var response = new ResponseList<Role>();
            try
            {
                var list = _repository.AsQueryable();
                response.data = list.ToList();
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }

            return response;
        }
    }
}
