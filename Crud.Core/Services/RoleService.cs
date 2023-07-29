using AutoMapper;
using Crud.Core.Domain.RepositoryContract;
using Crud.Core.DTOs;
using Crud.Core.Model.MongoDB.Collections;
using Crud.Core.Model.MongoDB.ViewModels;
using Crud.Core.Model.Response;
using Crud.Core.Services.Contracts;
using Crud.Core.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Crud.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMongoRepository<Role> _repository;
        private readonly IMapper _mapper;

        public RoleService(IMongoRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response> AddRole(RoleDTO model)
        {
            var response = new Response();
            try
            {
                await _repository.InsertOneAsync(_mapper.Map<Role>(model));
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.Complete;
            }
            catch
            {
                throw;
            }

            return response;
        }
        public async Task<ResponseList<RoleDTO>> GetAll()
        {
            var response = new ResponseList<RoleDTO>();
            try
            {
                var list = await _repository.GetAll();
                response.data = _mapper.Map<List<RoleDTO>>(list);
                response.IsSuccess = Constants.StatusData.True;
                response.Message = Constants.Msg.GetList;
            }
            catch
            {
                throw;
            }

            return response;
        }
        public async Task<ResponseTable<RoleDTO>> GetRoleById(string id)
        {
            var response = new ResponseTable<RoleDTO>();
            try
            {
                var model = await _repository.FindByIdAsync(id);
                response.value = _mapper.Map<RoleDTO>(model);
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
